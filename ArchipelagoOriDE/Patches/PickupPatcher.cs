using System;
using Game;
using HarmonyLib;
using OriForestArchipelago.Types;
using UnityEngine;

namespace OriForestArchipelago.Patches
{
    public class PickupPatcher
    {
        public static bool OnCollectKeystonePickupPatch(KeystonePickup keystonePickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ a #Keystone#");
            return true;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ a #Skill Point#");
            return true;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ an #Energy Orb#");
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ an #Energy Cell#");
            return true;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            if (expOrbPickup.MessageType == ExpOrbPickup.ExpOrbMessageType.None) return true;
            Main.Logger.Log("Collected Experience Orb: " + expOrbPickup.Amount + " - Type: " + expOrbPickup.MessageType);
            Main.MessageQueue.AddMessage("You $collected$ an #Experience Orb#");
            return true;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ a #Health Cell#");
            return true;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ a #Health Restore#");
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            Main.MessageQueue.AddMessage("You $collected$ a #Map Stone#");
            return true;
        }
    }
}