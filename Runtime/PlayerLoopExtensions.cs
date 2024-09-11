using System;
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

        public static bool InsertSystem<T>(in this PlayerLoopSystem system, int index = -1)
            where T : unmanaged
        {
            return PlayerLoopUtils.InsertSystem<T>(in system, index);
        }

        public static void RemoveSystem<T>(this PlayerLoopSystem system)
            where T : unmanaged
        {
            PlayerLoopUtils.RemoveSystem<T>(system);
        }

        public static bool InsertSystem(in this PlayerLoopSystem system, PlayerLoopType type, int index = -1)
        {
            return type switch
            {
                PlayerLoopType.TimeUpdate => PlayerLoopUtils.InsertSystem<TimeUpdate>(in system, index),
                PlayerLoopType.Initialization => PlayerLoopUtils.InsertSystem<Initialization>(in system, index),
                PlayerLoopType.EarlyUpdate => PlayerLoopUtils.InsertSystem<EarlyUpdate>(in system, index),
                PlayerLoopType.FixedUpdate => PlayerLoopUtils.InsertSystem<FixedUpdate>(in system, index),
                PlayerLoopType.PreUpdate => PlayerLoopUtils.InsertSystem<PreUpdate>(in system, index),
                PlayerLoopType.Update => PlayerLoopUtils.InsertSystem<Update>(in system, index),
                PlayerLoopType.PreLateUpdate => PlayerLoopUtils.InsertSystem<PreLateUpdate>(in system, index),
                PlayerLoopType.PostLateUpdate => PlayerLoopUtils.InsertSystem<PostLateUpdate>(in system, index),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static void RemoveSystem(this PlayerLoopSystem system, PlayerLoopType type)
        {
            switch (type)
            {
                case PlayerLoopType.TimeUpdate:
                    PlayerLoopUtils.RemoveSystem<TimeUpdate>(system);
                    break;
                case PlayerLoopType.Initialization:
                    PlayerLoopUtils.RemoveSystem<Initialization>(system);
                    break;
                case PlayerLoopType.EarlyUpdate:
                    PlayerLoopUtils.RemoveSystem<EarlyUpdate>(system);
                    break;
                case PlayerLoopType.FixedUpdate:
                    PlayerLoopUtils.RemoveSystem<FixedUpdate>(system);
                    break;
                case PlayerLoopType.PreUpdate:
                    PlayerLoopUtils.RemoveSystem<PreUpdate>(system);
                    break;
                case PlayerLoopType.Update:
                    PlayerLoopUtils.RemoveSystem<Update>(system);
                    break;
                case PlayerLoopType.PreLateUpdate:
                    PlayerLoopUtils.RemoveSystem<PreLateUpdate>(system);
                    break;
                case PlayerLoopType.PostLateUpdate:
                    PlayerLoopUtils.RemoveSystem<PostLateUpdate>(system);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}