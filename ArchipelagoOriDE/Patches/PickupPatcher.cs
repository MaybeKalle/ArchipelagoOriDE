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
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ a #Keystone#");
            return true;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ a #Skill Point#");
            return true;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ an #Energy Orb#");
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ an #Energy Cell#");
            return true;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            if (!State.ModActive) return true;
            if (expOrbPickup.MessageType == ExpOrbPickup.ExpOrbMessageType.None) return true;
            Main.Logger.Log("Collected Experience Orb: " + expOrbPickup.Amount + " - Type: " + expOrbPickup.MessageType);
            Main.MessageQueue.AddMessage("You $collected$ an #Experience Orb#");
            return true;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ a #Health Cell#");
            return true;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ a #Health Restore#");
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            if (!State.ModActive) return true;
            Main.MessageQueue.AddMessage("You $collected$ a #Map Stone#");
            return true;
        }
    }
}