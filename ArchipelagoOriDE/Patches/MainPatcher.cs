using System.Reflection;
using HarmonyLib;

namespace OriForestArchipelago.Patches
{
    public class MainPatcher
    {
        private Harmony _harmony; 
        public MainPatcher()
        {
            _harmony = new Harmony("FE6142B8-5A93-4A54-A034-738D603489A2");
        }

        public void Patch()
        {
            MethodInfo updateGameSessionOriginal=
                AccessTools.Method(typeof(GameController), "FixedUpdate");
            MethodInfo updateGameSessionNew =
                AccessTools.Method(typeof(GameControllerPatch), "UpdatePatch");
            _harmony.Patch(updateGameSessionOriginal, new HarmonyMethod(updateGameSessionNew));
        }

        private void PatchPickupEvents()
        {
            MethodInfo original, patched;
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectKeystonePickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectKeystonePickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectSkillPointPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectSkillPointPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectEnergyOrbPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectEnergyOrbPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectMaxEnergyContainerPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectMaxEnergyContainerPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectExpOrbPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectExpOrbPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectMaxHealthContainerPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectMaxHealthContainerPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectRestoreHealthPickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectRestoreHealthPickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectMapStone");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectMapStonePickup");
            _harmony.Patch(original, new HarmonyMethod(patched));
        }
        
        public Harmony Harmony()
        {
            return this._harmony;
        }
    }
}