using System;
using System.Collections;

namespace OriForestArchipelago
{
    public class State
    {
        public static bool Ingame;
        public static int SaveSlot;
        public static SeinCharacter SeinCharacter;
        public static bool ArchipelagoSlot;
        public static bool ModEnabled;
        public static string ModPath;
        public static bool Restarting;

        public static readonly string GameName = "Ori and the Blind Forest";

        public static bool ModShouldInteract()
        {
            return ArchipelagoSlot && ModEnabled;
        }
    }
}