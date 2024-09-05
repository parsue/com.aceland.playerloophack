using AceLand.Library.Editor;
using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEditor;

namespace AceLand.PlayerLoopHack.Editor.Drawer
{
    [CustomEditor(typeof(AceLandPlayerLoopSettings))]
    public class PlayerLoopSettingsInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorHelper.DrawAllPropertiesAsDisabled(serializedObject);
        }
    }
}