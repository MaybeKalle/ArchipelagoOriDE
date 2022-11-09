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
            MethodInfo pickupKeystonePatchOriginal =
                AccessTools.Method(typeof(SeinPickupProcessor), "OnCollectKeystonePickup");
            MethodInfo pickupKeystonePatchNew =
                AccessTools.Method(typeof(PickupPatcher), "OnCollectKeystonePickupPatch");
            _harmony.Patch(pickupKeystonePatchOriginal, new HarmonyMethod(pickupKeystonePatchNew));
            
            MethodInfo updateGameSessionOriginal=
                AccessTools.Method(typeof(GameController), "FixedUpdate");
            MethodInfo updateGameSessionNew =
                AccessTools.Method(typeof(GameControllerPatch), "UpdatePatch");
            _harmony.Patch(updateGameSessionOriginal, new HarmonyMethod(updateGameSessionNew));
        }
        
        public Harmony Harmony()
        {
            return this._harmony;
        }
    }
}