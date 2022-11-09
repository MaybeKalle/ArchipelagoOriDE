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
            
            Main.MessageQueue.AddMessage("$You$ collected a $Keystone$");
            return true;
        }
    }
}