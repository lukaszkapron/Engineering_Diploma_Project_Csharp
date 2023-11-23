////// "../../../17_21_matches_stats.csv"
////using CsvHelper;
////using CsvHelper.Configuration.Attributes;
////using Engineering_Diploma_Project_Csharp;
////using Engineering_Diploma_Project_Csharp.Models;
////using System.Globalization;

////var matchesList = CSVReader.ReadMatches();
////Console.WriteLine(matchesList.Count());

////var results = new List<Stats>();
//using Engineering_Diploma_Project_Csharp;
//using Engineering_Diploma_Project_Csharp.Models;

//var matchStatsService = new MatchStatsService();
//var csvReader = new CSVReaderHelper();

//var stats = new List<MatchStatsCSV>();
//int id = 0;
//foreach (var match in csvReader.Matches)
//{
//    var homeTeamStats = new TeamStatsBeforeMatch
//    {
//        NumberOfSeasonsInPLPerSeason = matchStatsService.NumberOfSeasonsInPL(match.HomeTeam, match.Date),
//        IsFromBigSix = matchStatsService.IsBigSix(match.HomeTeam),
//        IsNewInPL = matchStatsService.IsNewInPL(match.HomeTeam, match.Date),
//        RedCardsInLastMatch = matchStatsService.NumberOfRedCardsInLastMatch(match.HomeTeam, match.Date),
//    };

//    var awayTeamStats = new TeamStatsBeforeMatch
//    {
//        NumberOfSeasonsInPLPerSeason = matchStatsService.NumberOfSeasonsInPL(match.AwayTeam, match.Date),
//        IsFromBigSix = matchStatsService.IsBigSix(match.AwayTeam),
//        IsNewInPL = matchStatsService.IsNewInPL(match.AwayTeam, match.Date),
//        RedCardsInLastMatch = matchStatsService.NumberOfRedCardsInLastMatch(match.AwayTeam, match.Date),
//    };

//    var matchStats = new MatchStatsCSV
//    {
//        Id = id,
//        AwayTeam = match.AwayTeam,
//        AwayIsFromBigSix = Convert.ToInt32(awayTeamStats.IsFromBigSix),
//        AwayIsNewInPL = Convert.ToInt32(awayTeamStats.IsNewInPL),
//        //AwayNumberOfSeasonsInPLPerSeason = awayTeamStats.NumberOfSeasonsInPLPerSeason,
//        AwayRedCardsInLastMatch = awayTeamStats.RedCardsInLastMatch,

//        HomeTeam = match.HomeTeam,
//        HomeIsFromBigSix = Convert.ToInt32(homeTeamStats.IsFromBigSix),
//        HomeIsNewInPL = Convert.ToInt32(homeTeamStats.IsNewInPL),
//        //HomeNumberOfSeasonsInPLPerSeason = homeTeamStats.NumberOfSeasonsInPLPerSeason,
//        HomeRedCardsInLastMatch = homeTeamStats.RedCardsInLastMatch,

//        FullTimeResult = match.FTR
//    };
//    stats.Add(matchStats);
//    id++;
//}


//var csvWriter = new CSVWriterHelper();
//csvWriter.WriteMatchesStats(stats, "output.csv");

using Engineering_Diploma_Project_Csharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("start");

var matchStatsService = new MatchStatsService();
var csvReader = new CSVReaderHelper();

var x = matchStatsService.Last5MatchesAveragePointsPerMatch("Watford", new DateOnly(2021, 09, 18));
Console.WriteLine(x);

