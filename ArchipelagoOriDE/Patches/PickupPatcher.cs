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
            keystonePickup.Collected();
            Main.RandomizerSession.CollectedCheck(keystonePickup.Bounds.center);
            return false;
        }

        public static bool OnCollectSkillPointPickupPatch(SkillPointPickup skillPointPickup)
        {
            if (!State.ModShouldInteract()) return true;
            skillPointPickup.Collected();
            Main.RandomizerSession.CollectedCheck(skillPointPickup.Bounds.center);
            return false;
        }

        public static bool OnCollectEnergyOrbPickupPatch(EnergyOrbPickup energyOrbPickup)
        {
            return true;
        }

        public static bool OnCollectMaxEnergyContainerPickupPatch(MaxEnergyContainerPickup energyContainerPickup)
        {
            if (!State.ModShouldInteract()) return true;
            energyContainerPickup.Collected();
            Main.RandomizerSession.CollectedCheck(energyContainerPickup.Bounds.center);
            return false;
        }

        public static bool OnCollectExpOrbPickupPatch(ExpOrbPickup expOrbPickup)
        {
            if (!State.ModShouldInteract()) return true;
            if (expOrbPickup.MessageType == ExpOrbPickup.ExpOrbMessageType.None) return true;
            expOrbPickup.Collected();
            Main.RandomizerSession.CollectedCheck(expOrbPickup.Bounds.center);
            return false;
        }

        public static bool OnCollectMaxHealthContainerPickupPatch(MaxHealthContainerPickup maxHealthContainerPickup)
        {
            if (!State.ModShouldInteract()) return true;
            maxHealthContainerPickup.Collected();
            Main.RandomizerSession.CollectedCheck(maxHealthContainerPickup.Bounds.center);
            return false;
        }

        public static bool OnCollectRestoreHealthPickupPatch(RestoreHealthPickup restoreHealthPickup)
        {
            if (!State.ModShouldInteract()) return true;
            return true;
        }

        public static bool OnCollectMapStonePickupPatch(MapStonePickup mapStonePickup)
        {
            if (!State.ModShouldInteract()) return true;
            mapStonePickup.Collected();
            Main.RandomizerSession.CollectedCheck(mapStonePickup.Bounds.center);
            return false;
        }
    }
}