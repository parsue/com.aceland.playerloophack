using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEditor;

namespace AceLand.PlayerLoopHack.Editor.ProjectSettingsProvider
{
    [InitializeOnLoad]
    public static class PackageInitializer
    {
        static PackageInitializer()
        {
            AceLandPlayerLoopSettings.GetSerializedSettings();
        }
    }
}