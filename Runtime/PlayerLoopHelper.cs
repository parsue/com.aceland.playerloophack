using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEngine;

namespace AceLand.PlayerLoopHack
{
    public static class PlayerLoopHelper
    {
        public static AceLandPlayerLoopSettings Settings
        {
            get => Application.isPlaying
                ? _settings
                : Resources.Load<AceLandPlayerLoopSettings>(nameof(AceLandPlayerLoopSettings));
            internal set => _settings = value;
        }

        private static AceLandPlayerLoopSettings _settings;
    }
}