using OriForestArchipelago.Network;

namespace OriForestArchipelago.Patches
{
    public class GameProcessPatch
    {
        public static bool FixedUpdatePatch()
        {
            Main.MessageQueue.UpdateMessage();
            SendQueue.Update();
            return true;
        }
    }
}