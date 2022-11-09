using System;
using HarmonyLib;
using UnityEngine;

namespace OriForestArchipelago.Patches
{
    public class PickupPatcher
    {
        public static bool OnCollectKeystonePickupPatch(KeystonePickup keystonePickup)
        {
            string vector = "[" +  State.SeinCharacter.Position.x + " | " +  State.SeinCharacter.Position.y + " | " +  State.SeinCharacter.Position.z + "]";
            Main.Logger.Log("Trying to pickup keystone at " + vector);
            return true;
        }
    }
}