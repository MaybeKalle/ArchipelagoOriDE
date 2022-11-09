namespace OriForestArchipelago.Patches
{
    public class GameProcessPatch
    {
        public static bool FixedUpdatePatch()
        {
            Main.MessageQueue.UpdateMessage();
            return true;
        }
    }
}