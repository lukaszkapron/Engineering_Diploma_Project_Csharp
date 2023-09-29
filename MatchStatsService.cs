namespace Engineering_Diploma_Project_Csharp
{
    internal class MatchStatsService
    {
        private readonly CSVReaderHelper _csvReaderHelper;

        public MatchStatsService()
        {
            _csvReaderHelper = new CSVReaderHelper();
        }

        //public static IEnumerable<MatchCSV> ReadMatches()
        //{
        //    var matches = CSVReader.ReadMatches();
        //    return matches;
        //}

        //public List<List<MatchCSV>> DivideMatchesInSeasons()
        //{
        //    var matches = _csvReader.Matches;

        //    List<MatchCSV> matches_13_14_CSV = matches.Take(380).ToList();
        //    List<MatchCSV> matches_14_15_CSV = matches.Skip(380).Take(380).ToList();
        //    List<MatchCSV> matches_15_16_CSV = matches.Skip(380 * 2).Take(380).ToList();
        //    List<MatchCSV> matches_16_17_CSV = matches.Skip(380 * 3).Take(380).ToList();
        //    List<MatchCSV> matches_17_18_CSV = matches.Skip(380 * 4).Take(380).ToList();
        //    List<MatchCSV> matches_18_19_CSV = matches.Skip(380 * 5).Take(380).ToList();
        //    List<MatchCSV> matches_19_20_CSV = matches.Skip(380 * 6).Take(380).ToList();
        //    List<MatchCSV> matches_20_21_CSV = matches.Skip(380 * 7).Take(380).ToList();
        //    List<MatchCSV> matches_21_22_CSV = matches.Skip(380 * 8).Take(380).ToList();
        //    List<MatchCSV> matches_22_23_CSV = matches.Skip(380 * 9).Take(380).ToList();

        //    List<List<MatchCSV>> matchesDivided = new()
        //    {
        //        matches_13_14_CSV,
        //        matches_14_15_CSV,
        //        matches_15_16_CSV,
        //        matches_16_17_CSV,
        //        matches_17_18_CSV,
        //        matches_18_19_CSV,
        //        matches_19_20_CSV,
        //        matches_20_21_CSV,
        //        matches_21_22_CSV,
        //        matches_22_23_CSV
        //    };

        //    return matchesDivided;
        //}

        //public static List<List<MatchCSV>> GetSeasonsWithCurrentSeason(DateOnly date)
        //{
        //    var matches = DivideMatchesInSeasons();

        //    var seasonsBeforeMatch = new List<List<MatchCSV>>();

        //    if (date > new DateOnly(2013, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[0]);
        //    }
        //    if (date > new DateOnly(2014, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[1]);
        //    }
        //    if (date > new DateOnly(2015, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[2]);
        //    }
        //    if (date > new DateOnly(2016, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[3]);
        //    }
        //    if (date > new DateOnly(2017, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[4]);
        //    }
        //    if (date > new DateOnly(2018, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[5]);
        //    }
        //    if (date > new DateOnly(2029, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[6]);
        //    }
        //    if (date > new DateOnly(2020, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[7]);
        //    }
        //    if (date > new DateOnly(2021, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[8]);
        //    }
        //    if (date > new DateOnly(2022, 8, 1))
        //    {
        //        seasonsBeforeMatch.Add(matches[9]);
        //    }

        //    return seasonsBeforeMatch;
        //}

        //public static IEnumerable<MatchCSV> GetAllMatchesBeforeMatch(DateOnly date)
        //{
        //    var matches = ReadMatches();
        //    var matchesBefore = matches.Where(m => m.Date < date);
        //    return matchesBefore;
        //}

        //public static IEnumerable<MatchCSV> GetCurrentSeasonAllMatches(DateOnly date)
        //{
        //    var season = GetSeasonsWithCurrentSeason(date).Last();
        //    return season;
        //}

        //public static IEnumerable<MatchCSV> GetCurrentSeasonAllMatchesBeforeMatch(DateOnly date)
        //{
        //    var season = GetSeasonsWithCurrentSeason(date).Last();
        //    var matches = season.Where(m => m.Date < date);
        //    return matches;
        //}


        public double NumberOfSeasonsInPLPerSeason(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            int seasonsCount = 0;
            foreach (var matches in seasonsWithCurrentSeason)
            {
                if (matches.Any(m => m.HomeTeam == teamName))
                {
                    seasonsCount++;
                }
            }
            return (double)seasonsCount/seasonsWithCurrentSeason.Count;
        }

        public bool IsNewInPL(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count <= 1)
            {
                return false;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
            if (lastSeason.Any(m => m.HomeTeam == teamName))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool IsBigSix(string teamName)
        {
            if (teamName == "Arsenal" || teamName == "Chelsea" || teamName == "Man City" || teamName == "Man United" || teamName == "Liverpool" || teamName == "Tottenham")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int NumberOfRedCardsInLastMatch(string teamName, DateOnly date)
        {
            var matches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            if (matches.Count() == 0)
            {
                return 0;
            }
            var teamLastMatches = matches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).ToList();
            if (teamLastMatches.Count() == 0)
            {
                return 0;
            }
            var teamLastMatch = teamLastMatches.Last();
            if (teamLastMatch == null)
            {
                return 0;
            }
            if (teamLastMatch.HomeTeam == teamName)
            {
                return teamLastMatch.HR;
            }
            else
            {
                return teamLastMatch.AR;
            }
        }  

        public double CurentSeasonAveragePoints(string teamName, DateOnly date)
        {
            var matches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            if (matches.Count() == 0)
            {
                return 0;
            }
            var teamMatches = matches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (teamMatches.Count() == 0)
            {
                return 0;
            }
            else
            {
                int points = 0;
                foreach (var match in teamMatches)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        points += 3;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        points += 3;
                    }
                    if (match.FTR == "D")
                    {
                        points += 1;
                    }
                }
                return (double)points / teamMatches.Count();
            }

        }

        public double CurrentSeasonAverageGoalsScored(string teamName, DateOnly date)
        {
            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (cureentSeasonTeamMatches.Count() == 0)
            {
                return 0;
            }

            int goalsScored = 0;
            int numberOfMatches = 0;
            foreach (var match in cureentSeasonTeamMatches)
            {
                if (match.HomeTeam == teamName)
                {
                    goalsScored += match.FTHG;
                }
                else if (match.AwayTeam == teamName)
                {
                    goalsScored += match.FTAG;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)goalsScored / numberOfMatches;
            }
        }

        public double CurrentSeasonAverageGoalsConceded(string teamName, DateOnly date)
        {
            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (cureentSeasonTeamMatches.Count() == 0)
            {
                return 0;
            }

            int goalsConceded = 0;
            int numberOfMatches = 0;
            foreach (var match in cureentSeasonTeamMatches)
            {
                if (match.AwayTeam == teamName)
                {
                    goalsConceded += match.FTHG;
                }
                else if (match.HomeTeam == teamName)
                {
                    goalsConceded += match.FTAG;
                }
                numberOfMatches++;
            }
            Console.WriteLine("number of matches counted = " + numberOfMatches);
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)goalsConceded / numberOfMatches;
            }
        }

        public int LastSeasonCleanSheats(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
            int cleanSheats = 0;
            foreach (var match in lastSeason)
            {
                if (match.HomeTeam == teamName && match.FTAG == 0)
                {
                    cleanSheats++;
                }
                else if (match.AwayTeam == teamName && match.FTAG == 0)
                {
                    cleanSheats++;
                }
            }
            return cleanSheats;
        }



        public double LastSeasonAverageGoalsScored(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int goalsScored = 0;
            int numberOfMatches = 0;
            foreach (var match in lastSeason)
            {
                if (match.HomeTeam == teamName)
                {
                    goalsScored += match.FTHG;
                }
                else if (match.AwayTeam == teamName)
                {
                    goalsScored += match.FTAG;
                }
                numberOfMatches++;
            }
            Console.WriteLine("number of matches counted = " + numberOfMatches);
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)goalsScored / numberOfMatches;
            }
        }

        public double LastSeasonAverageGoalsConceded(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int goalsConceded = 0;
            int numberOfMatches = 0;
            foreach (var match in lastSeason)
            {
                if (match.AwayTeam == teamName)
                {
                    goalsConceded += match.FTHG;
                }
                else if (match.HomeTeam == teamName)
                {
                    goalsConceded += match.FTAG;
                }
                numberOfMatches++;
            }
            Console.WriteLine("number of matches counted = " + numberOfMatches);
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)goalsConceded / numberOfMatches;
            }
        }

        public double LastSeasonAveragePoints(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.HomeTeam == teamName && match.FTR == "H")
                {
                    points += 3;
                }
                if (match.AwayTeam == teamName && match.FTR == "A")
                {
                    points += 3;
                }
                if (match.FTR == "D")
                {
                    points += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)points / numberOfMatches;
            }
        }

        public int LastSeasonWins(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.HomeTeam == teamName && match.FTR == "H")
                {
                    wins++;
                }
                else if (match.AwayTeam == teamName && match.FTR == "A")
                {
                    wins++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return wins;
            }
        }

        public int LastSeasonLoses(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.HomeTeam == teamName && match.FTR == "A")
                {
                    loses++;
                }
                if (match.AwayTeam == teamName && match.FTR == "H")
                {
                    loses++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return loses;
            }
        }

        public int LastSeasonDraws(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "D")
                {
                    draws += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return draws;
            }
        }

        public double LastSeasonAveragePointsHome(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "H")
                {
                    points += 3;
                }
                if (match.FTR == "D")
                {
                    points += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)points / numberOfMatches;
            }
        }

        public int LastSeasonWinsHome(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "H")
                {
                    wins++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return wins;
            }
        }

        public int LastSeasonDrawsHome(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "D")
                {
                    draws += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return draws;
            }
        }

        public int LastSeasonLosesHome(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "A")
                {
                    loses++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return loses;
            }
        }

        public double LastSeasonAveragePointsAway(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "A")
                {
                    points += 3;
                }
                if (match.FTR == "D")
                {
                    points += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return (double)points / numberOfMatches;
            }
        }

        public double LastSeasonWinsAway(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "A")
                {
                    wins++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return wins;
            }
        }

        public double LastSeasonDrawsAway(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "D")
                {
                    draws += 1;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return draws;
            }
        }

        public double LastSeasonLosesAway(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            foreach (var match in lastSeason)
            {
                if (match.FTR == "H")
                {
                    loses++;
                }
                numberOfMatches++;
            }
            if (numberOfMatches == 0)
            {
                return 0;
            }
            else
            {
                return loses;
            }
        }

        public string LastH2HMatchResult(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m=>(m.HomeTeam == teamName && m.AwayTeam == rival) || (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return "D";
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                if (lastMatch.FTR == "A")
                {
                    return lastMatch.AwayTeam;
                }
                else if (lastMatch.FTR == "D")
                {
                    return "D";
                }
                else
                {
                    return lastMatch.HomeTeam;
                }
            }
        }

        public int LastH2HGoalsScored(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival) || (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return 0;
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                if (lastMatch.HomeTeam == teamName)
                {
                    return lastMatch.FTHG;
                }
                else
                {
                    return lastMatch.FTAG;
                }
            }
        }

        public int LastH2HGoalsConceded(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival) || (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return 0;
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                if (lastMatch.HomeTeam == teamName)
                {
                    return lastMatch.FTAG;
                }
                else
                {
                    return lastMatch.FTHG;
                }
            }
        }

    }
}

