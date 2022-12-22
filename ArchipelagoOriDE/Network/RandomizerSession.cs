using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Newtonsoft.Json;
using UnityEngine;

namespace OriForestArchipelago.Network
{
    public class RandomizerSession
    {
        private ArchipelagoSession _session;
        private LoginSuccessful _loginSuccessful;
        private string _host;
        private Dictionary<int, long> _receivedItems;
        private bool _connected;

        public RandomizerSession(string host)
        {
            _host = host;
            _receivedItems = new Dictionary<int, long>();
        }
        
        public bool Connect(string username, string password = null)
        {
            try
            {
                if (_host.Contains(":"))
                {
                    var hostSplit = _host.Split(':');
                    _session = ArchipelagoSessionFactory.CreateSession(hostSplit[0], int.Parse(hostSplit[1]));
                    _session.MessageLog.OnMessageReceived += LogMessage;
                }
                else
                {
                    _session = ArchipelagoSessionFactory.CreateSession(_host);
                    _session.MessageLog.OnMessageReceived += LogMessage;
                }
                
                LoginResult result = _session.TryConnectAndLogin(State.GameName, username, ItemsHandlingFlags.AllItems, null, null, password);
                if (result.Successful)
                {
                    _loginSuccessful = (LoginSuccessful)result;
                    Main.Logger.Log("Connected to the Archipelago server " + _host + " as " + username + " (Slot " + (_loginSuccessful.Slot + 1) + ").");
                    _connected = true;
                    RefreshItems();
                    return true;
                }
                else
                {
                    LoginFailure failure = (LoginFailure)result;
                    Main.Logger.Critical("Failed to connect to the Archipelago server:");
                    foreach (var error in failure.Errors)
                    {
                        Main.Logger.Critical(" - " + error);
                    }

                    State.Restarting = true;
                    GameController.Instance.RestartGame();
                    Main.MessageQueue.AddMenuMessage("Failed to connect to the Archipelago server.", OnScreenPositions.MiddleCenter);
                    return false;
                }
            }
            catch (Exception e)
            {
                State.Restarting = true;
                GameController.Instance.RestartGame();
                Main.MessageQueue.AddMenuMessage("Failed to connect to the Archipelago server.", OnScreenPositions.MiddleCenter);
                Main.Logger.Critical("Failed to connect to the Archipelago server: "+ e.Message);
                throw;
            }
        }
        
        private void LogMessage(LogMessage message)
        {
            bool send = false;
            int receiver = -1;
            int sender = -1;
            NetworkItem networkItem = new NetworkItem();

            Main.Logger.Log(message.ToString());

            if (message is ItemSendLogMessage)
            {
                ItemSendLogMessage itemSendLogMessage = (ItemSendLogMessage)message;
                send = true;
                receiver = itemSendLogMessage.ReceivingPlayerSlot;
                sender = itemSendLogMessage.SendingPlayerSlot;
                networkItem = itemSendLogMessage.Item;
            }

            if (message is HintItemSendLogMessage)
            {
                HintItemSendLogMessage hintItemSendLogMessage = (HintItemSendLogMessage)message;
                send = false;
                receiver = hintItemSendLogMessage.ReceivingPlayerSlot;
                sender = hintItemSendLogMessage.SendingPlayerSlot;
                networkItem = hintItemSendLogMessage.Item;
            }

            if (send)
            {
                if (_session.ConnectionInfo.Slot == receiver && _session.ConnectionInfo.Slot != sender)
                {
                    RandomizerUtility.GiveItem(networkItem.Item);
                    Main.MessageQueue.ReceivedItem(networkItem.Item, _session.Players.GetPlayerAlias(sender));
                }
                else if (_session.ConnectionInfo.Slot == receiver && _session.ConnectionInfo.Slot == sender)
                {
                    RandomizerUtility.GiveItem(networkItem.Item);
                    Main.MessageQueue.CollectedItem(networkItem.Item);
                }
                else if (_session.ConnectionInfo.Slot != receiver && _session.ConnectionInfo.Slot == sender)
                {
                    Main.MessageQueue.SentItem(networkItem.Item, _session.Players.GetPlayerAlias(receiver));
                }
            }
        }

        public bool IsConnected()
        {
            return _session != null && _session.Socket.Connected;
        }

        public void Disconnect()
        {
            _session.Socket.Disconnect();
            _session = null;
            Main.Logger.Log("Disconnected from the Archipelago server.");
        }

        public string getLocationName(int id)
        {
            return this._session.Locations.GetLocationNameFromId(id);
        }
        
        public void RefreshItems(bool _message = true)
        {
            if (!_connected) return;
            ReadOnlyCollection<NetworkItem> items = _session.Items.AllItemsReceived;
            Dictionary<int, long> savedItems = SavedItems(_session.RoomState.Seed);
            for (int i = 0; i < items.Count; i++)
            {
                NetworkItem item = items[i];
                if (!savedItems.ContainsKey(i) || savedItems[i] != item.Item)
                {
                    Main.Logger.Log("Received '" + RandomizerUtility.DisplayNameById(item.Item) + "' from " + _session.Players.GetPlayerAlias(item.Player));
                    RandomizerUtility.GiveItem(item.Item);
                    if(_message) Main.MessageQueue.ReceivedItem(item.Item, _session.Players.GetPlayerAlias(item.Player));
                }
                _receivedItems[i] = items[i].Item;
            }
        }


        private Dictionary<int, long> SavedItems(string seed)
        {
            string saveDir = Path.Combine(State.ModPath, "seeds");
            string saveFile = Path.Combine(saveDir, "A_" + seed + ".json");
            if(!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            if (File.Exists(saveFile))
            {
                string json = File.ReadAllText(saveFile);
                return JsonConvert.DeserializeObject<Dictionary<int, long>>(json);
            }
            else
            {
                return new Dictionary<int, long>();
            }
        }

        public void CollectedCheck(Vector3 location)
        {
            long id = RandomizerUtility.GetLocationIdFromLocationVector(location);
            if (id == -1) return;
            if (_session == null || !_connected) return;
            if (_session.Locations.GetLocationNameFromId(id) == "Unknown") Main.Logger.Error("Unknown location id: " + id);
            _session.Locations.CompleteLocationChecks(id);
        }
        
        public void SaveItems()
        {
            if (!_connected) return;
            WriteSeed(_session.RoomState.Seed, _receivedItems);
        }
        
        public void AddItemToSaveList(long item)
        {
            if (!_connected) return;
            Dictionary<int, long> items = SavedItems(_session.RoomState.Seed);
            int index = 0;
            while (items.ContainsKey(index))
            {
                index++;
            }
            items.Add(index, item);
        }
        
        public void WriteSeed(string seed, Dictionary<int, long> dictionary)
        {
            if (!_connected) return;
            string json = JsonConvert.SerializeObject(dictionary);
            string saveDir = Path.Combine(State.ModPath, "seeds");
            string saveFile = Path.Combine(saveDir, "A_" + seed + ".json");
            if(!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            if (!File.Exists(saveFile))
            {
                File.Create(saveFile).Dispose();
            }
            File.WriteAllText(saveFile, json);
        }
    }
}