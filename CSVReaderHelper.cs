using CsvHelper;
using Engineering_Diploma_Project_Csharp.Models;
using System.Globalization;

namespace Engineering_Diploma_Project_Csharp
{
    public class CSVReaderHelper
    {
        public IEnumerable<MatchCSV> Matches { get; set; }

        public CSVReaderHelper() 
        {
            Matches = ReadMatches();
        }

        private static IEnumerable<MatchCSV> ReadMatches()
        {
            using var reader = new StreamReader("../../../13_23_matches_stats.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var matchesCSV = csv.GetRecords<MatchCSV>();

            return matchesCSV.ToList();
        }

        public List<List<MatchCSV>> DivideMatchesInSeasons()
        {
            var matches = Matches;

            List<MatchCSV> matches_13_14_CSV = matches.Take(380).ToList();
            List<MatchCSV> matches_14_15_CSV = matches.Skip(380).Take(380).ToList();
            List<MatchCSV> matches_15_16_CSV = matches.Skip(380 * 2).Take(380).ToList();
            List<MatchCSV> matches_16_17_CSV = matches.Skip(380 * 3).Take(380).ToList();
            List<MatchCSV> matches_17_18_CSV = matches.Skip(380 * 4).Take(380).ToList();
            List<MatchCSV> matches_18_19_CSV = matches.Skip(380 * 5).Take(380).ToList();
            List<MatchCSV> matches_19_20_CSV = matches.Skip(380 * 6).Take(380).ToList();
            List<MatchCSV> matches_20_21_CSV = matches.Skip(380 * 7).Take(380).ToList();
            List<MatchCSV> matches_21_22_CSV = matches.Skip(380 * 8).Take(380).ToList();
            List<MatchCSV> matches_22_23_CSV = matches.Skip(380 * 9).Take(380).ToList();

            List<List<MatchCSV>> matchesDivided = new()
            {
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

            return matchesDivided;
        }

        public List<List<MatchCSV>> GetSeasonsWithCurrentSeason(DateOnly date)
        {
            var matches = DivideMatchesInSeasons();

            var seasonsBeforeMatch = new List<List<MatchCSV>>();

            if (date > new DateOnly(2013, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[0]);
            }
            if (date > new DateOnly(2014, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[1]);
            }
            if (date > new DateOnly(2015, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[2]);
            }
            if (date > new DateOnly(2016, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[3]);
            }
            if (date > new DateOnly(2017, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[4]);
            }
            if (date > new DateOnly(2018, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[5]);
            }
            if (date > new DateOnly(2029, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[6]);
            }
            if (date > new DateOnly(2020, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[7]);
            }
            if (date > new DateOnly(2021, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[8]);
            }
            if (date > new DateOnly(2022, 8, 1))
            {
                seasonsBeforeMatch.Add(matches[9]);
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
            var season = GetSeasonsWithCurrentSeason(date).Last();
            return season;
        }

        public IEnumerable<MatchCSV> GetCurrentSeasonAllMatchesBeforeMatch(DateOnly date)
        {
            var season = GetSeasonsWithCurrentSeason(date).Last();
            var matches = season.Where(m => m.Date < date);
            return matches;
        }

    }
}
