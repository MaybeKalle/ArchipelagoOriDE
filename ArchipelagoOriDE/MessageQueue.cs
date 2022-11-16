using System.Collections.Generic;
using System.ComponentModel;
using Game;
using OriForestArchipelago.Types;
using UnityEngine;

namespace OriForestArchipelago
{
    public class MessageQueue
    {
        private Queue<MessageProvider> queuedMessages = new Queue<MessageProvider>();
        private readonly int QueueTime = 240;
        private readonly Vector3 InformationPosition = OnScreenPositions.BottomRight;

        private int CurrentQueueTime = 0;

        public MessageQueue()
        {
            
        }

        public void AddMessage(MessageProvider provider)
        {
            queuedMessages.Enqueue(provider);
        }
        public void AddMessage(string message)
        {
            ItemMessageProvider provider = new ItemMessageProvider();
            provider.SetMessage(message);
            queuedMessages.Enqueue(provider);
        }

        public void UpdateMessage()
        {
            if (CurrentQueueTime <= 0)
            {
                if (queuedMessages.Count == 0) return;
                CurrentQueueTime = QueueTime;
                var item = queuedMessages.Dequeue();
                UI.MessageController.ShowHintMessage(item, InformationPosition, (QueueTime / 90f));
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

        public void CollectedItem(long item)
        {
            AddMessage("$You$ found your #" + RandomizerUtility.DisplayNameById(item) + "#.");
        }
    }
}