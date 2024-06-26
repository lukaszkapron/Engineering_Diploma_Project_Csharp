﻿namespace Engineering_Diploma_Project_Csharp
{
    internal class MatchStatsService
    {
        private readonly CSVReaderHelper _csvReaderHelper;

        public MatchStatsService()
        {
            _csvReaderHelper = new CSVReaderHelper();
        }

        // NewComers
        private List<string>? GetNewComersFromLastSeason(DateOnly date)
        {
            var returnList = new List<string>();
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return null;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
            foreach (var match in lastSeason.GroupBy(w => w.HomeTeam))
            {
                if (date.Month == 2 && date.Day == 29)
                {
                    var newDate = new DateOnly(date.Year - 1, date.Month, date.Day == 29 ? 28 : date.Day);
                }
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 1, date.Month, date.Day == 29 ? 28 : date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            return returnList;

        }

        public double NumberOfSeasonsInPLPerSeason(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            int seasonsCount = 0;
            int allSeasonsCount = 0;
            foreach (var season in seasonsWithCurrentSeason)
            {
                if (season.Any(m => m.HomeTeam == teamName))
                {
                    seasonsCount++;
                }
                allSeasonsCount++;
            }
            return (double)seasonsCount / allSeasonsCount;

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


        //N Seasons:
        public double NSeasonsAveragePointsPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return 0;
            }

            int points = 0;
            int numberOfMatches = 0;
            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newDate = new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day);
                    var newComersFromLastSeason = GetNewComersFromLastSeason(newDate);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                points += 3;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                points += 3;
                            }
                            if (match.FTR == "D")
                            {
                                points += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
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
                }
            }


            return (double)points / numberOfMatches;
        }
        public double NSeasonsAveragePointsHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int points = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                points += 3;
                            }
                            if (match.FTR == "D")
                            {
                                points += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            points += 3;
                        }
                        if (match.FTR == "D")
                        {
                            points += 1;
                        }
                        numberOfMatches++;
                    }
                }

            }

            return (double)points / numberOfMatches;
        }
        public double NSeasonsAveragePointsAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int points = 0;
            int numberOfMatches = 0;
            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                points += 3;
                            }
                            if (match.FTR == "D")
                            {
                                points += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
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
                }
            }


            return (double)points / numberOfMatches;
        }

        public double NSeasonsWinsPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int wins = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                wins += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            wins += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTR == "A")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)wins / numberOfMatches;
        }
        public double NSeasonsWinsHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int wins = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)wins / numberOfMatches;
        }
        public double NSeasonsWinsAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int wins = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName && match.FTR == "A")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)wins / numberOfMatches;
        }

        public double NSeasonsDrawsPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int draws = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)draws / numberOfMatches;
        }
        public double NSeasonsDrawsHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int draws = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }

            }

            return (double)draws / numberOfMatches;
        }
        public double NSeasonsDrawsAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int draws = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName && match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)draws / numberOfMatches;
        }

        public double NSeasonsLosesPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int loses = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "A")
                            {
                                loses += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "H")
                            {
                                loses += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "A")
                        {
                            loses += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTR == "H")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }

            }

            return (double)loses / numberOfMatches;
        }
        public double NSeasonsLosesHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int loses = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "A")
                            {
                                loses += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "A")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)loses / numberOfMatches;
        }
        public double NSeasonsLosesAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int loses = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "H")
                            {
                                loses += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName && match.FTR == "H")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)loses / numberOfMatches;
        }

        public double NSeasonsAverageGoalsScoredPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }
        public double NSeasonsAverageGoalsConcededPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }

        public double NSeasonsAverageGoalsScoredHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }
        public double NSeasonsAverageGoalsConcededHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }

        public double NSeasonsAverageGoalsScoredAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }
        public double NSeasonsAverageGoalsConcededAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int goals = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);
                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)goals / numberOfMatches;
        }

        public double NSeasonsCleanSheatsPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int cleanSheats = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTAG == 0)
                            {
                                cleanSheats += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTHG == 0)
                            {
                                cleanSheats += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTAG == 0)
                        {
                            cleanSheats += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTHG == 0)
                        {
                            cleanSheats += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)cleanSheats / numberOfMatches;
        }
        public double NSeasonsCleanSheatsHomePerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int cleanSheats = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.HomeTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTAG == 0)
                            {
                                cleanSheats += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.HomeTeam == teamName && match.FTAG == 0)
                        {
                            cleanSheats += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)cleanSheats / numberOfMatches;
        }
        public double NSeasonsCleanSheatsAwayPerMatch(string teamName, DateOnly date, int numberOfSeasons)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int cleanSheats = 0;
            int numberOfMatches = 0;

            for (int i = 0; i < numberOfSeasons; i++)
            {
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)].Where(m => m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day == 29 ? 28 : date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i + 2)];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTHG == 0)
                            {
                                cleanSheats += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    foreach (var match in lastSeason)
                    {
                        if (match.AwayTeam == teamName && match.FTHG == 0)
                        {
                            cleanSheats += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }


            return (double)cleanSheats / numberOfMatches;
        }


        //Current season:
        public double CurrentSeasonAveragePointsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int points = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                points += 3;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                points += 3;
                            }
                            if (match.FTR == "D")
                            {
                                points += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
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
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
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
            }

            return (double)points / numberOfMatches;
        }
        public double CurrentSeasonAveragePointsHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int points = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                points += 3;
                            }
                            if (match.FTR == "D")
                            {
                                points += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            points += 3;
                        }
                        if (match.FTR == "D")
                        {
                            points += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        points += 3;
                    }
                    if (match.FTR == "D")
                    {
                        points += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)points / numberOfMatches;
        }
        public double CurrentSeasonAveragePointsAwayPerMatch(string teamName, DateOnly date)
        {
            {
                var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
                int points = 0;
                int numberOfMatches = 0;
                var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

                if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
                {
                    if (IsNewInPL(teamName, date)) //benjaminek
                    {
                        var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                        foreach (var newComer in newComersFromLastSeason!)
                        {
                            var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                            var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                            foreach (var match in newComerMatchesInLastSeason)
                            {
                                if (match.AwayTeam == newComer && match.FTR == "A")
                                {
                                    points += 3;
                                }
                                if (match.FTR == "D")
                                {
                                    points += 1;
                                }
                                numberOfMatches++;
                            }
                        }

                    }
                    else
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                        foreach (var match in teamlastSeasonMatches)
                        {
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
                    }
                }

                else // nie pierwszye mecz w sezonie
                {
                    foreach (var match in currentSeason)
                    {
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
                }

                return (double)points / numberOfMatches;
            }

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
        }

        public double CurrentSeasonWinsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int wins = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                wins += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            wins += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTR == "A")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        wins += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        wins += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)wins / numberOfMatches;
        }
        public double CurrentSeasonWinsHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int wins = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "H")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "H")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        wins += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)wins / numberOfMatches;
        }
        public double CurrentSeasonWinsAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int wins = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "A")
                            {
                                wins += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.AwayTeam == teamName && match.FTR == "A")
                        {
                            wins += 1;
                        }

                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        wins += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)wins / numberOfMatches;
        }

        public double CurrentSeasonDrawsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int draws = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.FTR == "D")
                    {
                        draws += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)draws / numberOfMatches;
        }
        public double CurrentSeasonDrawsHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int draws = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.FTR == "D")
                    {
                        draws += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)draws / numberOfMatches;
        }
        public double CurrentSeasonDrawsAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int draws = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.FTR == "D")
                            {
                                draws += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.FTR == "D")
                    {
                        draws += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)draws / numberOfMatches;
        }

        public double CurrentSeasonLosesPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int loses = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "A")
                            {
                                loses += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTR == "H")
                            {
                                loses += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "A")
                        {
                            loses += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTR == "H")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        loses += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        loses += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)loses / numberOfMatches;
        }
        public double CurrentSeasonLosesHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int loses = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTR == "A")
                            {
                                loses += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTR == "A")
                        {
                            loses += 1;
                        }

                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "A")
                    {
                        loses += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)loses / numberOfMatches;
        }
        public double CurrentSeasonLosesAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int loses = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.AwayTeam == newComer && match.FTR == "H")
                            {
                                loses += 1;
                            }

                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.AwayTeam == teamName && match.FTR == "H")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.AwayTeam == teamName && match.FTR == "H")
                    {
                        loses += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)loses / numberOfMatches;
        }

        public double CurrentSeasonAverageGoalsScoredPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName )
                        {
                            goals += match.FTHG;
                        }
                        if (match.AwayTeam == teamName )
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }
        public double CurrentSeasonAverageGoalsConcededPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }

        public double CurrentSeasonAverageGoalsScoredHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }
        public double CurrentSeasonAverageGoalsConcededHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }

        public double CurrentSeasonAverageGoalsScoredAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m =>  m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }
        public double CurrentSeasonAverageGoalsConcededAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m =>  m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer)
                            {
                                goals += match.FTAG;
                            }
                            if (match.AwayTeam == newComer)
                            {
                                goals += match.FTHG;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName)
                        {
                            goals += match.FTAG;
                        }
                        if (match.AwayTeam == teamName)
                        {
                            goals += match.FTHG;
                        }
                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTHG;
                    }
                    numberOfMatches++;
                }
            }

            return (double)goals / numberOfMatches;
        }

        public double CurrentSeasonCleanSheatsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int cleanSheats = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTAG == 0)
                            {
                                cleanSheats += 1;
                            }
                            if (match.AwayTeam == newComer && match.FTHG == 0)
                            {
                                cleanSheats += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTAG == 0)
                        {
                            cleanSheats += 1;
                        }
                        if (match.AwayTeam == teamName && match.FTHG == 0)
                        {
                            cleanSheats += 1;
                        }

                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTAG == 0)
                    {
                        cleanSheats += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTHG == 0)
                    {
                        cleanSheats += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)cleanSheats / numberOfMatches;
        }
        public double CurrentSeasonCleanSheatsHomePerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int cleanSheats = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer );
                        foreach (var match in newComerMatchesInLastSeason)
                        {
                            if (match.HomeTeam == newComer && match.FTAG == 0)
                            {
                                cleanSheats += 1;
                            }

                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m => m.HomeTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {
                        if (match.HomeTeam == teamName && match.FTAG == 0)
                        {
                            cleanSheats += 1;
                        }

                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTAG == 0)
                    {
                        cleanSheats += 1;
                    }

                    numberOfMatches++;
                }
            }

            return (double)cleanSheats / numberOfMatches;
        }
        public double CurrentSeasonCleanSheatsAwayPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int cleanSheats = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.AwayTeam == teamName);
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            if (currentSeason.Count() == 0) // 1 mecz drużyny w sezonie
            {
                if (IsNewInPL(teamName, date)) //benjaminek
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                        var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m =>  m.AwayTeam == newComer);
                        foreach (var match in newComerMatchesInLastSeason)
                        {

                            if (match.AwayTeam == newComer && match.FTHG == 0)
                            {
                                cleanSheats += 1;
                            }
                            numberOfMatches++;
                        }
                    }

                }
                else
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var teamlastSeasonMatches = lastSeasonAllMatches.Where(m =>  m.AwayTeam == teamName);
                    foreach (var match in teamlastSeasonMatches)
                    {

                        if (match.AwayTeam == teamName && match.FTHG == 0)
                        {
                            cleanSheats += 1;
                        }

                        numberOfMatches++;
                    }
                }
            }

            else // nie pierwszye mecz w sezonie
            {
                foreach (var match in currentSeason)
                {

                    if (match.AwayTeam == teamName && match.FTHG == 0)
                    {
                        cleanSheats += 1;
                    }
                    numberOfMatches++;
                }
            }

            return (double)cleanSheats / numberOfMatches;
        }


        //Last 5 matches
        public double Last5MatchesAveragePointsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int points = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
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
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer && match.FTR == "H")
                        {
                            points += 3;
                        }
                        if (match.AwayTeam == newComer && match.FTR == "A")
                        {
                            points += 3;
                        }
                        if (match.FTR == "D")
                        {
                            points += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
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
            }
            

            return (double)points / numberOfMatches;
        }
        public double Last5MatchesWinsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int wins = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        wins += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        wins += 1;
                    }
                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer && match.FTR == "H")
                        {
                            wins += 1;
                        }
                        if (match.AwayTeam == newComer && match.FTR == "A")
                        {
                            wins += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.HomeTeam == teamName && match.FTR == "H")
                    {
                        wins += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "A")
                    {
                        wins += 1;
                    }
                    numberOfMatches++;
                }
            }


            return (double)wins / numberOfMatches;
        }
        public double Last5MatchesDrawsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int draws = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.FTR == "D")
                    {
                        draws += 1;
                    }
                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.FTR == "D")
                        {
                            draws += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.FTR == "D")
                    {
                        draws += 1;
                    }
                    numberOfMatches++;
                }
            }


            return (double)draws / numberOfMatches;
        }
        public double Last5MatchesLosesPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int loses = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTR == "A")
                    {
                        loses +=1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "H")
                    {
                        loses += 1;
                    }
                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer && match.FTR == "A")
                        {
                            loses += 1;
                        }
                        if (match.AwayTeam == newComer && match.FTR == "H")
                        {
                            loses += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.HomeTeam == teamName && match.FTR == "A")
                    {
                        loses += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTR == "H")
                    {
                        loses += 1;
                    }
                    numberOfMatches++;
                }
            }


            return (double)loses / numberOfMatches;
        }

        public double Last5MatchesAverageGoalsScoredPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName )
                    {
                        goals += match.FTHG;
                    }
                    if (match.AwayTeam == teamName )
                    {
                        goals += match.FTAG;
                    }

                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer )
                        {
                            goals += match.FTHG;
                        }
                        if (match.AwayTeam == newComer )
                        {
                            goals += match.FTAG;
                        }

                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.HomeTeam == teamName )
                    {
                        goals += match.FTHG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTAG;
                    }

                    numberOfMatches++;
                }
            }


            return (double)goals / numberOfMatches;
        }
        public double Last5MatchesAverageGoalsConcededPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int goals = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTHG;
                    }

                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer)
                        {
                            goals += match.FTAG;
                        }
                        if (match.AwayTeam == newComer)
                        {
                            goals += match.FTHG;
                        }

                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.HomeTeam == teamName)
                    {
                        goals += match.FTAG;
                    }
                    if (match.AwayTeam == teamName)
                    {
                        goals += match.FTHG;
                    }

                    numberOfMatches++;
                }
            }


            return (double)goals / numberOfMatches;
        }

        public double Last5MatchesCleanSheatsPerMatch(string teamName, DateOnly date)
        {
            var currentSeasonAllMatches = _csvReaderHelper.GetCurrentSeasonAllMatchesBeforeMatch(date);
            int cleanSheats = 0;
            int numberOfMatches = 0;
            var currentSeason = currentSeasonAllMatches.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            if (currentSeason.Count() < 5 && IsNewInPL(teamName, date)) // w tym sezonie mniej niz 5 meczy rozegrała
            {
                foreach (var match in currentSeason)
                {
                    if (match.HomeTeam == teamName && match.FTAG == 0)
                    {
                        cleanSheats += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTHG == 0)
                    {
                        cleanSheats += 1;
                    }
                    numberOfMatches++;
                }
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m => m.HomeTeam == newComer || m.AwayTeam == newComer);
                    var newComersLastXMatches = newComerMatchesInLastSeason.TakeLast(5 - currentSeason.Count());
                    foreach (var match in newComersLastXMatches)
                    {
                        if (match.HomeTeam == newComer && match.FTAG == 0)
                        {
                            cleanSheats += 1;
                        }
                        if (match.AwayTeam == newComer && match.FTHG == 0)
                        {
                            cleanSheats += 1;
                        }
                        numberOfMatches++;
                    }
                }
            }
            else
            {
                var allMatchesBeforeMatch = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
                var teamLast5MatchesBeforeMatch = allMatchesBeforeMatch.Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName).TakeLast(5);
                foreach (var match in teamLast5MatchesBeforeMatch)
                {
                    if (match.HomeTeam == teamName && match.FTAG == 0)
                    {
                        cleanSheats += 1;
                    }
                    if (match.AwayTeam == teamName && match.FTHG == 0)
                    {
                        cleanSheats += 1;
                    }
                    numberOfMatches++;
                }
            }


            return (double)cleanSheats / numberOfMatches;
        }


        //Last H2H
        public string LastHomeH2HMatchResult(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => m.HomeTeam == teamName && m.AwayTeam == rival);
            if (h2hMatches.Count() == 0)
            {
                return "D";
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                if (lastMatch.FTR == "A")
                {
                    return "L";
                }
                else if (lastMatch.FTR == "D")
                {
                    return "D";
                }
                else
                {
                    return "W";
                }
            }
        }
        public double LastHomeH2HGoalsScored(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival) );
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsScoredHomePerMatch(teamName, date, 1);
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                return lastMatch.FTHG;

            }
        }
        public double LastHomeH2HGoalsConceded(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsScoredHomePerMatch(teamName, date, 1);
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                return lastMatch.FTAG;

            }
        }

        public string LastAwayH2HMatchResult(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return "D";
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                if (lastMatch.FTR == "A")
                {
                    return "W";
                }
                else if (lastMatch.FTR == "D")
                {
                    return "D";
                }
                else
                {
                    return "L";
                }
            }
        }
        public double LastAwayH2HGoalsScored(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsScoredAwayPerMatch(teamName, date, 1);
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                return lastMatch.FTAG;
            }
        }
        public double LastAwayH2HGoalsConceded(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsConcededAwayPerMatch(teamName, date, 1);
            }
            else
            {
                var lastMatch = h2hMatches.Last();
                return lastMatch.FTHG;
            }
        }

        //Last4H2H
        public double Last4HomeH2HAveragePoints(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAveragePointsHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count()>=4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int points = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.HomeTeam == teamName && match.FTR == "H")
                {
                    points += 3;
                }
                if (match.FTR == "D")
                {
                    points += 1;
                }
                numberOfMatches++;
            }
            return (double)points / numberOfMatches;

        }
        public double Last4HomeH2HWins(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsWinsHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int wins = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.HomeTeam == teamName && match.FTR == "H")
                {
                    wins += 1;
                }
                numberOfMatches++;
            }
            return (double)wins / numberOfMatches;

        }
        public double Last4HomeH2HDraws(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsDrawsHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int draws = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.HomeTeam == teamName && match.FTR == "D")
                {
                    draws += 1;
                }
                numberOfMatches++;
            }
            return (double)draws / numberOfMatches;

        }
        public double Last4HomeH2HLoses(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsLosesHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int loses = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.HomeTeam == teamName && match.FTR == "A")
                {
                    loses += 1;
                }
                numberOfMatches++;
            }
            return (double)loses / numberOfMatches;

        }

        public double Last4AwayH2HAveragePoints(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAveragePointsAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int points = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
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
            return (double)points / numberOfMatches;

        }
        public double Last4AwayH2HWins(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsWinsAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int wins = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.AwayTeam == teamName && match.FTR == "A")
                {
                    wins += 1;
                }
                numberOfMatches++;
            }
            return (double)wins / numberOfMatches;

        }
        public double Last4AwayH2HDraws(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsDrawsAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int draws = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.AwayTeam == teamName && match.FTR == "D")
                {
                    draws += 1;
                }
                numberOfMatches++;
            }
            return (double)draws / numberOfMatches;

        }
        public double Last4AwayH2HLoses(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsLosesAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int loses = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.AwayTeam == teamName && match.FTR == "H")
                {
                    loses += 1;
                }
                numberOfMatches++;
            }
            return (double)loses / numberOfMatches;

        }

        public double Last4HomeH2HGoalsScored(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsScoredHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int goals = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                goals += match.FTHG;
                numberOfMatches++;
            }
            return (double)goals / numberOfMatches;
        }
        public double Last4HomeH2HGoalsConceded(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsConcededHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int goals = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                goals += match.FTAG;
                numberOfMatches++;
            }
            return (double)goals / numberOfMatches;
        }

        public double Last4AwayH2HGoalsScored(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsScoredAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int goals = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                goals += match.FTAG;
                numberOfMatches++;
            }
            return (double)goals / numberOfMatches;
        }
        public double Last4AwayH2HGoalsConceded(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsAverageGoalsConcededAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int goals = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                goals += match.FTHG;
                numberOfMatches++;
            }
            return (double)goals / numberOfMatches;
        }

        public double Last4HomeH2HCleanSheats(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.HomeTeam == teamName && m.AwayTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsCleanSheatsHomePerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int cleanSheats = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.FTAG == 0)
                {
                    cleanSheats++;
                }
                numberOfMatches++;
            }
            return (double)cleanSheats / numberOfMatches;
        }
        public double Last4AwayH2HCleanSheats(string teamName, string rival, DateOnly date)
        {
            var matches = _csvReaderHelper.GetAllMatchesBeforeMatch(date);
            var h2hMatches = matches.Where(m => (m.AwayTeam == teamName && m.HomeTeam == rival));
            IEnumerable<Models.MatchCSV> last4h2hMatches = new List<Models.MatchCSV>();
            if (h2hMatches.Count() == 0)
            {
                return NSeasonsCleanSheatsAwayPerMatch(teamName, date, 2);
            }
            else if (h2hMatches.Count() >= 4)
            {
                last4h2hMatches = h2hMatches.TakeLast(4);
            }
            else
            {
                last4h2hMatches = h2hMatches.TakeLast(h2hMatches.Count());
            }
            int cleanSheats = 0;
            int numberOfMatches = 0;
            foreach (var match in last4h2hMatches)
            {
                if (match.FTHG == 0)
                {
                    cleanSheats++;
                }
                numberOfMatches++;
            }
            return (double)cleanSheats / numberOfMatches;
        }




    }
}

