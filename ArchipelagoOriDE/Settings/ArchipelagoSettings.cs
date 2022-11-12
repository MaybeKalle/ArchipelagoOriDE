using UnityEngine;
using UnityModManagerNet;

namespace OriForestArchipelago.Settings
{
    [DrawFields(DrawFieldMask.Public)]
    public class ArchipelagoSettings
    {
        public int Slot = 1;
        public ArchipelagoSlotSettings[] ArchipelagoSlots = new ArchipelagoSlotSettings[]
        {
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings(),
            new ArchipelagoSlotSettings()
        };
    }
}