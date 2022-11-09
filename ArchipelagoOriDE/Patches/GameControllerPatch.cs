namespace OriForestArchipelago.Patches
{
    public class GameControllerPatch
    {
        public static bool UpdatePatch()
        {
            Main.MessageQueue.UpdateMessage();
            return true;
        }
    }
}