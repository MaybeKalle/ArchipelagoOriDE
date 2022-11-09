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
            if (!State.IngameRunning()) return true;
            
            ItemMessageProvider provider = new ItemMessageProvider();

            string keystonePosition = "[" +  keystonePickup.Bounds.center.x + " | " +  keystonePickup.Bounds.center.y + " | " +  keystonePickup.Bounds.center.z + "]";
            
            Main.MessageQueue.AddMessage("You $collected$ a #Keystone#");
            return true;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            if (!State.IngameRunning()) return true;
            
            return true;
        }
    }
}