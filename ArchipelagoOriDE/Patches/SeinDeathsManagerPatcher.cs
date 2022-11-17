namespace OriForestArchipelago.Patches
{
    public class SeinDeathsManagerPatcher
    {
        public static bool OnDeathPatch()
        {
            Main.RandomizerSession.RefreshItems();
            return true;
        }
    }
}