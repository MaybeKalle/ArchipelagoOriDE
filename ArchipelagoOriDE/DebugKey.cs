using OriForestArchipelago.Settings;
using UnityEngine;
using UnityModManagerNet;

namespace OriForestArchipelago
{
    public class DebugKey
    {
        public static void OnDebugUpdate()
        {
            if (!State.ModShouldInteract()) return;
            if(Main.CurrentModSettings.DebugSettings.DebugKeybind.Down())
            {
                switch (Main.CurrentModSettings.DebugSettings.DebugKeyAction)
                {
                    case DebugKeyAction.OutputState:
                        Main.Logger.Log("Current state of the modification:");
                        Main.Logger.Log("   - Ingame: " + State.Ingame);
                        Main.Logger.Log("   - SeinCharacter: " + State.SeinCharacter);
                        Main.Logger.Log("   - ArchipelagoSlot: " + State.ArchipelagoSlot);
                        Main.Logger.Log("   - ModPath: " + State.ModPath);
                        Main.Logger.Log("   - Restarting: " + State.Restarting);
                        Main.Logger.Log("   ");
                        Main.Logger.Log("   - Message Queue: " + Main.MessageQueue.GetGameMessageSize());
                        Main.Logger.Log("   - Menu Message Queue: " + Main.MessageQueue.GetMenuMessageSize());
                        break;
                    case DebugKeyAction.DisplayLocation:
                        string area = GameWorld.Instance.FindAreaFromPosition(State.SeinCharacter.Position)
                            .AreaNameString;
                        Main.MessageQueue.AddMessage("$" + area + "$: " + State.SeinCharacter.Position.x + ", " +
                                                     State.SeinCharacter.Position.y, OnScreenPositions.TopCenter);
                        break;
                }
            }
        }
    }
}