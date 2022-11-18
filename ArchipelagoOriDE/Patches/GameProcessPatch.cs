using OriForestArchipelago.Network;

namespace OriForestArchipelago.Patches
{
    public class GameProcessPatch
    {
        public static bool FixedUpdatePatch()
        {
            Main.MessageQueue.UpdateMessage();
            SendQueue.Update();
            DebugKey.OnDebugUpdate();
            RandomizerUtility.Update();
            return true;
        }

        public static bool OnFinishedRestartingPatch()
        {
            State.Restarting = false;
            return true;
        }
    }
}