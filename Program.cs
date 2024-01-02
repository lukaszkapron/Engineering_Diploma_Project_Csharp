//// "../../../17_21_matches_stats.csv"
//using CsvHelper;
//using CsvHelper.Configuration.Attributes;
//using Engineering_Diploma_Project_Csharp;
//using Engineering_Diploma_Project_Csharp.Models;
//using System.Globalization;

//var matchesList = CSVReader.ReadMatches();
//Console.WriteLine(matchesList.Count());

//var results = new List<Stats>();
using Engineering_Diploma_Project_Csharp;
using Engineering_Diploma_Project_Csharp.Models;
using System.Diagnostics;

var matchStatsService = new MatchStatsService();
var csvReader = new CSVReaderHelper();

var stats = new List<MatchStatsCSV>();
int id = 0;
var watch = new Stopwatch();
watch.Start();
foreach (var match in csvReader.Matches.Skip(380 * 9))
{
    Console.WriteLine(id);
    Console.WriteLine(watch.ElapsedMilliseconds / 1000 + " s");
    var matchStats = new MatchStatsCSV
    {
        //Id = id,
        //date = match.Date,

        //HomeTeam = match.HomeTeam,
        //HomeTeamNumberOfSeasonsInPL = matchStatsService.NumberOfSeasonsInPLPerSeason(match.HomeTeam, match.Date),
        //HomeTeamIsFromBigSix = Convert.ToInt32(matchStatsService.IsBigSix(match.HomeTeam)),
        //HomeTeamIsNewInPL = Convert.ToInt32(matchStatsService.IsNewInPL(match.HomeTeam, match.Date)),
        //HomeTeamRedCardsInLastMatch = matchStatsService.NumberOfRedCardsInLastMatch(match.HomeTeam, match.Date),

        //HomeTeamCurrentSeasonPointsPerMatch = matchStatsService.CurrentSeasonAveragePointsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonPointsPerMatchHome = matchStatsService.CurrentSeasonAveragePointsHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonWinsPerMatch = matchStatsService.CurrentSeasonWinsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonWinsPerMatchHome = matchStatsService.CurrentSeasonWinsHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonDrawsPerMatch = matchStatsService.CurrentSeasonDrawsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonDrawsPerMatchHome = matchStatsService.CurrentSeasonDrawsHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonLosesPerMatch = matchStatsService.CurrentSeasonLosesPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonLosesPerMatchHome = matchStatsService.CurrentSeasonLosesHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonGoalsScoredPerMatch = matchStatsService.CurrentSeasonAverageGoalsScoredPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonGoalsScoredPerMatchHome = matchStatsService.CurrentSeasonAverageGoalsScoredHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonGoalsConcededPerMatch = matchStatsService.CurrentSeasonAverageGoalsConcededPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonGoalsConcededPerMatchHome = matchStatsService.CurrentSeasonAverageGoalsConcededHomePerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonCleanSheatsPerMatch = matchStatsService.CurrentSeasonCleanSheatsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamCurrentSeasonCleanSheatsPerMatchHome = matchStatsService.CurrentSeasonCleanSheatsHomePerMatch(match.HomeTeam, match.Date),

        //HomeTeamLastSeasonPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonPointsPerMatchHome = matchStatsService.NSeasonsAveragePointsHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonWinsPerMatchHome = matchStatsService.NSeasonsWinsHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonDrawsPerMatchHome = matchStatsService.NSeasonsDrawsHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonLosesPerMatchHome = matchStatsService.NSeasonsLosesHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonGoalsScoredPerMatchHome = matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonGoalsConcededPerMatchHome = matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.HomeTeam, match.Date, 1),
        //HomeTeamLastSeasonCleanSheatsPerMatchHome = matchStatsService.NSeasonsCleanSheatsHomePerMatch(match.HomeTeam, match.Date, 1),

        //HomeTeamLast3SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsPointsPerMatchHome = matchStatsService.NSeasonsAveragePointsHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsWinsPerMatchHome = matchStatsService.NSeasonsWinsHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsDrawsPerMatchHome = matchStatsService.NSeasonsDrawsHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsLosesPerMatchHome = matchStatsService.NSeasonsLosesHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsGoalsScoredPerMatchHome = matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsGoalsConcededPerMatchHome = matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.HomeTeam, match.Date, 3),
        //HomeTeamLast3SeasonsCleanSheatsPerMatchHome = matchStatsService.NSeasonsCleanSheatsHomePerMatch(match.HomeTeam, match.Date, 3),

        //HomeTeamLast6SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsPointsPerMatchHome = matchStatsService.NSeasonsAveragePointsHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsWinsPerMatchHome = matchStatsService.NSeasonsWinsHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsDrawsPerMatchHome = matchStatsService.NSeasonsDrawsHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsLosesPerMatchHome = matchStatsService.NSeasonsLosesHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsGoalsScoredPerMatchHome = matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsGoalsConcededPerMatchHome = matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.HomeTeam, match.Date, 6),
        //HomeTeamLast6SeasonsCleanSheatsPerMatchHome = matchStatsService.NSeasonsCleanSheatsHomePerMatch(match.HomeTeam, match.Date, 6),

        //HomeTeamLast9SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsPointsPerMatchHome = matchStatsService.NSeasonsAveragePointsHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsWinsPerMatchHome = matchStatsService.NSeasonsWinsHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsDrawsPerMatchHome = matchStatsService.NSeasonsDrawsHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsLosesPerMatchHome = matchStatsService.NSeasonsLosesHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsGoalsScoredPerMatchHome = matchStatsService.NSeasonsAverageGoalsScoredHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsGoalsConcededPerMatchHome = matchStatsService.NSeasonsAverageGoalsConcededHomePerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.HomeTeam, match.Date, 9),
        //HomeTeamLast9SeasonsCleanSheatsPerMatchHome = matchStatsService.NSeasonsCleanSheatsHomePerMatch(match.HomeTeam, match.Date, 9),

        //HomeTeamLast5MatchesPointsPerMatch = matchStatsService.Last5MatchesAveragePointsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatchesWinsPerMatch = matchStatsService.Last5MatchesWinsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatchesDrawsPerMatch = matchStatsService.Last5MatchesDrawsPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatchesLosesPerMatch = matchStatsService.Last5MatchesLosesPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatchesGoalsScoredPerMatch = matchStatsService.Last5MatchesAverageGoalsScoredPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatchesGoalsConcededPerMatch = matchStatsService.Last5MatchesAverageGoalsConcededPerMatch(match.HomeTeam, match.Date),
        //HomeTeamLast5MatcheCleanSheatsPerMatch = matchStatsService.Last5MatchesCleanSheatsPerMatch(match.HomeTeam, match.Date),

        //HomeTeamLastH2HMatchResultHome = matchStatsService.LastHomeH2HMatchResult(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLastH2HMAtchGoalsScoredHome = matchStatsService.LastHomeH2HGoalsScored(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLastH2HMatchGoalsConcededHome = matchStatsService.LastHomeH2HGoalsConceded(match.HomeTeam, match.AwayTeam, match.Date),

        //HomeTeamLast4H2HMatchesPointsPerMatchHome = matchStatsService.Last4HomeH2HAveragePoints(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesWinsPerMatchHome = matchStatsService.Last4HomeH2HWins(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesDrawsPerMatchHome = matchStatsService.Last4HomeH2HDraws(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesLosesPerMatchHome = matchStatsService.Last4HomeH2HLoses(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesGoalsScoredPerMatchHome = matchStatsService.Last4HomeH2HGoalsScored(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesGoalsConcededPerMatchHome = matchStatsService.Last4HomeH2HGoalsConceded(match.HomeTeam, match.AwayTeam, match.Date),
        //HomeTeamLast4H2HMatchesCleanSheatsPerMatchHome = matchStatsService.Last4HomeH2HCleanSheats(match.HomeTeam, match.AwayTeam, match.Date),






        //AwayTeam = match.AwayTeam,
        //AwayTeamNumberOfSeasonsInPL = matchStatsService.NumberOfSeasonsInPLPerSeason(match.AwayTeam, match.Date),
        //AwayTeamIsFromBigSix = Convert.ToInt32(matchStatsService.IsBigSix(match.AwayTeam)),
        //AwayTeamIsNewInPL = Convert.ToInt32(matchStatsService.IsNewInPL(match.AwayTeam, match.Date)),
        //AwayTeamRedCardsInLastMatch = matchStatsService.NumberOfRedCardsInLastMatch(match.AwayTeam, match.Date),

        //AwayTeamCurrentSeasonPointsPerMatch = matchStatsService.CurrentSeasonAveragePointsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonPointsPerMatchAway = matchStatsService.CurrentSeasonAveragePointsAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonWinsPerMatch = matchStatsService.CurrentSeasonWinsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonWinsPerMatchAway = matchStatsService.CurrentSeasonWinsAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonDrawsPerMatch = matchStatsService.CurrentSeasonDrawsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonDrawsPerMatchAway = matchStatsService.CurrentSeasonDrawsAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonLosesPerMatch = matchStatsService.CurrentSeasonLosesPerMatch(match.AwayTeam, match.Date),
        AwayTeamCurrentSeasonLosesPerMatchAway = matchStatsService.CurrentSeasonLosesAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonGoalsScoredPerMatch = matchStatsService.CurrentSeasonAverageGoalsScoredPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonGoalsScoredPerMatchAway = matchStatsService.CurrentSeasonAverageGoalsScoredAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonGoalsConcededPerMatch = matchStatsService.CurrentSeasonAverageGoalsConcededPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonGoalsConcededPerMatchAway = matchStatsService.CurrentSeasonAverageGoalsConcededAwayPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonCleanSheatsPerMatch = matchStatsService.CurrentSeasonCleanSheatsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamCurrentSeasonCleanSheatsPerMatchAway = matchStatsService.CurrentSeasonCleanSheatsAwayPerMatch(match.AwayTeam, match.Date),

        //AwayTeamLastSeasonPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonPointsPerMatchAway = matchStatsService.NSeasonsAveragePointsAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonWinsPerMatchAway = matchStatsService.NSeasonsWinsAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonDrawsPerMatchAway = matchStatsService.NSeasonsDrawsAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonLosesPerMatchAway = matchStatsService.NSeasonsLosesAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonGoalsScoredPerMatchAway = matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonGoalsConcededPerMatchAway = matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.AwayTeam, match.Date, 1),
        //AwayTeamLastSeasonCleanSheatsPerMatchAway = matchStatsService.NSeasonsCleanSheatsAwayPerMatch(match.AwayTeam, match.Date, 1),

        //AwayTeamLast3SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsPointsPerMatchAway = matchStatsService.NSeasonsAveragePointsAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsWinsPerMatchAway = matchStatsService.NSeasonsWinsAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsDrawsPerMatchAway = matchStatsService.NSeasonsDrawsAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsLosesPerMatchAway = matchStatsService.NSeasonsLosesAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsGoalsScoredPerMatchAway = matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsGoalsConcededPerMatchAway = matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.AwayTeam, match.Date, 3),
        //AwayTeamLast3SeasonsCleanSheatsPerMatchAway = matchStatsService.NSeasonsCleanSheatsAwayPerMatch(match.AwayTeam, match.Date, 3),

        //AwayTeamLast6SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsPointsPerMatchAway = matchStatsService.NSeasonsAveragePointsAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsWinsPerMatchAway = matchStatsService.NSeasonsWinsAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsDrawsPerMatchAway = matchStatsService.NSeasonsDrawsAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsLosesPerMatchAway = matchStatsService.NSeasonsLosesAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsGoalsScoredPerMatchAway = matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsGoalsConcededPerMatchAway = matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.AwayTeam, match.Date, 6),
        //AwayTeamLast6SeasonsCleanSheatsPerMatchAway = matchStatsService.NSeasonsCleanSheatsAwayPerMatch(match.AwayTeam, match.Date, 6),

        //AwayTeamLast9SeasonsPointsPerMatch = matchStatsService.NSeasonsAveragePointsPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsPointsPerMatchAway = matchStatsService.NSeasonsAveragePointsAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsWinsPerMatch = matchStatsService.NSeasonsWinsPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsWinsPerMatchAway = matchStatsService.NSeasonsWinsAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsDrawsPerMatch = matchStatsService.NSeasonsDrawsPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsDrawsPerMatchAway = matchStatsService.NSeasonsDrawsAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsLosesPerMatch = matchStatsService.NSeasonsLosesPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsLosesPerMatchAway = matchStatsService.NSeasonsLosesAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsGoalsScoredPerMatch = matchStatsService.NSeasonsAverageGoalsScoredPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsGoalsScoredPerMatchAway = matchStatsService.NSeasonsAverageGoalsScoredAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsGoalsConcededPerMatch = matchStatsService.NSeasonsAverageGoalsConcededPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsGoalsConcededPerMatchAway = matchStatsService.NSeasonsAverageGoalsConcededAwayPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsCleanSheatsPerMatch = matchStatsService.NSeasonsCleanSheatsPerMatch(match.AwayTeam, match.Date, 9),
        //AwayTeamLast9SeasonsCleanSheatsPerMatchAway = matchStatsService.NSeasonsCleanSheatsAwayPerMatch(match.AwayTeam, match.Date, 9),

        //AwayTeamLast5MatchesPointsPerMatch = matchStatsService.Last5MatchesAveragePointsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatchesWinsPerMatch = matchStatsService.Last5MatchesWinsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatchesDrawsPerMatch = matchStatsService.Last5MatchesDrawsPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatchesLosesPerMatch = matchStatsService.Last5MatchesLosesPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatchesGoalsScoredPerMatch = matchStatsService.Last5MatchesAverageGoalsScoredPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatchesGoalsConcededPerMatch = matchStatsService.Last5MatchesAverageGoalsConcededPerMatch(match.AwayTeam, match.Date),
        //AwayTeamLast5MatcheCleanSheatsPerMatch = matchStatsService.Last5MatchesCleanSheatsPerMatch(match.AwayTeam, match.Date),

        //AwayTeamLastH2HMatchResultAway = matchStatsService.LastAwayH2HMatchResult(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLastH2HMAtchGoalsScoredAway = matchStatsService.LastAwayH2HGoalsScored(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLastH2HMatchGoalsConcededAway = matchStatsService.LastAwayH2HGoalsConceded(match.AwayTeam, match.HomeTeam, match.Date),

        //AwayTeamLast4H2HMatchesPointsPerMatchAway = matchStatsService.Last4AwayH2HAveragePoints(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesWinsPerMatchAway = matchStatsService.Last4AwayH2HWins(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesDrawsPerMatchAway = matchStatsService.Last4AwayH2HDraws(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesLosesPerMatchAway = matchStatsService.Last4AwayH2HLoses(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesGoalsScoredPerMatchAway = matchStatsService.Last4AwayH2HGoalsScored(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesGoalsConcededPerMatchAway = matchStatsService.Last4AwayH2HGoalsConceded(match.AwayTeam, match.HomeTeam, match.Date),
        //AwayTeamLast4H2HMatchesCleanSheatsPerMatchAway = matchStatsService.Last4AwayH2HCleanSheats(match.AwayTeam, match.HomeTeam, match.Date),
    };
    stats.Add(matchStats);
    id++;
}


var csvWriter = new CSVWriterHelper();
csvWriter.WriteMatchesStats(stats, "output_only.csv");

//using Engineering_Diploma_Project_Csharp;

//Console.WriteLine("start");

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
//    var pointrs = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2021, 12, 12), 1);
//    Console.WriteLine(pointrs);
//}
//foreach (var newcomer in newcomers2)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2021, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//    var pointrs = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2020, 12, 12), 1);
//    Console.WriteLine(pointrs);
//}
//foreach (var newcomer in newcomers3)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2020, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//    var pointrs = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2019, 12, 12), 1);
//    Console.WriteLine(pointrs);
//}
//foreach (var newcomer in newcomers4)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2019, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//    var pointrs = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2018, 12, 12), 1);
//    Console.WriteLine(pointrs);
//}
//foreach (var newcomer in newcomers5)
//{
//    var points = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2018, 12, 12), 1); // avg punkty w sezonie 2021/22
//    Console.WriteLine(newcomer);
//    Console.WriteLine(points);
//    var pointrs = matchStatsService.NSeasonsAveragePointsPerMatch(newcomer, new DateOnly(2017, 12, 12), 1);
//    Console.WriteLine(pointrs);
//}
