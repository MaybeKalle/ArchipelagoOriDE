using System;
using Game;
using UnityEngine;

namespace OriForestArchipelago
{
    public class EventHandler
    {
        public static void OnStateChanged(GameStateMachine.State state)
        {
            if (state == GameStateMachine.State.Game)
            {
                Main.Logger.Log("Player opened save " + GameController.Instance.SaveGameController.CurrentSlotIndex);
            }
        }

        public static void OnCharacterSwitched(bool ingame, string character, SeinCharacter seinCharacter)
        {
            if (seinCharacter != null) State.SeinCharacter = seinCharacter;
        }
    }
}