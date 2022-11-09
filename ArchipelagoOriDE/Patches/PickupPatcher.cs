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
            ItemMessageProvider provider = new ItemMessageProvider();

            string keystonePosition = "[" +  keystonePickup.Bounds.center.x + " | " +  keystonePickup.Bounds.center.y + " | " +  keystonePickup.Bounds.center.z + "]";
            
            Main.MessageQueue.AddMessage("You $collected$ a #Keystone#");
            return true;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            return true;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            return true;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            return true;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            return true;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            return true;
        }
    }
}