using System;
using System.Reflection;
using BepInEx;
using Epic.OnlineServices.AntiCheatClient;
using HarmonyLib;
using Landfall;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TacticalToolkit
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            bool isMainMenu = scene.buildIndex == 0;
            if (isMainMenu)
            {
                /*GameObject x = GameObject.Find("/MainMenuCamPivot/MainMenuCam/Logos/LogoParent/Logo");
                bool flag2 = x != null;
                if (flag2)
                {
                    foreach (MelonMod melonMod in MelonTypeBase<MelonMod>.RegisteredMelons)
                    {
                    }
                }*/
                TacticalToolkitUI.FixOptionsTabs();
                TacticalToolkitUI.AddLowerUISpace(15);
                TacticalToolkitUI.AddLowerUIButton("TACTICAL TOOLS (TEMP BUTTON)", 16);
            }
        }
    }
}
