using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Engineering_Diploma_Project_Csharp
{
    internal class MatchStatsService
    {
        private readonly CSVReaderHelper _csvReaderHelper;

        public MatchStatsService()
        {
            _csvReaderHelper = new CSVReaderHelper();
        }
        

        public int NumberOfSeasonsInPLPerSeason(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);

            int seasonsCount = 0;
            foreach (var season in seasonsWithCurrentSeason)
            {
                if (season.Any(m => m.HomeTeam == teamName))
                {
                    seasonsCount++;
                }
            }
            return seasonsCount;
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


        //  Liczenie do 2 rozdziału pracy

        public int CountDifferentTeams()
        {
            var allMatches = _csvReaderHelper.GetAllMatches();
            Console.WriteLine(allMatches.Count());

            List<string> teams = new();
            foreach ( var match in allMatches)
            {
                if (!teams.Contains(match.HomeTeam))
                {
                    teams.Add(match.HomeTeam);
                }
            }
            return teams.Count();
        }

        public void GetTemasNumberOfSeasons()
        {
            var allMatches = _csvReaderHelper.GetAllMatches();

            var groupedMatches = allMatches.GroupBy(d=>d.HomeTeam).ToList();
            foreach (var item in groupedMatches)
            {
                Console.WriteLine(item.Key + "\t" + item.Count()/19);
            }
        }



        // NewComers

        public List<string>? GetNewComersFromLastSeason(DateOnly date)
        {
            var returnList = new List<string>();
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2)
            {
                return null;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
            foreach (var match in lastSeason.GroupBy(w=>w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 1, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            return returnList;

        }

        public List<string>? GetNewComersFromLast3Seasons(DateOnly date)
        {
            var returnList = new List<string>();
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 4)
            {
                return null;
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 1, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year-2, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 3, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            return returnList;

        }

        public List<string>? GetNewComersFromLast5Seasons(DateOnly date)
        {
            var returnList = new List<string>();
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 6)
            {
                return null;
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 1, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 2, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 3, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 5].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 4, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 6].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 5, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            return returnList;

        }

        public List<string>? GetNewComersFromLast10Seasons(DateOnly date)
        {
            var returnList = new List<string>();
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 11)
            {
                return null;
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 1, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 2, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 3, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 5].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 4, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 6].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 5, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 7].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 6, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 8].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 7, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 9].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 8, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 10].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 9, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            foreach (var match in seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 11].GroupBy(w => w.HomeTeam))
            {
                if (IsNewInPL(match.Key, new DateOnly(date.Year - 10, date.Month, date.Day)))
                {
                    returnList.Add(match.Key);
                }
            }
            return returnList;

        }



        // Ready functions:

        // LastSeason:
        public double LastSeasonAveragePointsPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            int points = 0;
            int numberOfMatches = 0;
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

                return (double)points / numberOfMatches;
        }
        public double LastSeasonAveragePointsHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)points / numberOfMatches;
        }
        public double LastSeasonAveragePointsAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)points / numberOfMatches;
        }

        public double LastSeasonWinsPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)wins / numberOfMatches;
        }
        public double LastSeasonWinsHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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
                foreach (var match in lastSeason)
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
        public double LastSeasonWinsAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int wins = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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
                foreach (var match in lastSeason)
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

        public double LastSeasonDrawsPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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
                foreach (var match in lastSeason)
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
        public double LastSeasonDrawsHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
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

            return (double)draws / numberOfMatches;
        }
        public double LastSeasonDrawsAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int draws = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
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

            return (double)draws / numberOfMatches;
        }

        public double LastSeasonLosesPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)loses / numberOfMatches;
        }
        public double LastSeasonLosesHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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
                foreach (var match in lastSeason)
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
        public double LastSeasonLosesAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int loses = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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
                foreach (var match in lastSeason)
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

        public double LastSeasonAverageGoalsScoredPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)goals / numberOfMatches;
        }
        public double LastSeasonAverageGoalsConcededPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)goals / numberOfMatches;
        }

        public double LastSeasonAverageGoalsScoredHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)goals / numberOfMatches;
        }
        public double LastSeasonAverageGoalsConcededHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)goals / numberOfMatches;
        }

        public double LastSeasonAverageGoalsScoredAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
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

            return (double)goals / numberOfMatches;
        }
        public double LastSeasonAverageGoalsConcededAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int goals = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
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

            return (double)goals / numberOfMatches;
        }

        public double LastSeasonCleanSheatsPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int cleanSheats = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            return (double)cleanSheats / numberOfMatches;
        }
        public double LastSeasonCleanSheatsHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int cleanSheats = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
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

            return (double)cleanSheats / numberOfMatches;
        }
        public double LastSeasonCleanSheatsAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int cleanSheats = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(date);
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2];
                    var newComerMatchesInLastSeason = lastSeasonAllMatches.Where(m =>m.AwayTeam == newComer);
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

            return (double)cleanSheats / numberOfMatches;
        }




        public double Last3SeasonsAveragePointsPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 4)
            {
                return 0;
            }

            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0)
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

            var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

            if (lastSeason2.Count() == 0)
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year-1, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
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
                foreach (var match in lastSeason2)
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

            var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

            if (lastSeason3.Count() == 0)
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 2, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
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
                foreach (var match in lastSeason3)
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
        public double Last3SeasonsAveragePointsHomePerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.HomeTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.HomeTeam == teamName);

            if (lastSeason2.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year -1, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
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
                foreach (var match in lastSeason2)
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

            var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.HomeTeam == teamName);

            if (lastSeason3.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - 2, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
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
                foreach (var match in lastSeason3)
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
        public double Last3SeasonsAveragePointsAwayPerMatch(string teamName, DateOnly date)
        {
            var seasonsWithCurrentSeason = _csvReaderHelper.GetSeasonsWithCurrentSeason(date);
            if (seasonsWithCurrentSeason.Count < 2) // jeżeli sezon 03/04 to 0
            {
                return 0;
            }
            var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 2].Where(m => m.AwayTeam == teamName);
            int points = 0;
            int numberOfMatches = 0;

            if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
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

            var lastSeason2 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3].Where(m => m.AwayTeam == teamName);

            if (lastSeason2.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year-1, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 3];
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
                foreach (var match in lastSeason2)
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

            var lastSeason3 = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4].Where(m => m.AwayTeam == teamName);

            if (lastSeason3.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            {
                var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year-2, date.Month, date.Day));
                foreach (var newComer in newComersFromLastSeason!)
                {
                    var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - 4];
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
                foreach (var match in lastSeason3)
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
                var lastSeason = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i+2)].Where(m => m.HomeTeam == teamName || m.AwayTeam == teamName);

                if (lastSeason.Count() == 0) //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
                {
                    var newComersFromLastSeason = GetNewComersFromLastSeason(new DateOnly(date.Year - i, date.Month, date.Day));
                    foreach (var newComer in newComersFromLastSeason!)
                    {
                        var lastSeasonAllMatches = seasonsWithCurrentSeason[seasonsWithCurrentSeason.Count - (i+2)];
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
    }
}

