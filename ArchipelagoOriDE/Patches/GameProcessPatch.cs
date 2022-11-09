namespace OriForestArchipelago.Patches
{
    public class GameProcessPatch
    {
        public static bool FixedUpdatePatch()
        {
            if (!State.IngameRunning()) return true;
            Main.MessageQueue.UpdateMessage();
            return true;
        }
    }
}