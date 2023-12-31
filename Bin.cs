////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace Engineering_Diploma_Project_Csharp
////{
////    internal class Bin
////    {
////        public double CurentSeasonAveragePoints(string teamName, DateOnly date)
////        {
////            var matches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
////            if (matches.Count() == 0)
////            {
////                return 0;
////            }
////            var teamMatches = matches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            if (teamMatches.Count() == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                int points = 0;
////                foreach (var match in teamMatches)
////                {
////                    if (match.HomeTeam == teamName && match.FTR == "H")
////                    {
////                        points += 3;
////                    }
////                    if (match.AwayTeam == teamName && match.FTR == "A")
////                    {
////                        points += 3;
////                    }
////                    if (match.FTR == "D")
////                    {
////                        points += 1;
////                    }
////                }
////                return (double)points / teamMatches.Count();
////            }

////        }

////        public double CurrentSeasonAverageGoalsScored(string teamName, DateOnly date)
////        {
////            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
////            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            if (cureentSeasonTeamMatches.Count() == 0)
////            {
////                return 0;
////            }

////            int goalsScored = 0;
////            int numberOfMatches = 0;
////            foreach (var match in cureentSeasonTeamMatches)
////            {
////                if (match.HomeTeam == teamName)
////                {
////                    goalsScored += match.FTHG;
////                }
////                else if (match.AwayTeam == teamName)
////                {
////                    goalsScored += match.FTAG;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)goalsScored / numberOfMatches;
////            }
////        }

////        public double CurrentSeasonAverageGoalsConceded(string teamName, DateOnly date)
////        {
////            var currentSeasonMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
////            var cureentSeasonTeamMatches = currentSeasonMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            if (cureentSeasonTeamMatches.Count() == 0)
////            {
////                return 0;
////            }

////            int goalsConceded = 0;
////            int numberOfMatches = 0;
////            foreach (var match in cureentSeasonTeamMatches)
////            {
////                if (match.AwayTeam == teamName)
////                {
////                    goalsConceded += match.FTHG;
////                }
////                else if (match.HomeTeam == teamName)
////                {
////                    goalsConceded += match.FTAG;
////                }
////                numberOfMatches++;
////            }
////            Console.WriteLine("number of matches counted = " + numberOfMatches);
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)goalsConceded / numberOfMatches;
////            }
////        }

////        public int LastSeasonCleanSheats(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
////            int cleanSheats = 0;
////            foreach (var match in lastSeason)
////            {
////                if (match.HomeTeam == teamName && match.FTAG == 0)
////                {
////                    cleanSheats++;
////                }
////                else if (match.AwayTeam == teamName && match.FTAG == 0)
////                {
////                    cleanSheats++;
////                }
////            }
////            return cleanSheats;
////        }

////        public double LastSeasonAverageGoalsScored(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int goalsScored = 0;
////            int numberOfMatches = 0;
////            foreach (var match in lastSeason)
////            {
////                if (match.HomeTeam == teamName)
////                {
////                    goalsScored += match.FTHG;
////                }
////                else if (match.AwayTeam == teamName)
////                {
////                    goalsScored += match.FTAG;
////                }
////                numberOfMatches++;
////            }
////            Console.WriteLine("number of matches counted = " + numberOfMatches);
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)goalsScored / numberOfMatches;
////            }
////        }

////        public double LastSeasonAverageGoalsConceded(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int goalsConceded = 0;
////            int numberOfMatches = 0;
////            foreach (var match in lastSeason)
////            {
////                if (match.AwayTeam == teamName)
////                {
////                    goalsConceded += match.FTHG;
////                }
////                else if (match.HomeTeam == teamName)
////                {
////                    goalsConceded += match.FTAG;
////                }
////                numberOfMatches++;
////            }
////            Console.WriteLine("number of matches counted = " + numberOfMatches);
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)goalsConceded / numberOfMatches;
////            }
////        }

////        public double LastSeasonAveragePoints(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int points = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.HomeTeam == teamName && match.FTR == "H")
////                {
////                    points += 3;
////                }
////                if (match.AwayTeam == teamName && match.FTR == "A")
////                {
////                    points += 3;
////                }
////                if (match.FTR == "D")
////                {
////                    points += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)points / numberOfMatches;
////            }
////        }

////        public int LastSeasonWins(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int wins = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.HomeTeam == teamName && match.FTR == "H")
////                {
////                    wins++;
////                }
////                else if (match.AwayTeam == teamName && match.FTR == "A")
////                {
////                    wins++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return wins;
////            }
////        }

////        public int LastSeasonLoses(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int loses = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.HomeTeam == teamName && match.FTR == "A")
////                {
////                    loses++;
////                }
////                if (match.AwayTeam == teamName && match.FTR == "H")
////                {
////                    loses++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return loses;
////            }
////        }

////        public int LastSeasonDraws(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
////            int draws = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "D")
////                {
////                    draws += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return draws;
////            }
////        }

////        public double LastSeasonAveragePointsHome(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
////            int points = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "H")
////                {
////                    points += 3;
////                }
////                if (match.FTR == "D")
////                {
////                    points += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)points / numberOfMatches;
////            }
////        }

////        public int LastSeasonWinsHome(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
////            int wins = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "H")
////                {
////                    wins++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return wins;
////            }
////        }

////        public int LastSeasonDrawsHome(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
////            int draws = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "D")
////                {
////                    draws += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return draws;
////            }
////        }

////        public int LastSeasonLosesHome(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
////            int loses = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "A")
////                {
////                    loses++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return loses;
////            }
////        }

////        public double LastSeasonAveragePointsAway(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
////            int points = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "A")
////                {
////                    points += 3;
////                }
////                if (match.FTR == "D")
////                {
////                    points += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return (double)points / numberOfMatches;
////            }
////        }

////        public double LastSeasonWinsAway(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
////            int wins = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "A")
////                {
////                    wins++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return wins;
////            }
////        }

////        public double LastSeasonDrawsAway(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
////            int draws = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "D")
////                {
////                    draws += 1;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return draws;
////            }
////        }

////        public double LastSeasonLosesAway(string teamName, DateOnly date)
////        {
////            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
////            if (seasonsWithCurrentSeason.Count < 2)
////            {
////                return 0;
////            }
////            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
////            int loses = 0;
////            int numberOfMatches = 0;

////            foreach (var match in lastSeason)
////            {
////                if (match.FTR == "H")
////                {
////                    loses++;
////                }
////                numberOfMatches++;
////            }
////            if (numberOfMatches == 0)
////            {
////                return 0;
////            }
////            else
////            {
////                return loses;
////            }
////        }
////    }
////}

////Console.WriteLine(matchStatsService.LastSeasonAveragePointsPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAveragePointsPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAveragePointsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAveragePointsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAveragePointsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAveragePointsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAveragePointsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonWinsPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonWinsPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsWinsPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsWinsPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonWinsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonWinsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsWinsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsWinsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonWinsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonWinsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsWinsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsWinsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonDrawsPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonDrawsPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsDrawsPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsDrawsPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonDrawsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonDrawsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsDrawsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsDrawsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonDrawsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonDrawsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsDrawsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsDrawsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonLosesPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonLosesPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsLosesPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsLosesPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonLosesHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonLosesHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsLosesHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsLosesHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonLosesAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonLosesAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsLosesAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsLosesAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsScoredAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonAverageGoalsConcededAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsHomePerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsHomePerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));

////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.LastSeasonCleanSheatsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30)));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsAwayPerMatch("Arsenal", new DateOnly(2020, 05, 30), 1));
////Console.WriteLine(matchStatsService.NSeasonsCleanSheatsAwayPerMatch("Huddersfield", new DateOnly(2020, 05, 30), 1));



//// LastSeason:
//public double LastSeasonAveragePointsPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    int points = 0;
//    int numberOfMatches = 0;
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)points / numberOfMatches;
//}
//public double LastSeasonAveragePointsHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int points = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)points / numberOfMatches;
//}
//public double LastSeasonAveragePointsAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int points = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)points / numberOfMatches;
//}

//public double LastSeasonWinsPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int wins = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    wins += 1;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    wins += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                wins += 1;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                wins += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)wins / numberOfMatches;
//}
//public double LastSeasonWinsHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int wins = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    wins += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                wins += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)wins / numberOfMatches;
//}
//public double LastSeasonWinsAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int wins = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    wins += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                wins += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)wins / numberOfMatches;
//}

//public double LastSeasonDrawsPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int draws = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.FTR == "D")
//            {
//                draws += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)draws / numberOfMatches;
//}
//public double LastSeasonDrawsHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int draws = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "D")
//            {
//                draws += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)draws / numberOfMatches;
//}
//public double LastSeasonDrawsAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int draws = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "D")
//                {
//                    draws += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "D")
//            {
//                draws += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)draws / numberOfMatches;
//}

//public double LastSeasonLosesPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int loses = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "A")
//                {
//                    loses += 1;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "H")
//                {
//                    loses += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "A")
//            {
//                loses += 1;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "H")
//            {
//                loses += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)loses / numberOfMatches;
//}
//public double LastSeasonLosesHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int loses = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "A")
//                {
//                    loses += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "A")
//            {
//                loses += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)loses / numberOfMatches;
//}
//public double LastSeasonLosesAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int loses = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "H")
//                {
//                    loses += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "H")
//            {
//                loses += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)loses / numberOfMatches;
//}

//public double LastSeasonAverageGoalsScoredPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer)
//                {
//                    goals += match.FTHG;
//                }
//                if (match.AwayTeam == newComer)
//                {
//                    goals += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName)
//            {
//                goals += match.FTHG;
//            }
//            if (match.AwayTeam == teamName)
//            {
//                goals += match.FTAG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}
//public double LastSeasonAverageGoalsConcededPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer)
//                {
//                    goals += match.FTAG;
//                }
//                if (match.AwayTeam == newComer)
//                {
//                    goals += match.FTHG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName)
//            {
//                goals += match.FTAG;
//            }
//            if (match.AwayTeam == teamName)
//            {
//                goals += match.FTHG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}

//public double LastSeasonAverageGoalsScoredHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer)
//                {
//                    goals += match.FTHG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName)
//            {
//                goals += match.FTHG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}
//public double LastSeasonAverageGoalsConcededHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer)
//                {
//                    goals += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName)
//            {
//                goals += match.FTAG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}

//public double LastSeasonAverageGoalsScoredAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer)
//                {
//                    goals += match.FTAG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName)
//            {
//                goals += match.FTAG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}
//public double LastSeasonAverageGoalsConcededAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int goals = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer)
//                {
//                    goals += match.FTHG;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName)
//            {
//                goals += match.FTHG;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)goals / numberOfMatches;
//}

//public double LastSeasonCleanSheatsPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int cleanSheats = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTAG == 0)
//                {
//                    cleanSheats += 1;
//                }
//                if (match.AwayTeam == newComer && match.FTHG == 0)
//                {
//                    cleanSheats += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTAG == 0)
//            {
//                cleanSheats += 1;
//            }
//            if (match.AwayTeam == teamName && match.FTHG == 0)
//            {
//                cleanSheats += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)cleanSheats / numberOfMatches;
//}
//public double LastSeasonCleanSheatsHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int cleanSheats = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTAG == 0)
//                {
//                    cleanSheats += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTAG == 0)
//            {
//                cleanSheats += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)cleanSheats / numberOfMatches;
//}
//public double LastSeasonCleanSheatsAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int cleanSheats = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTHG == 0)
//                {
//                    cleanSheats += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTHG == 0)
//            {
//                cleanSheats += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)cleanSheats / numberOfMatches;
//}




//public double Last3SeasonsAveragePointsPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 4)
//    {
//        return 0;
//    }

//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
//    int points = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0)
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

//    if (lastSeason2.Count() == 0)
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 1, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason2)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

//    if (lastSeason3.Count() == 0)
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 2, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason3)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    return (double)points / numberOfMatches;
//}
//public double Last3SeasonsAveragePointsHomePerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
//    int points = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.HomeTeam == teamName);

//    if (lastSeason2.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 1, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason2)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.HomeTeam == teamName);

//    if (lastSeason3.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 2, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.HomeTeam == newComer && match.FTR == "H")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason3)
//        {
//            if (match.HomeTeam == teamName && match.FTR == "H")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }
//    return (double)points / numberOfMatches;
//}
//public double Last3SeasonsAveragePointsAwayPerMatch(string teamName, DateOnly date)
//{
//    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
//    if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
//    {
//        return 0;
//    }
//    var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
//    int points = 0;
//    int numberOfMatches = 0;

//    if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.AwayTeam == teamName);

//    if (lastSeason2.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 1, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason2)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }

//    var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.AwayTeam == teamName);

//    if (lastSeason3.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
//    {
//        var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 2, date.Month, date.Day));
//        foreach (var newComer in newComersFromLastSeason!)
//        {
//            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
//            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
//            foreach (var match in newComerMatchesInLastSeason)
//            {
//                if (match.AwayTeam == newComer && match.FTR == "A")
//                {
//                    points += 3;
//                }
//                if (match.FTR == "D")
//                {
//                    points += 1;
//                }
//                numberOfMatches++;
//            }
//        }

//    }
//    else
//    {
//        foreach (var match in lastSeason3)
//        {
//            if (match.AwayTeam == teamName && match.FTR == "A")
//            {
//                points += 3;
//            }
//            if (match.FTR == "D")
//            {
//                points += 1;
//            }
//            numberOfMatches++;
//        }
//    }
//    return (double)points / numberOfMatches;
//}



//using Engineering_Diploma_Project_Csharp;

//var matchStatsService = new MatchStatsService();

//var newcomers1 = matchStatsService.GetNewComersFromLastSeason(new DateOnly(2022, 12, 12)); // - beniaminkowe w sezonie 2021/22
//var newcomers2 = matchStatsService.GetNewComersFromLastSeason(new DateOnly(2021, 12, 12));
//var newcomers3 = matchStatsService.GetNewComersFromLastSeason(new DateOnly(2020, 12, 12));
//var newcomers4 = matchStatsService.GetNewComersFromLastSeason(new DateOnly(2019, 12, 12));
//var newcomers5 = matchStatsService.GetNewComersFromLastSeason(new DateOnly(2018, 12, 12));
//foreach (var newcomer in newcomers1)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2022, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//}
//foreach (var newcomer in newcomers2)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2021, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//}
//foreach (var newcomer in newcomers3)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2020, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//}
//foreach (var newcomer in newcomers4)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2019, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//}
//foreach (var newcomer in newcomers5)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2018, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//}


//var bigSix = new string[] { "Man United", "Chelsea", "Arsenal", "Man City", "Liverpool", "Tottenham" };
//foreach (var team in bigSix)
//{
//    Console.WriteLine("2022");
//    Console.WriteLine(team);
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(team, new DateOnly(2022, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(points);
//}
//foreach (var team in bigSix)
//{
//    Console.WriteLine("2021");
//    Console.WriteLine(team);
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(team, new DateOnly(2021, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(points);
//}
//foreach (var team in bigSix)
//{
//    Console.WriteLine("2020");
//    Console.WriteLine(team);
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(team, new DateOnly(2020, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(points);
//}
//foreach (var team in bigSix)
//{
//    Console.WriteLine("2019");
//    Console.WriteLine(team);
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(team, new DateOnly(2019, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(points);
//}
//foreach (var team in bigSix)
//{
//    Console.WriteLine("2018");
//    Console.WriteLine(team);
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(team, new DateOnly(2018, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(points);
//}

//var others1 = matchStatsService.GetNotNewComersAndNoBigSixFromLastSeason(new DateOnly(2022, 12, 12));
//var others2 = matchStatsService.GetNotNewComersAndNoBigSixFromLastSeason(new DateOnly(2021, 12, 12));
//var others3 = matchStatsService.GetNotNewComersAndNoBigSixFromLastSeason(new DateOnly(2020, 12, 12));
//var others4 = matchStatsService.GetNotNewComersAndNoBigSixFromLastSeason(new DateOnly(2019, 12, 12));
//var others5 = matchStatsService.GetNotNewComersAndNoBigSixFromLastSeason(new DateOnly(2018, 12, 12));

//foreach (var other in others1)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(other, new DateOnly(2022, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(other);
//    Console.WriteLine(points);
//}
//foreach (var other in others2)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(other, new DateOnly(2021, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(other);
//    Console.WriteLine(points);
//}
//foreach (var other in others3)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(other, new DateOnly(2020, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(other);
//    Console.WriteLine(points);
//}
//foreach (var other in others4)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(other, new DateOnly(2019, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(other);
//    Console.WriteLine(points);
//}
//foreach (var other in others5)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(other, new DateOnly(2018, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(other);
//    Console.WriteLine(points);
//}