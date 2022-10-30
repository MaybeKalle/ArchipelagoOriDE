using Game;
using UnityEngine;

namespace OriForestArchipelago
{
    public class MessageQueue
    {
        public static void sendLocalItem()
        {
            GameController.Instance.SendMessage("Test");
        }
    }
}