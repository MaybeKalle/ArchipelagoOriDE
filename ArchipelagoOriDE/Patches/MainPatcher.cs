using System.Reflection;
using HarmonyLib;

namespace OriForestArchipelago.Patches
{
    public class MainPatcher
    {
        private Harmony _harmony; 
        public MainPatcher()
        {
            _harmony = new Harmony("de.maybekalle.archipelago.oribf");
        }

        public void Patch()
        {
            PatchPickupEvents();
            PatchGameProcess();
            PlayerSaveLoadActions();
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
            
            original = AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectMapStonePickup");
            patched = AccessTools.Method(typeof(PickupPatcher), "OnCollectMapStonePickupPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(GetAbilityPedestal), "ActivatePedestal");
            patched = AccessTools.Method(typeof(GetAbilityPedestalPatcher), "ActivatePedestalPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
        }

        private void PatchGameProcess()
        {
            MethodInfo original, patched;
            
            original = AccessTools.Method(typeof(GameController), "FixedUpdate");
            patched = AccessTools.Method(typeof(GameProcessPatch), "FixedUpdatePatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(GameController), "OnFinishedRestarting");
            patched = AccessTools.Method(typeof(GameProcessPatch), "OnFinishedRestartingPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
        }
        
        private void PlayerSaveLoadActions()
        {
            MethodInfo original, patched;

            original = AccessTools.Method(typeof(SaveGameController), "PerformSave");
            patched = AccessTools.Method(typeof(SaveGameControllerPatch), "PerformSavePatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
            
            original = AccessTools.Method(typeof(SeinDeathsManager), "OnDeath");
            patched = AccessTools.Method(typeof(SeinDeathsManagerPatcher), "OnDeathPatch");
            _harmony.Patch(original, new HarmonyMethod(patched));
        }
        
        public Harmony Harmony()
        {
            return this._harmony;
        }
    }
}