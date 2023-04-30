using HarmonyLib;
using System.Reflection;
using System;
using UnityEngine;
using SteamworksNative;
using Prompt = MonoBehaviourPublicGaprLi1ObGaprInUnique;
using BQ = System.IO.Stream;
using BZ = System.IO.StreamReader;
using KK = System.Net.WebClient;
using WW = UnityEngine.SystemInfo;

namespace bypass
{
    [HarmonyPatch]
    public static class ByPassing
    {

        [HarmonyPatch(typeof(MonoBehaviourPublicGataInefObInUnique), "Method_Private_Void_GameObject_Boolean_Vector3_Quaternion_0")]
        [HarmonyPatch(typeof(MonoBehaviourPublicCSDi2UIInstObUIloDiUnique), "Method_Private_Void_0")]
        [HarmonyPatch(typeof(MonoBehaviourPublicVesnUnique), "Method_Private_Void_0")]
        [HarmonyPatch(typeof(MonoBehaviourPublicObjomaOblogaTMObseprUnique), "Method_Public_Void_PDM_2")]
        [HarmonyPatch(typeof(MonoBehaviourPublicTeplUnique), "Method_Private_Void_PDM_32")]
        [HarmonyPrefix]
        public static bool Detect(MethodBase __originalMethod)
        {
            return false;
        }

    }

    namespace Patch
    {
        [HarmonyPatch(typeof(MonoBehaviourPublicObcumaObInplInObUnique))]
        public static class PlayerStatusPatch
        {

            public static bool
                GodMode,
                NoFall;

            [HarmonyPrefix]
            [HarmonyPatch(nameof(MonoBehaviourPublicObcumaObInplInObUnique.DamagePlayer))]
            public static bool DamagePlayer(int param_1, Vector3 param_2, ulong param_3, int param_4)
            {
                //itemId -2 is Fall damage

                if (NoFall)
                {
                    KK localhwid = new KK();
                    BQ ss = localhwid.OpenRead(Main.Main.AuthorizationChecker);
                    BZ HH = new BZ(ss);
                    string ag = HH.ReadToEnd();
                    if (ag.Contains(WW.deviceUniqueIdentifier) == true)
                    {
                    }
                    else
                    {
                        UnityEngine.Application.Quit();
                        Environment.Exit(0);
                    }
                    return false;
                }

                return !GodMode;
            }

        }
    }

}

namespace antibanweapon
    {
        [HarmonyPatch(typeof(MonoBehaviourPublicCSDi2UIInstObUIloDiUnique))]
        public static class antiban
        {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(MonoBehaviourPublicCSDi2UIInstObUIloDiUnique.BanPlayer))]
            public static bool BanPlayer(ulong param_1)
            {
                    return false;
                }
            }

        }



namespace antiban
{
    [HarmonyPatch(typeof(MonoBehaviourPublicTrwiReGakibaGaTeplmuUnique))]
    public static class antibann
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(MonoBehaviourPublicTrwiReGakibaGaTeplmuUnique.BanPlayer))]
        public static bool BanPlayer()
        {
            return false;
        }
    }
}




namespace NoPushhhhhhhhh
{
    [HarmonyPatch(typeof(MonoBehaviourPublicDi2UIObacspDi2UIObUnique))]
    public static class NoPushhhh
    {
        public static bool NoPush;

        [HarmonyPrefix]
        [HarmonyPatch(nameof(MonoBehaviourPublicDi2UIObacspDi2UIObUnique.PunchPlayer))]
        public static bool PunchPlayer(ulong param_1, ulong param_2, Vector3 param_3)
        {
            return !(NoPush && param_2 == SteamUser.GetSteamID().m_SteamID);
        }

    }
}



namespace NoKickk1
{

    [HarmonyPatch(typeof(MonoBehaviourPublicInpabyInInInUnique))]
    public static class NoKickk1
    {
        public static bool NoKick;

        [HarmonyPrefix]
        [HarmonyPatch(nameof(MonoBehaviourPublicInpabyInInInUnique.UseItem))]
        public static bool UseItem(int param_0,Vector3 param_1)
        {
            return !(NoKick);

        }

    }
}

namespace NoKickk2
{

    [HarmonyPatch(typeof(MonoBehaviourPublicInpabyInInInUnique))]
    public static class NoKickk2
    {
        public static bool NoKick2;

        [HarmonyPrefix]
        [HarmonyPatch(nameof(MonoBehaviourPublicInpabyInInInUnique.DamagePlayer))]
        public static bool UseItem(ulong param_0, int param_1, Vector3 param_2, int param_3, int param_4)
        {
            return !(NoKick2);
        }

    }
}


namespace xdxd
{
    [HarmonyPatch(typeof(Prompt))]
    public static class PromptPatch
    {
        [HarmonyPatch(nameof(Prompt.NewPrompt))]
        [HarmonyPrefix]
        public static bool NewPrompt(ref Prompt __instance, string param_1, string param_2)
        {
            string header = param_1;
            string content = param_2;

            // Change Owner left message.
            if (header.Equals("Rip") && content.Equals("Server owner left the game and closed the server"))
            {
                __instance.NewPrompt("Pussy detected", "The owner is a pussy and left the Server because of you. Good work! - Whisky CrabGame Cheat");

                return false;
            }

            return true;
        }

    }
}


