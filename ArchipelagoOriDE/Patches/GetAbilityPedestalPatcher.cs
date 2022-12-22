using HarmonyLib;

namespace OriForestArchipelago.Patches
{
    public class GetAbilityPedestalPatcher
    {
        public static bool ActivatePedestalPatch(ref GetAbilityPedestal __instance)
        {
            __instance.CurrentState = GetAbilityPedestal.States.Completed;
            __instance.ActivatePedestalSequence.Perform((IContext) null);
            Main.RandomizerSession.CollectedCheck(__instance.Ability);
            return false;
        }
    }
}