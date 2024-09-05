using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEngine;
using UnityEngine.LowLevel;

namespace AceLand.PlayerLoopHack
{
    internal static class PlayerLoopBootstrapper
    {
        private static PlayerLoopSystem _fakeLoop;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        internal static void Initialize()
        {
            PlayerLoopHelper.Settings = Resources.Load<AceLandPlayerLoopSettings>(nameof(AceLandPlayerLoopSettings));
            
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopUtils.PrintPlayerLoop((currentPlayerLoop));
        }
    }
}