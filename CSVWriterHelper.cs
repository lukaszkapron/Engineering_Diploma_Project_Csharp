using CsvHelper;
using Engineering_Diploma_Project_Csharp.Models;
using System.Globalization;

namespace Engineering_Diploma_Project_Csharp
{
    public class CSVWriterHelper
    {
        public CSVWriterHelper() { }

        public void WriteMatchesStats(IEnumerable<MatchStatsCSV> matchStats, string fileName)
        {
            using var writer = new StreamWriter(fileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<MatchStatsCSV>();
            csv.NextRecord();
            foreach (var match in matchStats)
            {
                csv.WriteRecord(match);
                csv.NextRecord();
             }
        }
    }
}
