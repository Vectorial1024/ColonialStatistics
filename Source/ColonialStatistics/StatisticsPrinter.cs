using System.Text;

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
            builder.AppendLine("Hello World");
        }
    }
}
