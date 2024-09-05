using AceLand.Library.Editor;
using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.PlayerLoopHack.Editor.ProjectSettingsProvider
{
    public class PlayerLoopSettingsProvider : SettingsProvider
    {
        public const string SETTINGS_NAME = "Project/AceLand Player Loop Hack";
        private SerializedObject _settings;
        
        private PlayerLoopSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _settings = AceLandPlayerLoopSettings.GetSerializedSettings();
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new PlayerLoopSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            return provider;
        }

        public override void OnGUI(string searchContext)
        {
            EditorHelper.DrawAllProperties(_settings);
        }
    }
}