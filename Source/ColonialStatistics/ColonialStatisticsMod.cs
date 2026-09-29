using HarmonyLib;
using JetBrains.Annotations;
using Verse;

namespace ColonialStatistics
{
    [UsedImplicitly]
    public class ColonialStatisticsMod : Mod
    {
        [UsedImplicitly]
        public static string ModShortId => "V1024-COST";

        public ColonialStatisticsMod(ModContentPack content) : base(content)
        {
            LogInfo("Colonial Statistics, starting up. Hopefully the patches work.");
            var harmony = new Harmony("rimworld." + content.PackageId);
            harmony.PatchAll();
        }

        /// <summary>
        /// Already includes a space character.
        /// </summary>
        private static string ModPrefix => "[" + ModShortId + "]";

        public static void LogError(string message)
        {
            Log.Error(ModPrefix + " " + message);
        }

        public static void LogWarning(string message)
        {
            Log.Warning(ModPrefix + " " + message);
        }

        internal static void LogInfo(string message)
        {
            Log.Message(ModPrefix + " " + message);
        }
    }
}
