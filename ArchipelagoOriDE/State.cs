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

        public static bool ModShouldInteract()
        {
            return ArchipelagoSlot && ModEnabled;
        }
    }
}