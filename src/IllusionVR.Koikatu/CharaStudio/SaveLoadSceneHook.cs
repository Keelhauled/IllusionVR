﻿using HarmonyLib;
using IllusionVR.Core;
using System;
using System.Reflection;
using UnityEngine;
using VRGIN.Core;

namespace IllusionVR.Koikatu.CharaStudio
{
    public static class SaveLoadSceneHook
    {
        private static Camera[] backupRenderCam;

        public static void InstallHook()
        {
            Harmony.CreateAndPatchAll(typeof(SaveLoadSceneHook));
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Studio.Studio), "SaveScene", new Type[] { })]
        public static bool SaveScenePreHook(Studio.Studio __instance, ref Camera[] __state)
        {
            IVRLog.LogDebug("Update Camera position and rotation for Scene Capture and last Camera data.");
            VRCameraMoveHelper.Instance.CurrentToCameraCtrl();
            FieldInfo field = typeof(Studio.GameScreenShot).GetField("renderCam", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Camera[] array = field.GetValue(Singleton<Studio.Studio>.Instance.gameScreenShot) as Camera[];
            IVRLog.LogDebug("Backup Screenshot render cam.");
            backupRenderCam = array;
            Camera[] value = new Camera[] { VR.Camera.SteamCam.camera };
            __state = backupRenderCam;
            field.SetValue(Singleton<Studio.Studio>.Instance.gameScreenShot, value);
            return true;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Studio.Studio), "SaveScene", new Type[] { }, null)]
        public static void SaveScenePostHook(Studio.Studio __instance, Camera[] __state)
        {
            IVRLog.LogDebug("Restore backup render cam.");
            typeof(Studio.GameScreenShot).GetField("renderCam", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SetValue(Singleton<Studio.Studio>.Instance.gameScreenShot, __state);
        }
    }
}
