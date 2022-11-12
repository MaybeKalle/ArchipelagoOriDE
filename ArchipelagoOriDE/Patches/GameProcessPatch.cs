using OriForestArchipelago.Network;

namespace OriForestArchipelago.Patches
{
    public class GameProcessPatch
    {
        public static bool FixedUpdatePatch()
        {
            if (!State.ModShouldInteract()) return true;
            Main.MessageQueue.UpdateMessage();
            SendQueue.Update();
            DebugKey.OnDebugUpdate();
            return true;
        }
    }
}