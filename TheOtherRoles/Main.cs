global using Il2CppInterop.Runtime.Attributes;
global using Il2CppInterop.Runtime.InteropTypes.Arrays;

using BepInEx;
using BepInEx.Unity.IL2CPP;
using System;
using Reactor.Networking.Attributes;
using HarmonyLib;
using UnityEngine;
using CustomCosmeticsAU.Modules.CustomHats;

namespace CustomCosmeticsAU
{
    [BepInPlugin(Id, "Custom Cosmetics AU", VersionString)]
    [BepInProcess("Among Us.exe")]
    [ReactorModFlags(Reactor.Networking.ModFlags.RequireOnAllClients)]

    public class TheOtherRolesPlugin : BasePlugin
    {
        public const string Id = "me.emalix.customcosmeticsau";
        public const string VersionString = "1.0.0";

        public static Version Version = Version.Parse(VersionString);
        internal static BepInEx.Logging.ManualLogSource Logger;

        public Harmony Harmony { get; } = new Harmony(Id);
        public static TheOtherRolesPlugin Instance;

        public static Sprite ModStamp;

        public override void Load()
        {
            Logger = Log;
            Instance = this;
            Harmony.PatchAll();
            CustomHatManager.LoadHats();
            Logger.LogInfo("Successfully loaded CustomCosmeticsAU.");
        }
    }
}
