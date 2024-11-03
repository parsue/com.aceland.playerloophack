using AceLand.PlayerLoopHack.Core;
using UnityEngine;
using UnityEngine.LowLevel;

namespace AceLand.PlayerLoopHack
{
    internal static class PlayerLoopBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        internal static void Initialize()
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopUtils.PrintPlayerLoopSystem(currentPlayerLoop);
        }
    }
}