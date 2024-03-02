using CsvHelper;
using Engineering_Diploma_Project_Csharp.Models;
using System.Globalization;

namespace Engineering_Diploma_Project_Csharp
{
    public class CSVReaderHelper
    {
        public IEnumerable<MatchCSV> Matches { get; set; } 
        public List<List<MatchCSV>> MachesDividedInSeasons { get; set; }

        public CSVReaderHelper() 
        {
            Matches = ReadMatches();
            var matches = Matches;
            MachesDividedInSeasons = DivideMatchesInSeasons(matches);

        }

        private static IEnumerable<MatchCSV> ReadMatches()
        {
            using var reader = new StreamReader("../../../03_23_matches_stats.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var matchesCSV = csv.GetRecords<MatchCSV>();

            return matchesCSV.ToList();
        }

        private static List<List<MatchCSV>> DivideMatchesInSeasons(IEnumerable<MatchCSV> matches)
        {
            List<MatchCSV> matches_03_04_CSV = matches.Take(380).ToList();
            List<MatchCSV> matches_04_05_CSV = matches.Skip(380).Take(380).ToList();
            List<MatchCSV> matches_05_06_CSV = matches.Skip(380 * 2).Take(380).ToList();
            List<MatchCSV> matches_06_07_CSV = matches.Skip(380 * 3).Take(380).ToList();
            List<MatchCSV> matches_07_08_CSV = matches.Skip(380 * 4).Take(380).ToList();
            List<MatchCSV> matches_08_09_CSV = matches.Skip(380 * 5).Take(380).ToList();
            List<MatchCSV> matches_09_10_CSV = matches.Skip(380 * 6).Take(380).ToList();
            List<MatchCSV> matches_10_11_CSV = matches.Skip(380 * 7).Take(380).ToList();
            List<MatchCSV> matches_11_12_CSV = matches.Skip(380 * 8).Take(380).ToList();
            List<MatchCSV> matches_12_13_CSV = matches.Skip(380 * 9).Take(380).ToList();
            List<MatchCSV> matches_13_14_CSV = matches.Skip(380 * 10).Take(380).ToList();
            List<MatchCSV> matches_14_15_CSV = matches.Skip(380 * 11).Take(380).ToList();
            List<MatchCSV> matches_15_16_CSV = matches.Skip(380 * 12).Take(380).ToList();
            List<MatchCSV> matches_16_17_CSV = matches.Skip(380 * 13).Take(380).ToList();
            List<MatchCSV> matches_17_18_CSV = matches.Skip(380 * 14).Take(380).ToList();
            List<MatchCSV> matches_18_19_CSV = matches.Skip(380 * 15).Take(380).ToList();
            List<MatchCSV> matches_19_20_CSV = matches.Skip(380 * 16).Take(380).ToList();
            List<MatchCSV> matches_20_21_CSV = matches.Skip(380 * 17).Take(380).ToList();
            List<MatchCSV> matches_21_22_CSV = matches.Skip(380 * 18).Take(380).ToList();
            List<MatchCSV> matches_22_23_CSV = matches.Skip(380 * 19).Take(380).ToList();

            List<List<MatchCSV>> matchesDividedInSeasons = new()
            {
                matches_03_04_CSV,
                matches_04_05_CSV,
                matches_05_06_CSV,
                matches_06_07_CSV,
                matches_07_08_CSV,
                matches_08_09_CSV,
                matches_09_10_CSV,
                matches_10_11_CSV,
                matches_11_12_CSV,
                matches_12_13_CSV,
                matches_13_14_CSV,
                matches_14_15_CSV,
                matches_15_16_CSV,
                matches_16_17_CSV,
                matches_17_18_CSV,
                matches_18_19_CSV,
                matches_19_20_CSV,
                matches_20_21_CSV,
                matches_21_22_CSV,
                matches_22_23_CSV
            };

            return matchesDividedInSeasons;
        }


        public List<List<MatchCSV>> GetSeasonsWithCurrentSeason(DateOnly date)
        {
            var matches = MachesDividedInSeasons;

            var seasonsBeforeMatch = new List<List<MatchCSV>>();

            if (date > new DateOnly(2003, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[0]);
            }
            if (date > new DateOnly(2004, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[1]);
            }
            if (date > new DateOnly(2005, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[2]);
            }
            if (date > new DateOnly(2006, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[3]);
            }
            if (date > new DateOnly(2007, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[4]);
            }
            if (date > new DateOnly(2008, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[5]);
            }
            if (date > new DateOnly(2009, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[6]);
            }
            if (date > new DateOnly(2010, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[7]);
            }
            if (date > new DateOnly(2011, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[8]);
            }
            if (date > new DateOnly(2012, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[9]);
            }
            if (date > new DateOnly(2013, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[10]);
            }
            if (date > new DateOnly(2014, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[11]);
            }
            if (date > new DateOnly(2015, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[12]);
            }
            if (date > new DateOnly(2016, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[13]);
            }
            if (date > new DateOnly(2017, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[14]);
            }
            if (date > new DateOnly(2018, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[15]);
            }
            if (date > new DateOnly(2019, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[16]);
            }
            if (date > new DateOnly(2020, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[17]);
            }
            if (date > new DateOnly(2021, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[18]);
            }
            if (date > new DateOnly(2022, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[19]);
            }

            return seasonsBeforeMatch;
        }

        public IEnumerable<MatchCSV> GetAllMatchesBeforeMatch(DateOnly date)
        {
            var matches = Matches;
            var matchesBefore = matches.Where(m => m.Date < date);
            return matchesBefore;
        }

        public IEnumerable<MatchCSV> GetCurrentSeasonAllMatches(DateOnly date)
        {
            return GetSeasonsWithCurrentSeason(date).Last();
        }

        public IEnumerable<MatchCSV> GetCurrentSeasonAllMatchesBeforeMatch(DateOnly date)
        {
            var season = GetSeasonsWithCurrentSeason(date).Last();
            var matches = season.Where(m => m.Date < date);
            return matches;
        }

    }
}
