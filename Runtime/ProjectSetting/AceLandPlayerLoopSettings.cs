using AceLand.Library.Attribute;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.PlayerLoopHack.ProjectSetting
{
    public class AceLandPlayerLoopSettings : ProjectSettings<AceLandPlayerLoopSettings>
    {
        [Header("Logging")]
        public bool enableLogging;
        [ConditionalShow("enableLogging")] public bool loggingOnEditor;
        [ConditionalShow("enableLogging")] public bool loggingOnBuild;
        
        public bool PrintLogging()
        {
            if (!enableLogging) return false;
#if UNITY_EDITOR
            return loggingOnEditor;
#else
            return loggingOnBuild;
#endif
        }
    }
}