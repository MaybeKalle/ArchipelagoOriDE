using System;
using System.Collections.Generic;
using Game;

namespace OriForestArchipelago
{
    public class RandomizerUtility
    {
        private static readonly Dictionary<long, string> ItemDictionary = new Dictionary<long, string>()
        {
            {262144, "100 EXP"},
            {262145, "an Ability Cell"},
            {262146, "Bash"},
            {262147, "a Health Cell"},
            {262148, "a Plant"},
            {262149, "a Mapstone"},
            {262150, "Charge Flame"},
            {262151, "Charge Jump"},
            {262152, "Climb"},
            {262153, "a Mapstone Fragment"},
            {262154, "Dash"},
            {262155, "an Energy Cell"},
            {262156, "200 EXP"},
            {262157, "Double Jump"},
            {262158, "15 EXP"},
            {262159, "Wind Event"},
            {262160, "a Keystone"},
            {262161, "Water Event"},
            {262162, "Glide"},
            {262163, "Grenade"},
            {262164, "the Gumon Seal"},
            {262165, "CS"},
            {262166, "Stomp"},
            {262167, "the Sunstone"},
            {262168, "Wall Jump"},
            {262169, "the Water Vein"},
        };
        
        private static Queue<long> _itemQueue = new Queue<long>();

        public static string DisplayNameById(long id)
        {
            return ItemDictionary[id];
        }

        public static void GiveItem(long id)
        {
            _itemQueue.Enqueue(id);
        }
        
        private static void ProccessGiveItem(long id)
        {
            switch (id)
            {
                case 262144:
                    AddExperience(100);
                    break;
                case 262145:
                    State.SeinCharacter.Level.GainSkillPoint();
                    ++State.SeinCharacter.Inventory.SkillPointsCollected;
                    UI.SeinUI.ShakeExperienceBar();
                    break;
                case 262146:
                    AddAbility(AbilityType.Bash);
                    break;
                case 262147:
                    State.SeinCharacter.Mortality.Health.GainMaxHeartContainer();
                    UI.SeinUI.ShakeHealthbar();
                    break;
                case 262148:
                    // TODO: Add plant
                case 262149:
                    UnlockMap();
                    break;
                case 262150:
                    AddAbility(AbilityType.ChargeFlame);
                    break;
                case 262151:
                    AddAbility(AbilityType.ChargeJump);
                    break;
                case 262152:
                    AddAbility(AbilityType.Climb);
                    break;
                case 262153:
                    State.SeinCharacter.Inventory.CollectMapstone(1);
                    UI.SeinUI.ShakeMapstones();
                    break;
                case 262154:
                    AddAbility(AbilityType.Dash);
                    break;
                case 262155:
                    State.SeinCharacter.Energy.Max++;
                    State.SeinCharacter.Energy.Current = State.SeinCharacter.Energy.Max;
                    break;
                case 262156:
                    AddExperience(200);
                    break;
                case 262157:
                    AddAbility(AbilityType.DoubleJump);
                    break;
                case 262158:
                    AddExperience(15);
                    break;
                case 262159:
                    TriggerWorldEvent();
                    break;
                case 262160:
                    State.SeinCharacter.Inventory.CollectKeystones(1);
                    UI.SeinUI.ShakeKeystones();
                    break;
                case 262161:
                    TriggerWorldEvent();
                    break;
                case 262162:
                    AddAbility(AbilityType.Glide);
                    break;
                case 262163:
                    AddAbility(AbilityType.Grenade);
                    break;
                case 262164:
                    TriggerWorldEvent();
                    break;
                case 262165:
                    // TODO: Add CS
                    break;
                case 262166:
                    AddAbility(AbilityType.Stomp);
                    break;
                case 262167:
                    TriggerWorldEvent();
                    break;
                case 262168:
                    AddAbility(AbilityType.WallJump);
                    break;
                case 262169:
                    TriggerWorldEvent();
                    break;
                default:
                    Console.WriteLine("[Archipelago Debug] Unknown item ID: " + id);
                    break;
            }
        }
        
        // TODO: Implement methods for abilities
        private static void AddAbility(AbilityType type)
        {
            State.SeinCharacter.PlayerAbilities.SetAbility(type, true);
        }
        
        // TODO: Implement method for world events
        private static void TriggerWorldEvent()
        {
            
        }

        // TODO: Unlock Map
        private static void UnlockMap()
        {
            
        }
        
        private static void AddExperience(int amount)
        {
            amount = amount * (!State.SeinCharacter.PlayerAbilities.SoulEfficiency.HasAbility ? 1 : 2);
            State.SeinCharacter.Level.GainExperience(amount);
            UI.SeinUI.ShakeExperienceBar();
        }

        public static void Update()
        {
            if (State.Ingame && State.SeinCharacter != null)
            {
                long nextItem = _itemQueue.Dequeue();
                ProccessGiveItem(nextItem);
            }
        }
    }
}