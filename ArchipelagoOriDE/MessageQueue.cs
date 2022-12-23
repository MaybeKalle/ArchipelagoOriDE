using System.Collections.Generic;
using System.ComponentModel;
using Game;
using OriForestArchipelago.Types;
using UnityEngine;

namespace OriForestArchipelago
{
    public class MessageQueue
    {
        private Queue<KeyValuePair<MessageProvider, Vector3>> menuMessages = new Queue<KeyValuePair<MessageProvider, Vector3>>();
        private Queue<KeyValuePair<MessageProvider, Vector3>> queuedMessages = new Queue<KeyValuePair<MessageProvider, Vector3>>();
        private readonly int QueueTime = 240;
        private readonly Vector3 DefaultInformationPosition;

        private int CurrentQueueTime = 0;

        public MessageQueue()
        {
            Vector3 position = OnScreenPositions.TopCenter;
            position.y += 0.5f;
            DefaultInformationPosition = position;
        }
        
        public void AddMessage(MessageProvider provider)
        {
            AddMessage(provider, DefaultInformationPosition);
        }
        public void AddMessage(string message)
        {
            AddMessage(message, DefaultInformationPosition);
        }
        
        public void AddMenuMessage(MessageProvider provider)
        {
            AddMenuMessage(provider, DefaultInformationPosition);
        }
        public void AddMenuMessage(string message)
        {
            AddMenuMessage(message, DefaultInformationPosition);
        }
        
        public void AddMessage(MessageProvider provider, Vector3 position)
        {
            queuedMessages.Enqueue(new KeyValuePair<MessageProvider, Vector3>(provider, position));
        }
        public void AddMessage(string message, Vector3 position)
        {
            ItemMessageProvider provider = new ItemMessageProvider();
            provider.SetMessage(message);
            queuedMessages.Enqueue(new KeyValuePair<MessageProvider, Vector3>(provider, position));
        }

        public void AddMenuMessage(MessageProvider provider, Vector3 position)
        {
            menuMessages.Enqueue(new KeyValuePair<MessageProvider, Vector3>(provider, position));
        }
        public void AddMenuMessage(string message, Vector3 position)
        {
            ItemMessageProvider provider = new ItemMessageProvider();
            provider.SetMessage(message);
            menuMessages.Enqueue(new KeyValuePair<MessageProvider, Vector3>(provider, position));
        }

        public void Clear()
        {
            queuedMessages.Clear();
        }
        
        public void UpdateMessage()
        {
            IngameMessage();
            MenuMessage();
        }

        private void IngameMessage()
        {
            if (!State.Ingame || State.SeinCharacter == null) return;
            if (CurrentQueueTime <= 0)
            {
                if (queuedMessages.Count == 0) return;
                CurrentQueueTime = QueueTime;
                var item = queuedMessages.Dequeue();
                UI.MessageController.ShowHintMessage(item.Key, item.Value, (QueueTime / 90f));
            }
            else
            {
                CurrentQueueTime--;
            }
        }

        private void MenuMessage()
        {
            if (State.Ingame || State.Restarting || GameStateMachine.Instance == null || GameStateMachine.Instance.CurrentState != GameStateMachine.State.TitleScreen) return;
            if (CurrentQueueTime <= 0)
            {
                if (menuMessages.Count == 0) return;
                CurrentQueueTime = QueueTime;
                var item = menuMessages.Dequeue();
                UI.MessageController.ShowHintMessage(item.Key, item.Value, (QueueTime / 90f));
            }
            else
            {
                CurrentQueueTime--;
            }
        }

        public void ReceivedItem(long item, string sender)
        {
            AddMessage("$" + sender + "$ sent you #" + RandomizerUtility.DisplayNameById(item) + "#.");
        }
        
        public void SentItem(string item, string receiver)
        {
            AddMessage("You sent #" + item.Replace("_", " ") + "# to $" + receiver + "$.");
        }

        public void CollectedItem(long item)
        {
            string itemName = RandomizerUtility.DisplayNameById(item);
            if (itemName.StartsWith("an ")) itemName = itemName.Substring(3);
            else if (itemName.StartsWith("a ")) itemName = itemName.Substring(2);
            AddMessage("$You$ found your #" + itemName + "#.");
        }
        
        public int GetGameMessageSize()
        {
            return queuedMessages.Count;
        }
        
        public int GetMenuMessageSize()
        {
            return menuMessages.Count;
        }
    }
}