using HarmonyLib;

namespace OriForestArchipelago.Patches
{
    public class GetAbilityPedestalPatcher
    {
        public static bool ActivatePedestalPatch(ref GetAbilityPedestal __instance)
        {
            if (!State.ModShouldInteract()) return true;
            __instance.CurrentState = GetAbilityPedestal.States.Completed;
            Main.RandomizerSession.CollectedCheck(__instance.Ability);
            return false;
        }
    }
}