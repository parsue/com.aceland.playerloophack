using System.Collections.Generic;
using System.Text;
using AceLand.Library.Extensions;
using AceLand.PlayerLoopHack.ProjectSetting;
using UnityEngine;
using UnityEngine.LowLevel;

namespace AceLand.PlayerLoopHack.Core
{
    internal static class PlayerLoopUtils
    {
        public static AceLandPlayerLoopSettings Settings
        {
            get => _settings ?? Resources.Load<AceLandPlayerLoopSettings>(nameof(AceLandPlayerLoopSettings));
            internal set => _settings = value;
        }
        
        private static AceLandPlayerLoopSettings _settings;
        private static bool PrintLogging() => Settings.PrintLogging();
        
        public static void PrintPlayerLoop()
        {
            if (!PrintLogging()) return;

            var loop = PlayerLoop.GetCurrentPlayerLoop();
            var sb = new StringBuilder();
            sb.AppendLine("Unity Player Loop");
            foreach (var subSystem in loop.subSystemList)
            {
                PrintSubsystem(subSystem, sb, 0);
            }
            Debug.Log(sb.ToString());
        }
        
        public static void PrintPlayerLoop(PlayerLoopSystem loop)
        {
            if (!PrintLogging()) return;
            
            var sb = new StringBuilder();
            sb.AppendLine("Unity Player Loop");
            foreach (var subSystem in loop.subSystemList)
            {
                PrintSubsystem(subSystem, sb, 0);
            }
            Debug.Log(sb.ToString());
        }

        public static PlayerLoopSystem CreatePlayerLoopSystem<T>(T system) 
            where T : IPlayerLoopSystem
        {
            var loop = new PlayerLoopSystem()
            {
                type = typeof(T),
                updateDelegate = system.SystemUpdate,
                subSystemList = null,
            };

            return loop;
        }

        public static bool InsertSystem<T>(in PlayerLoopSystem systemToInsert, int index)
            where T : unmanaged
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            var systemName = systemToInsert.updateDelegate.GetOwnerName();
            if (InsertSystemHandle<T>(ref currentPlayerLoop, in systemToInsert, index))
            {
                PlayerLoop.SetPlayerLoop(currentPlayerLoop);
                if (!PrintLogging()) return true;
                Debug.Log($"Insert System: {systemName} ({typeof(T).Name})");
                PrintPlayerLoop();
                return true;
            }
            
            if (!PrintLogging()) return false;
            Debug.LogWarning($"Insert System Fail: {systemName} ({typeof(T).Name})");
            return false;
        }

        public static void RemoveSystem<T>(in PlayerLoopSystem systemToRemove)
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            var systemName = systemToRemove.updateDelegate.GetOwnerName();
            RemoveSystemHandle<T>(ref currentPlayerLoop, in systemToRemove);
            PlayerLoop.SetPlayerLoop(currentPlayerLoop);
            if (!PrintLogging()) return;
            
            Debug.Log($"Remove System: {systemName} ({typeof(T).Name})");
            PrintPlayerLoop();
        }
        
        private static void PrintSubsystem(PlayerLoopSystem system, StringBuilder sb, int level)
        {
            sb.Append(' ', level * 2).AppendLine(system.type.ToString());
            if (system.subSystemList == null || system.subSystemList.Length == 0) return;

            foreach (var subSystem in system.subSystemList)
            {
                PrintSubsystem(subSystem, sb, level + 1);
            }
        }

        private static bool InsertSystemHandle<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToInsert, int index)
            where T : unmanaged
        {
            if (loop.type != typeof(T)) return HandleSubSystemLoop<T>(ref loop, systemToInsert, index);
            var playerLoopSystemList = new List<PlayerLoopSystem>();
            if (loop.subSystemList != null) playerLoopSystemList.AddRange((loop.subSystemList));
            if (index < 0) playerLoopSystemList.Add(systemToInsert);
            else playerLoopSystemList.Insert(index, systemToInsert);
            loop.subSystemList = playerLoopSystemList.ToArray();
            return true;
        }

        private static bool HandleSubSystemLoop<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToInsert, int index) 
            where T : unmanaged
        {
            if (loop.subSystemList == null) return false;

            for (var i = 0; i < loop.subSystemList.Length; i++)
            {
                if (!InsertSystemHandle<T>(ref loop.subSystemList[i], in systemToInsert, index)) continue;
                return true;
            }

            return false;
        }

        private static void RemoveSystemHandle<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToRemove)
        {
            if (loop.subSystemList == null) return;

            var playerLoopSystemList = new List<PlayerLoopSystem>(loop.subSystemList);
            for (var i = 0; i < playerLoopSystemList.Count; i++)
            {
                if (playerLoopSystemList[i].type != systemToRemove.type ||
                    playerLoopSystemList[i].updateDelegate != systemToRemove.updateDelegate) continue;
                
                playerLoopSystemList.RemoveAt(i);
                loop.subSystemList = playerLoopSystemList.ToArray();
            }

            HandleSubsystemLoopForRemoval<T>(ref loop, systemToRemove);
        }

        private static void HandleSubsystemLoopForRemoval<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToRemove)
        {
            if (loop.subSystemList == null) return;

            for (var i = 0; i < loop.subSystemList.Length; i++)
            {
                RemoveSystemHandle<T>(ref loop.subSystemList[i], systemToRemove);
            }
        }
    }
}