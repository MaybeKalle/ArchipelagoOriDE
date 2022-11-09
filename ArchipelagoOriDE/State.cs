using System.Collections;

namespace OriForestArchipelago
{
    public class State
    {
        public static bool ModActive;
        public static bool Ingame;
        public static int SaveSlot;
        public static SeinCharacter SeinCharacter;


        public static bool IngameRunning()
        {
            return ModActive && Ingame;
        }
    }
}