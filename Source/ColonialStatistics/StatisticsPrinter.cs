using System.Text;
using RimWorld;
using Verse;

namespace ColonialStatistics
{
    public class StatisticsPrinter
    {
        /// <summary>
        /// Given the StringBuilder instance that contains statistics texts, prints more colony statistics.
        /// </summary>
        /// <param name="builder"></param>
        public static void PrintStatistics(StringBuilder builder)
        {
            // make a paragraph break from vanilla statistics
            builder.AppendLine();

            // mod custom printing follows
            builder.AppendLine("Mod active: Colonial Statistics");
            builder.AppendLine();
            var theMap = Find.CurrentMap;
            if (theMap != null)
            {
                builder.AppendLine("Map statistics:");

                // count colonists etc
                var colonistCount = theMap.mapPawns.FreeColonistsCount;
                builder.AppendLine("Colonists: " + theMap.mapPawns.FreeColonistsCount);
                builder.AppendLine("Prisoners: " + theMap.mapPawns.PrisonersOfColonyCount);

                // count wealth per pawn
                var totalWealth = theMap.wealthWatcher.HealthTotal;
                var wealthPerGuy = totalWealth / colonistCount;
                builder.AppendLine("Wealth per capita: " + wealthPerGuy);
            }
            else
            {
                builder.AppendLine("(Not in map!)");
            }
        }
    }
}
