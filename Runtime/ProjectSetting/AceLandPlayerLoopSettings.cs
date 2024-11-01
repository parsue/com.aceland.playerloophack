using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.PlayerLoopHack.ProjectSetting
{
    public class AceLandPlayerLoopSettings : ProjectSettings<AceLandPlayerLoopSettings>
    {
        [Header("Logging")]
        [SerializeField] private BuildLevel loggingLevel = BuildLevel.DevelopmentBuild;
        
        public bool PrintLogging()
        {
            return loggingLevel.IsAcceptedLevel();
        }
    }
}