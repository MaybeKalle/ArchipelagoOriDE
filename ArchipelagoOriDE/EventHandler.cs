using System;

namespace OriForestArchipelago
{
    public class EventHandler
    {
        public static void OnStateChanged(GameStateMachine.State state)
        {
            Console.WriteLine("[Archipelago Debug] The game state changed to: " + state.ToString());
            if (state == GameStateMachine.State.Game)
            {
                Main.Logger.Log("Player opened save " + GameController.Instance.SaveGameController.CurrentSlotIndex);
            }
        }
    }
}