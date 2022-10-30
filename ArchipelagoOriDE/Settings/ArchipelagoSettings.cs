using UnityEngine;
using UnityModManagerNet;

namespace OriForestArchipelago.Settings
{
    [DrawFields(DrawFieldMask.Public)]
    public class ArchipelagoSettings
    {
        public int Slot = -1;
        public string Host = "Test";
        public int Port = 0;
        public string User = "a";
        public string Password = "a";
    }
}