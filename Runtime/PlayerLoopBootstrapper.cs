using AceLand.PlayerLoopHack.Core;
using UnityEngine;

namespace AceLand.PlayerLoopHack
{
    internal static class PlayerLoopBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        internal static void Initialize()
        {
            if (PlayerLoopUtils.Settings.SystemLogging)
                PlayerLoopUtils.PrintPlayerLoopSystem();
        }
    }
}