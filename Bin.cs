//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Engineering_Diploma_Project_Csharp
//{
//    internal class Bin
//    {
//        public double CurentSeasonAveragePoints(string teamName, DateOnly date)
//        {
//            var matches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
//            if (matches.Count() == 0)
//            {
//                return 0;
//            }
//            var teamMatches = matches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            if (teamMatches.Count() == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                int points = 0;
//                foreach (var match in teamMatches)
//                {
//                    if (match.HomeTeam == teamName && match.FTR == "H")
//                    {
//                        points += 3;
//                    }
//                    if (match.AwayTeam == teamName && match.FTR == "A")
//                    {
//                        points += 3;
//                    }
//                    if (match.FTR == "D")
//                    {
//                        points += 1;
//                    }
//                }
//                return (double)points / teamMatches.Count();
//            }

//        }

//        public double CurrentSeasonAverageGoalsScored(string teamName, DateOnly date)
//        {
//            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
//            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            if (cureentSeasonTeamMatches.Count() == 0)
//            {
//                return 0;
//            }

//            int goalsScored = 0;
//            int numberOfMatches = 0;
//            foreach (var match in cureentSeasonTeamMatches)
//            {
//                if (match.HomeTeam == teamName)
//                {
//                    goalsScored += match.FTHG;
//                }
//                else if (match.AwayTeam == teamName)
//                {
//                    goalsScored += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)goalsScored / numberOfMatches;
//            }
//        }

//        public double CurrentSeasonAverageGoalsConceded(string teamName, DateOnly date)
//        {
//            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
//            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            if (cureentSeasonTeamMatches.Count() == 0)
//            {
//                return 0;
//            }

//            int goalsConceded = 0;
//            int numberOfMatches = 0;
//            foreach (var match in cureentSeasonTeamMatches)
//            {
//                if (match.AwayTeam == teamName)
//                {
//                    goalsConceded += match.FTHG;
//                }
//                else if (match.HomeTeam == teamName)
//                {
//                    goalsConceded += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//            Console.WriteLine("number of matches counted = " + numberOfMatches);
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)goalsConceded / numberOfMatches;
//            }
//        }

//        public int LastSeasonCleanSheats(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            int cleanSheats = 0;
//            foreach (var match in lastSeason)
//            {
//                if (match.HomeTeam == teamName && match.FTAG == 0)
//                {
//                    cleanSheats++;
//                }
//                else if (match.AwayTeam == teamName && match.FTAG == 0)
//                {
//                    cleanSheats++;
//                }
//            }
//            return cleanSheats;
//        }

//        public double LastSeasonAverageGoalsScored(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int goalsScored = 0;
//            int numberOfMatches = 0;
//            foreach (var match in lastSeason)
//            {
//                if (match.HomeTeam == teamName)
//                {
//                    goalsScored += match.FTHG;
//                }
//                else if (match.AwayTeam == teamName)
//                {
//                    goalsScored += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//            Console.WriteLine("number of matches counted = " + numberOfMatches);
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)goalsScored / numberOfMatches;
//            }
//        }

//        public double LastSeasonAverageGoalsConceded(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int goalsConceded = 0;
//            int numberOfMatches = 0;
//            foreach (var match in lastSeason)
//            {
//                if (match.AwayTeam == teamName)
//                {
//                    goalsConceded += match.FTHG;
//                }
//                else if (match.HomeTeam == teamName)
//                {
//                    goalsConceded += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//            Console.WriteLine("number of matches counted = " + numberOfMatches);
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)goalsConceded / numberOfMatches;
//            }
//        }

//        public double LastSeasonAveragePoints(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int points = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.HomeTeam == teamName && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.AwayTeam == teamName && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)points / numberOfMatches;
//            }
//        }

//        public int LastSeasonWins(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int wins = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.HomeTeam == teamName && match.FTR == "H")
//                {
//                    wins++;
//                }
//                else if (match.AwayTeam == teamName && match.FTR == "A")
//                {
//                    wins++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return wins;
//            }
//        }

//        public int LastSeasonLoses(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int loses = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.HomeTeam == teamName && match.FTR == "A")
//                {
//                    loses++;
//                }
//                if (match.AwayTeam == teamName && match.FTR == "H")
//                {
//                    loses++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return loses;
//            }
//        }

//        public int LastSeasonDraws(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//            int draws = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return draws;
//            }
//        }

//        public double LastSeasonAveragePointsHome(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//            int points = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)points / numberOfMatches;
//            }
//        }

//        public int LastSeasonWinsHome(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//            int wins = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "H")
//                {
//                    wins++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return wins;
//            }
//        }

//        public int LastSeasonDrawsHome(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//            int draws = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return draws;
//            }
//        }

//        public int LastSeasonLosesHome(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//            int loses = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "A")
//                {
//                    loses++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return loses;
//            }
//        }

//        public double LastSeasonAveragePointsAway(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//            int points = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return (double)points / numberOfMatches;
//            }
//        }

//        public double LastSeasonWinsAway(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//            int wins = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "A")
//                {
//                    wins++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return wins;
//            }
//        }

//        public double LastSeasonDrawsAway(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//            int draws = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return draws;
//            }
//        }

//        public double LastSeasonLosesAway(string teamName, DateOnly date)
//        {
//            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//            if (seasonsWithCurrentSeason.Count < 2)
//            {
//                return 0;
//            }
//            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//            int loses = 0;
//            int numberOfMatches = 0;

//            foreach (var match in lastSeason)
//            {
//                if (match.FTR == "H")
//                {
//                    loses++;
//                }
//                numberOfMatches++;
//            }
//            if (numberOfMatches == 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return loses;
//            }
//        }
//    }
//}
