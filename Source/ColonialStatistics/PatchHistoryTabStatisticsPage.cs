using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;

namespace ColonialStatistics
{
    [UsedImplicitly]
    [HarmonyPatch]
    public class PatchHistoryTabStatisticsPage
    {
        [UsedImplicitly]
        public static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(MainTabWindow_History), "DoStatisticsPage");
        }

        [UsedImplicitly]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> PrintMoreStatistics(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions)
                // the moment when the game is about to emit the label to the UI
                .MatchStartForward(new CodeMatch(OpCodes.Ldc_I4_1))
                .InsertAndAdvance(
                    new CodeInstruction(OpCodes.Ldloc_0),
                    CodeInstruction.Call(typeof(StatisticsPrinter), nameof(StatisticsPrinter.PrintStatistics))
                    )
                .InstructionEnumeration();
        }
    }
}
