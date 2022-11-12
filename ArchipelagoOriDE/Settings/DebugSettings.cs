using UnityModManagerNet;

namespace OriForestArchipelago.Settings
{
    [DrawFields(DrawFieldMask.Any)]
    public class DebugSettings
    {
        public bool EnableDebug = false;
        public KeyBinding DebugKeybind = new KeyBinding();
        public DebugKeyAction DebugKeyAction = DebugKeyAction.None;
    }
}