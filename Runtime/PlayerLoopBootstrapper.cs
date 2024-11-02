using AceLand.PlayerLoopHack.Core;
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
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopUtils.PrintPlayerLoopSystem(currentPlayerLoop);
        }
    }
}