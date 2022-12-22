using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace OriForestArchipelago
{
    public class RandomizerUtility
    {
        private static readonly Dictionary<long, string> ItemDictionary = 
            new Dictionary<long, string>()
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

        private static readonly Dictionary<KeyValuePair<long, long>, long> LocationDictionary =
            new Dictionary<KeyValuePair<long, long>, long>()
            {
                { new KeyValuePair<long, long>(432, -324), 262146 },
                { new KeyValuePair<long, long>(208, -431), 262258 },
                { new KeyValuePair<long, long>(394, -309), 262147 },
                { new KeyValuePair<long, long>(252, -331), 262236 },
                { new KeyValuePair<long, long>(224, -359), 262238 },
                { new KeyValuePair<long, long>(459, -506), 262231 },
                { new KeyValuePair<long, long>(462, -489), 262232 },
                { new KeyValuePair<long, long>(527, -544), 262233 },
                { new KeyValuePair<long, long>(307, -525), 262234 },
                { new KeyValuePair<long, long>(197, -229), 262338 },
                { new KeyValuePair<long, long>(183, -291), 262340 },
                { new KeyValuePair<long, long>(154, -291), 262339 },
                { new KeyValuePair<long, long>(346, -255), 262341 },
                { new KeyValuePair<long, long>(279, -375), 262235 },
                { new KeyValuePair<long, long>(339, -418), 262237 },
                { new KeyValuePair<long, long>(391, -423), 262245 },
                { new KeyValuePair<long, long>(304, -303), 262342 },
                { new KeyValuePair<long, long>(-703, -390), 262151 },
                { new KeyValuePair<long, long>(-625, -315), 262157 },
                { new KeyValuePair<long, long>(-858, -353), 262153 },
                { new KeyValuePair<long, long>(-892, -328), 262154 },
                { new KeyValuePair<long, long>(-887, -250), 262155 },
                { new KeyValuePair<long, long>(-869, -255), 262156 },
                { new KeyValuePair<long, long>(-841, -350), 262152 },
                { new KeyValuePair<long, long>(518, 339), 262244 },
                { new KeyValuePair<long, long>(536, 434), 262287 },
                { new KeyValuePair<long, long>(537, 733), 262159 },
                { new KeyValuePair<long, long>(533, 827), 262160 },
                { new KeyValuePair<long, long>(534, 661), 262161 },
                { new KeyValuePair<long, long>(519, 867), 262158 },
                { new KeyValuePair<long, long>(540, 277), 262241 },
                { new KeyValuePair<long, long>(531, 267), 262240 },
                { new KeyValuePair<long, long>(456, 566), 262285 },
                { new KeyValuePair<long, long>(471, 614), 262286 },
                { new KeyValuePair<long, long>(523, 142), 262239 },
                { new KeyValuePair<long, long>(517, 384), 262289 },
                { new KeyValuePair<long, long>(530, 407), 262290 },
                { new KeyValuePair<long, long>(529, 297), 262242 },
                { new KeyValuePair<long, long>(508, 304), 262243 },
                { new KeyValuePair<long, long>(507, 476), 262288 },
                { new KeyValuePair<long, long>(535, 488), 262291 },
                { new KeyValuePair<long, long>(531, 502), 262293 },
                { new KeyValuePair<long, long>(508, 498), 262292 },
                { new KeyValuePair<long, long>(-14, -95), 262324 },
                { new KeyValuePair<long, long>(581, -67), 262328 },
                { new KeyValuePair<long, long>(176, -34), 262196 },
                { new KeyValuePair<long, long>(175, 1), 262197 },
                { new KeyValuePair<long, long>(160, -78), 262198 },
                { new KeyValuePair<long, long>(97, -37), 262199 },
                { new KeyValuePair<long, long>(174, -105), 262177 },
                { new KeyValuePair<long, long>(272, -97), 262178 },
                { new KeyValuePair<long, long>(261, -117), 262179 },
                { new KeyValuePair<long, long>(354, -178), 262337 },
                { new KeyValuePair<long, long>(643, -127), 262329 },
                { new KeyValuePair<long, long>(365, -109), 262327 },
                { new KeyValuePair<long, long>(300, -94), 262194 },
                { new KeyValuePair<long, long>(303, -190), 262326 },
                { new KeyValuePair<long, long>(321, -179), 262325 },
                { new KeyValuePair<long, long>(-191, 194), 262200 },
                { new KeyValuePair<long, long>(-29, 148), 262201 },
                { new KeyValuePair<long, long>(64, -109), 262273 },
                { new KeyValuePair<long, long>(60, -155), 262272 },
                { new KeyValuePair<long, long>(93, -92), 262274 },
                { new KeyValuePair<long, long>(151, -117), 262275 },
                { new KeyValuePair<long, long>(187, -163), 262180 },
                { new KeyValuePair<long, long>(356, -207), 262181 },
                { new KeyValuePair<long, long>(333, -61), 262195 },
                { new KeyValuePair<long, long>(-717, -22), 262193 },
                { new KeyValuePair<long, long>(432, -108), 262175 },
                { new KeyValuePair<long, long>(449, -166), 262144 },
                { new KeyValuePair<long, long>(543, -189), 262145 },
                { new KeyValuePair<long, long>(423, -169), 262331 },
                { new KeyValuePair<long, long>(759, -398), 262185 },
                { new KeyValuePair<long, long>(424, -220), 262172 },
                { new KeyValuePair<long, long>(552, -141), 262260 },
                { new KeyValuePair<long, long>(620, -404), 262187 },
                { new KeyValuePair<long, long>(567, -246), 262174 },
                { new KeyValuePair<long, long>(406, -386), 262221 },
                { new KeyValuePair<long, long>(393, -375), 262220 },
                { new KeyValuePair<long, long>(328, -353), 262219 },
                { new KeyValuePair<long, long>(451, -296), 262188 },
                { new KeyValuePair<long, long>(449, -430), 262191 },
                { new KeyValuePair<long, long>(515, -441), 262189 },
                { new KeyValuePair<long, long>(505, -439), 262190 },
                { new KeyValuePair<long, long>(397, -411), 262192 },
                { new KeyValuePair<long, long>(572, -378), 262182 },
                { new KeyValuePair<long, long>(590, -384), 262183 },
                { new KeyValuePair<long, long>(545, -357), 262184 },
                { new KeyValuePair<long, long>(423, -274), 262222 },
                { new KeyValuePair<long, long>(477, -140), 262330 },
                { new KeyValuePair<long, long>(513, -413), 262186 },
                { new KeyValuePair<long, long>(496, -369), 262148 },
                { new KeyValuePair<long, long>(339, -216), 262173 },
                { new KeyValuePair<long, long>(13, 164), 262202 },
                { new KeyValuePair<long, long>(106, 112), 262207 },
                { new KeyValuePair<long, long>(148, 363), 262206 },
                { new KeyValuePair<long, long>(129, 165), 262203 },
                { new KeyValuePair<long, long>(249, 403), 262204 },
                { new KeyValuePair<long, long>(193, 384), 262205 },
                { new KeyValuePair<long, long>(253, 194), 262210 },
                { new KeyValuePair<long, long>(163, 136), 262208 },
                { new KeyValuePair<long, long>(191, 165), 262209 },
                { new KeyValuePair<long, long>(98, 130), 262211 },
                { new KeyValuePair<long, long>(-1009, -35), 262256 },
                { new KeyValuePair<long, long>(-1082, 8), 262257 },
                { new KeyValuePair<long, long>(-678, -29), 262248 },
                { new KeyValuePair<long, long>(-837, -123), 262250 },
                { new KeyValuePair<long, long>(-671, -39), 262251 },
                { new KeyValuePair<long, long>(-1075, 32), 262252 },
                { new KeyValuePair<long, long>(-1043, -7), 262253 },
                { new KeyValuePair<long, long>(-1075, -2), 262247 },
                { new KeyValuePair<long, long>(-911, -34), 262254 },
                { new KeyValuePair<long, long>(-765, -144), 262255 },
                { new KeyValuePair<long, long>(-822, -9), 262249 },
                { new KeyValuePair<long, long>(-796, -144), 262259 },
                { new KeyValuePair<long, long>(-48, -166), 262318 },
                { new KeyValuePair<long, long>(-216, -176), 262276 },
                { new KeyValuePair<long, long>(-165, -140), 262167 },
                { new KeyValuePair<long, long>(-336, -288), 262312 },
                { new KeyValuePair<long, long>(-155, -186), 262166 },
                { new KeyValuePair<long, long>(92, -227), 262150 },
                { new KeyValuePair<long, long>(-247, -207), 262321 },
                { new KeyValuePair<long, long>(-245, -277), 262313 },
                { new KeyValuePair<long, long>(-27, -256), 262315 },
                { new KeyValuePair<long, long>(82, -196), 262163 },
                { new KeyValuePair<long, long>(59, -280), 262162 },
                { new KeyValuePair<long, long>(-80, -189), 262317 },
                { new KeyValuePair<long, long>(-283, -236), 262320 },
                { new KeyValuePair<long, long>(5, -193), 262319 },
                { new KeyValuePair<long, long>(257, -199), 262316 },
                { new KeyValuePair<long, long>(-11, -206), 262165 },
                { new KeyValuePair<long, long>(-217, -183), 262280 },
                { new KeyValuePair<long, long>(-238, -212), 262278 },
                { new KeyValuePair<long, long>(-59, -244), 262277 },
                { new KeyValuePair<long, long>(83, -222), 262164 },
                { new KeyValuePair<long, long>(-182, -193), 262279 },
                { new KeyValuePair<long, long>(-217, -146), 262322 },
                { new KeyValuePair<long, long>(-177, -154), 262323 },
                { new KeyValuePair<long, long>(-184, -227), 262170 },
                { new KeyValuePair<long, long>(-40, -239), 262169 },
                { new KeyValuePair<long, long>(5, -241), 262168 },
                { new KeyValuePair<long, long>(-627, 393), 262224 },
                { new KeyValuePair<long, long>(-510, 204), 262265 },
                { new KeyValuePair<long, long>(-677, 269), 262225 },
                { new KeyValuePair<long, long>(-485, 323), 262269 },
                { new KeyValuePair<long, long>(-596, 229), 262268 },
                { new KeyValuePair<long, long>(-609, 299), 262266 },
                { new KeyValuePair<long, long>(-514, 303), 262267 },
                { new KeyValuePair<long, long>(-503, 274), 262271 },
                { new KeyValuePair<long, long>(-435, 322), 262270 },
                { new KeyValuePair<long, long>(-671, 289), 262223 },
                { new KeyValuePair<long, long>(-608, 329), 262226 },
                { new KeyValuePair<long, long>(-612, 347), 262227 },
                { new KeyValuePair<long, long>(-604, 361), 262228 },
                { new KeyValuePair<long, long>(-613, 371), 262229 },
                { new KeyValuePair<long, long>(-646, 473), 262230 },
                { new KeyValuePair<long, long>(-514, 427), 262296 },
                { new KeyValuePair<long, long>(-592, 445), 262294 },
                { new KeyValuePair<long, long>(-456, 419), 262297 },
                { new KeyValuePair<long, long>(-414, 429), 262295 },
                { new KeyValuePair<long, long>(-545, 409), 262298 },
                { new KeyValuePair<long, long>(-572, 157), 262335 },
                { new KeyValuePair<long, long>(595, -136), 262332 },
                { new KeyValuePair<long, long>(703, -82), 262281 },
                { new KeyValuePair<long, long>(666, -48), 262282 },
                { new KeyValuePair<long, long>(409, -34), 262284 },
                { new KeyValuePair<long, long>(636, -162), 262176 },
                { new KeyValuePair<long, long>(722, -95), 262212 },
                { new KeyValuePair<long, long>(761, -173), 262213 },
                { new KeyValuePair<long, long>(766, -183), 262217 },
                { new KeyValuePair<long, long>(684, -205), 262215 },
                { new KeyValuePair<long, long>(796, -210), 262216 },
                { new KeyValuePair<long, long>(502, -108), 262262 },
                { new KeyValuePair<long, long>(914, -71), 262263 },
                { new KeyValuePair<long, long>(874, -143), 262261 },
                { new KeyValuePair<long, long>(884, -98), 262264 },
                { new KeyValuePair<long, long>(770, -148), 262214 },
                { new KeyValuePair<long, long>(618, -98), 262283 },
                { new KeyValuePair<long, long>(-561, -89), 262304 },
                { new KeyValuePair<long, long>(-292, 20), 262311 },
                { new KeyValuePair<long, long>(-415, -80), 262309 },
                { new KeyValuePair<long, long>(-205, -113), 262299 },
                { new KeyValuePair<long, long>(-320, -162), 262300 },
                { new KeyValuePair<long, long>(-538, -104), 262334 },
                { new KeyValuePair<long, long>(-460, -187), 262303 },
                { new KeyValuePair<long, long>(-514, -277), 262305 },
                { new KeyValuePair<long, long>(-460, -255), 262333 },
                { new KeyValuePair<long, long>(-538, -234), 262306 },
                { new KeyValuePair<long, long>(-456, -17), 262171 },
                { new KeyValuePair<long, long>(-546, 54), 262218 },
                { new KeyValuePair<long, long>(-443, -152), 262246 },
                { new KeyValuePair<long, long>(-350, -98), 262307 },
                { new KeyValuePair<long, long>(-359, -87), 262310 },
                { new KeyValuePair<long, long>(-418, 67), 262308 },
                { new KeyValuePair<long, long>(-168, -102), 262301 },
                { new KeyValuePair<long, long>(-221, -84), 262302 },
                { new KeyValuePair<long, long>(-355, 65), 262336 },
            };

        private static readonly Dictionary<AbilityType, long> AbilityDictionary =
            new Dictionary<AbilityType, long>()
            {
                { AbilityType.Bash, 262356 },
                { AbilityType.ChargeFlame , 262354 },
                { AbilityType.ChargeJump, 262360 },
                { AbilityType.Climb, 262359 },
                { AbilityType.Dash, 262362 },
                { AbilityType.DoubleJump, 262355 },
                { AbilityType.Glide, 262358 },
                { AbilityType.Grenade, 262361 },
                { AbilityType.Stomp, 262357 },
                { AbilityType.WallJump, 262353 },
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
            if(_itemQueue.Count <= 0) return;
            if (State.Ingame && State.SeinCharacter != null)
            {
                long nextItem = _itemQueue.Dequeue();
                ProccessGiveItem(nextItem);
            }
        }
        
        public static JObject GenerateObjectJson(PickupBase pickupBase)
        {
            JObject jObject = new JObject();
            jObject.Add("type", pickupBase.name);
            jObject.Add("id", pickupBase.MoonGuid.GetHashCode());
            jObject.Add("location", pickupBase.Bounds.center.x + " | " + pickupBase.Bounds.center.y + " | " + pickupBase.Bounds.center.z);
            jObject.Add("area", GameWorld.Instance.FindAreaFromPosition(pickupBase.Bounds.center).AreaNameString);
            if(pickupBase.GetType() == (typeof(ExpOrbPickup))) jObject.Add("size", ((ExpOrbPickup)pickupBase).MessageType.ToString());
            return jObject;
        }
        
        public static long GetLocationIdFromLocationVector(Vector3 location)
        {
            long x = (long)location.x;
            long y = (long)location.y;
            KeyValuePair<long, long> key = new KeyValuePair<long, long>(x, y);
            if (LocationDictionary.ContainsKey(key))
            {
                return LocationDictionary[key];
            }
            return -1;
        }

        public static long GetLocationIdFromAbilityTree(AbilityType type)
        {
            if (AbilityDictionary.ContainsKey(type))
            {
                return AbilityDictionary[type];
            }
            return -1;
        }
        
        public static Vector3 GetLocationVectorFromLocationId(int id)
        {
            if (LocationDictionary.ContainsValue(id))
            {
                KeyValuePair<long, long> key = LocationDictionary.FirstOrDefault(x => x.Value == id).Key;
                return new Vector3(key.Key, key.Value, 0);
            }
            return new Vector3(0, 0, 0);
        }
    }
}