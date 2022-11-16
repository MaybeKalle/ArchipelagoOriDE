using System;

namespace OriForestArchipelago.Patches
{
    public class SaveGameControllerPatch
    {
        public static bool PerformSavePatch()
        {
            Main.RandomizerSession.SaveItems();
            return true;
        }
    }
}