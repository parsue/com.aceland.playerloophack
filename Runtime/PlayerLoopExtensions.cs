using System;
using AceLand.PlayerLoopHack.Core;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace AceLand.PlayerLoopHack
{
    public static class PlayerLoopExtensions
    {
        public static PlayerLoopSystem CreatePlayerLoopSystem<T>(this T system)
            where T : IPlayerLoopSystem
        {
            return PlayerLoopUtils.CreatePlayerLoopSystem(system);
        }

        public static bool InjectSystem(in this PlayerLoopSystem system, PlayerLoopState state, int index = -1)
        {
            return state switch
            {
                PlayerLoopState.TimeUpdate => PlayerLoopUtils.InjectSystem<TimeUpdate>(in system, index),
                PlayerLoopState.Initialization => PlayerLoopUtils.InjectSystem<Initialization>(in system, index),
                PlayerLoopState.EarlyUpdate => PlayerLoopUtils.InjectSystem<EarlyUpdate>(in system, index),
                PlayerLoopState.FixedUpdate => PlayerLoopUtils.InjectSystem<FixedUpdate>(in system, index),
                PlayerLoopState.PreUpdate => PlayerLoopUtils.InjectSystem<PreUpdate>(in system, index),
                PlayerLoopState.Update => PlayerLoopUtils.InjectSystem<Update>(in system, index),
                PlayerLoopState.PreLateUpdate => PlayerLoopUtils.InjectSystem<PreLateUpdate>(in system, index),
                PlayerLoopState.PostLateUpdate => PlayerLoopUtils.InjectSystem<PostLateUpdate>(in system, index),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        public static void RemoveSystem(this PlayerLoopSystem system, PlayerLoopState state)
        {
            switch (state)
            {
                case PlayerLoopState.TimeUpdate:
                    PlayerLoopUtils.RemoveSystem<TimeUpdate>(system);
                    break;
                case PlayerLoopState.Initialization:
                    PlayerLoopUtils.RemoveSystem<Initialization>(system);
                    break;
                case PlayerLoopState.EarlyUpdate:
                    PlayerLoopUtils.RemoveSystem<EarlyUpdate>(system);
                    break;
                case PlayerLoopState.FixedUpdate:
                    PlayerLoopUtils.RemoveSystem<FixedUpdate>(system);
                    break;
                case PlayerLoopState.PreUpdate:
                    PlayerLoopUtils.RemoveSystem<PreUpdate>(system);
                    break;
                case PlayerLoopState.Update:
                    PlayerLoopUtils.RemoveSystem<Update>(system);
                    break;
                case PlayerLoopState.PreLateUpdate:
                    PlayerLoopUtils.RemoveSystem<PreLateUpdate>(system);
                    break;
                case PlayerLoopState.PostLateUpdate:
                    PlayerLoopUtils.RemoveSystem<PostLateUpdate>(system);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}