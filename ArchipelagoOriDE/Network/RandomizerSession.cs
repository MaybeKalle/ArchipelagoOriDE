using System;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using UnityEngine;

namespace OriForestArchipelago.Network
{
    public class RandomizerSession
    {
        private ArchipelagoSession _session;
        private LoginSuccessful _loginSuccessful;
        private string _host;
        
        public RandomizerSession(string host)
        {
            _host = host;
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
                    Main.Logger.Log("Connected to the Archipelago server " + _host + " as " + username + " (Slot " + _loginSuccessful.Slot + ").");
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
                    return false;
                }
            }
            catch (Exception e)
            {
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
                if (_session.ConnectionInfo.Slot == receiver)
                {
                    RandomizerUtility.GiveItem(networkItem.Item);
                    if (receiver == sender)
                    {
                        Main.MessageQueue.CollectedItem(networkItem.Item);
                    }
                    else
                    {
                        Main.MessageQueue.ReceivedItem(networkItem.Item, _session.Players.GetPlayerAlias(sender));
                    }
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
    }
}