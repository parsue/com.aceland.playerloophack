using AceLand.Library.Editor.Providers;
using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.PlayerLoopHack.Editor.ProjectSettingsProvider
{
    public class PlayerLoopSettingsProvider : AceLandSettingsProvider
    {
        public const string SETTINGS_NAME = "Project/AceLand Packages/Player Loop Hack";
        
        [InitializeOnLoadMethod]
        public static void CreateSettings() => AceLandPlayerLoopSettings.GetSerializedSettings();
        
        private PlayerLoopSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Settings = AceLandPlayerLoopSettings.GetSerializedSettings();
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new PlayerLoopSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            return provider;
        }
    }
}