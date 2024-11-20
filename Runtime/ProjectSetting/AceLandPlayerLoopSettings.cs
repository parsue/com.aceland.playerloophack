using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.PlayerLoopHack.ProjectSetting
{
    public class AceLandPlayerLoopSettings : ProjectSettings<AceLandPlayerLoopSettings>
    {
        [Header("Logging")]
        [SerializeField] private BuildLevel loggingLevel = BuildLevel.Development;

        [SerializeField] private BuildLevel systemLoggingLevel = BuildLevel.Development;
        
        public bool PrintLogging => loggingLevel.IsAcceptedLevel();
        public bool SystemLogging => systemLoggingLevel.IsAcceptedLevel();
    }
}