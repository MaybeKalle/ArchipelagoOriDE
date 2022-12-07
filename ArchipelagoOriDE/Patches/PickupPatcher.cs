using System.Linq;
using Newtonsoft.Json;
using OriForestArchipelago.Types;
using TinyJson;

namespace OriForestArchipelago.Patches
{
    public class PickupPatcher
    {
        public static bool OnCollectKeystonePickupPatch(KeystonePickup keystonePickup)
        {
            if (!State.ModShouldInteract()) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(keystonePickup).ToString(Formatting.None));
            return true;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            if (!State.ModShouldInteract()) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(skillPointPickup).ToString(Formatting.None));
            return true;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            if (!State.ModShouldInteract()) return true;
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            if (!State.ModShouldInteract()) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(energyContainerPickup).ToString(Formatting.None));
            return true;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            if (!State.ModShouldInteract()) return true;
            if (expOrbPickup.MessageType == ExpOrbPickup.ExpOrbMessageType.None) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(expOrbPickup).ToString(Formatting.None));
            return true;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            if (!State.ModShouldInteract()) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(maxHealthContainerPickup).ToString(Formatting.None));
            return true;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            if (!State.ModShouldInteract()) return true;
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            if (!State.ModShouldInteract()) return true;
            Main.Logger.Log("[Collect] " + RandomizerUtility.GenerateObjectJson(mapStonePickup).ToString(Formatting.None));
            return true;
        }
    }
}