using CsvHelper.Configuration.Attributes;

namespace Engineering_Diploma_Project_Csharp.Models
{
    public class MatchStatsCSV
    {
        [Name("Id")]
        public int Id { get; set; }

        [Name("Date")]
        public DateOnly date { get; set; }


        //Home Team stats
        [Name("HomeTeam")]
        public string? HomeTeam { get; set; }

        //General stats:
        [Name("HomeTeamNumberOfSeasonsInPL")]
        public double HomeTeamNumberOfSeasonsInPL { get; set; }

        [Name("HomeTeamIsFromBigSix")]
        public int HomeTeamIsFromBigSix { get; set; }

        [Name("HomeTeamIsNewInPL")]
        public int HomeTeamIsNewInPL { get; set; }

        [Name("HomeTeamRedCardsInLastMatch")]
        public int HomeTeamRedCardsInLastMatch { get; set; }

        //Current season:
        [Name("HomeTeamCurrentSeasonPointsPerMatch")]
        public double HomeTeamCurrentSeasonPointsPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonPointsPerMatchHome")]
        public double HomeTeamCurrentSeasonPointsPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonWinsPerMatch")]
        public double HomeTeamCurrentSeasonWinsPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonWinsPerMatchHome")]
        public double HomeTeamCurrentSeasonWinsPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonDrawsPerMatch")]
        public double HomeTeamCurrentSeasonDrawsPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonDrawsPerMatchHome")]
        public double HomeTeamCurrentSeasonDrawsPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonLosesPerMatch")]
        public double HomeTeamCurrentSeasonLosesPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonLosesPerMatchHome")]
        public double HomeTeamCurrentSeasonLosesPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonGoalsScoredPerMatch")]
        public double HomeTeamCurrentSeasonGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonGoalsScoredPerMatchHome")]
        public double HomeTeamCurrentSeasonGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonGoalsConcededPerMatch")]
        public double HomeTeamCurrentSeasonGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonGoalsConcededPerMatchHome")]
        public double HomeTeamCurrentSeasonGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamCurrentSeasonCleanSheatsPerMatch")]
        public double HomeTeamCurrentSeasonCleanSheatsPerMatch { get; set; }

        [Name("HomeTeamCurrentSeasonCleanSheatsPerMatchHome")]
        public double HomeTeamCurrentSeasonCleanSheatsPerMatchHome { get; set; }

        // Last season

        [Name("HomeTeamLastSeasonPointsPerMatch")]
        public double HomeTeamLastSeasonPointsPerMatch { get; set; }

        [Name("HomeTeamLastSeasonPointsPerMatchHome")]
        public double HomeTeamLastSeasonPointsPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonWinsPerMatch")]
        public double HomeTeamLastSeasonWinsPerMatch { get; set; }

        [Name("HomeTeamLastSeasonWinsPerMatchHome")]
        public double HomeTeamLastSeasonWinsPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonDrawsPerMatch")]
        public double HomeTeamLastSeasonDrawsPerMatch { get; set; }

        [Name("HomeTeamLastSeasonDrawsPerMatchHome")]
        public double HomeTeamLastSeasonDrawsPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonLosesPerMatch")]
        public double HomeTeamLastSeasonLosesPerMatch { get; set; }

        [Name("HomeTeamLastSeasonLosesPerMatchHome")]
        public double HomeTeamLastSeasonLosesPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonGoalsScoredPerMatch")]
        public double HomeTeamLastSeasonGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamLastSeasonGoalsScoredPerMatchHome")]
        public double HomeTeamLastSeasonGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonGoalsConcededPerMatch")]
        public double HomeTeamLastSeasonGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamLastSeasonGoalsConcededPerMatchHome")]
        public double HomeTeamLastSeasonGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamLastSeasonCleanSheatsPerMatch")]
        public double HomeTeamLastSeasonCleanSheatsPerMatch { get; set; }

        [Name("HomeTeamLastSeasonCleanSheatsPerMatchHome")]
        public double HomeTeamLastSeasonCleanSheatsPerMatchHome { get; set; }

        // Last 3 seasons
        [Name("HomeTeamLast3SeasonsPointsPerMatch")]
        public double HomeTeamLast3SeasonsPointsPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsPointsPerMatchHome")]
        public double HomeTeamLast3SeasonsPointsPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsWinsPerMatch")]
        public double HomeTeamLast3SeasonsWinsPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsWinsPerMatchHome")]
        public double HomeTeamLast3SeasonsWinsPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsDrawsPerMatch")]
        public double HomeTeamLast3SeasonsDrawsPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsDrawsPerMatchHome")]
        public double HomeTeamLast3SeasonsDrawsPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsLosesPerMatch")]
        public double HomeTeamLast3SeasonsLosesPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsLosesPerMatchHome")]
        public double HomeTeamLast3SeasonsLosesPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsGoalsScoredPerMatch")]
        public double HomeTeamLast3SeasonsGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsGoalsScoredPerMatchHome")]
        public double HomeTeamLast3SeasonsGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsGoalsConcededPerMatch")]
        public double HomeTeamLast3SeasonsGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamLast3SeasonsGoalsConcededPerMatchHome")]
        public double HomeTeamLast3SeasonsGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamLast3SeasonsCleanSheatsPerMatch")]
        public double HomeTeamLast3SeasonsCleanSheatsPerMatch { get; set; }
         
        [Name("HomeTeamLast3SeasonsCleanSheatsPerMatchHome")]
        public double HomeTeamLast3SeasonsCleanSheatsPerMatchHome { get; set; }

        // Last 6 seasons
        [Name("HomeTeamLast6SeasonsPointsPerMatch")]
        public double HomeTeamLast6SeasonsPointsPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsPointsPerMatchHome")]
        public double HomeTeamLast6SeasonsPointsPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsWinsPerMatch")]
        public double HomeTeamLast6SeasonsWinsPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsWinsPerMatchHome")]
        public double HomeTeamLast6SeasonsWinsPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsDrawsPerMatch")]
        public double HomeTeamLast6SeasonsDrawsPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsDrawsPerMatchHome")]
        public double HomeTeamLast6SeasonsDrawsPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsLosesPerMatch")]
        public double HomeTeamLast6SeasonsLosesPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsLosesPerMatchHome")]
        public double HomeTeamLast6SeasonsLosesPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsGoalsScoredPerMatch")]
        public double HomeTeamLast6SeasonsGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsGoalsScoredPerMatchHome")]
        public double HomeTeamLast6SeasonsGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsGoalsConcededPerMatch")]
        public double HomeTeamLast6SeasonsGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsGoalsConcededPerMatchHome")]
        public double HomeTeamLast6SeasonsGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamLast6SeasonsCleanSheatsPerMatch")]
        public double HomeTeamLast6SeasonsCleanSheatsPerMatch { get; set; }

        [Name("HomeTeamLast6SeasonsCleanSheatsPerMatchHome")]
        public double HomeTeamLast6SeasonsCleanSheatsPerMatchHome { get; set; }

        // Last 9 seasons
        [Name("HomeTeamLast9SeasonsPointsPerMatch")]
        public double HomeTeamLast9SeasonsPointsPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsPointsPerMatchHome")]
        public double HomeTeamLast9SeasonsPointsPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsWinsPerMatch")]
        public double HomeTeamLast9SeasonsWinsPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsWinsPerMatchHome")]
        public double HomeTeamLast9SeasonsWinsPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsDrawsPerMatch")]
        public double HomeTeamLast9SeasonsDrawsPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsDrawsPerMatchHome")]
        public double HomeTeamLast9SeasonsDrawsPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsLosesPerMatch")]
        public double HomeTeamLast9SeasonsLosesPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsLosesPerMatchHome")]
        public double HomeTeamLast9SeasonsLosesPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsGoalsScoredPerMatch")]
        public double HomeTeamLast9SeasonsGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsGoalsScoredPerMatchHome")]
        public double HomeTeamLast9SeasonsGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsGoalsConcededPerMatch")]
        public double HomeTeamLast9SeasonsGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsGoalsConcededPerMatchHome")]
        public double HomeTeamLast9SeasonsGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamLast9SeasonsCleanSheatsPerMatch")]
        public double HomeTeamLast9SeasonsCleanSheatsPerMatch { get; set; }

        [Name("HomeTeamLast9SeasonsCleanSheatsPerMatchHome")]
        public double HomeTeamLast9SeasonsCleanSheatsPerMatchHome { get; set; }


        // Last 5 matches

        [Name("HomeTeamLast5MatchesPointsPerMatch")]
        public double HomeTeamLast5MatchesPointsPerMatch { get; set; }

        [Name("HomeTeamLast5MatchesWinsPerMatch")]
        public double HomeTeamLast5MatchesWinsPerMatch { get; set; }

        [Name("HomeTeamLast5MatchesDrawsPerMatch")]
        public double HomeTeamLast5MatchesDrawsPerMatch { get; set; }

        [Name("HomeTeamLast5MatchesLosesPerMatch")]
        public double HomeTeamLast5MatchesLosesPerMatch { get; set; }

        [Name("HomeTeamLast5MatchesGoalsScoredPerMatch")]
        public double HomeTeamLast5MatchesGoalsScoredPerMatch { get; set; }

        [Name("HomeTeamLast5MatchesGoalsConcededPerMatch")]
        public double HomeTeamLast5MatchesGoalsConcededPerMatch { get; set; }

        [Name("HomeTeamLast5MatcheCleanSheatsPerMatch")]
        public double HomeTeamLast5MatcheCleanSheatsPerMatch { get; set; }


        // Last H2H match

        [Name("HomeTeamLastH2HMatchResultHome")]
        public string HomeTeamLastH2HMatchResultHome{ get; set; }

        [Name("HomeTeamLastH2HMAtchGoalsScoredHome")]
        public double HomeTeamLastH2HMAtchGoalsScoredHome { get; set; }

        [Name("HomeTeamLastH2HMatchGoalsConcededHome")]
        public double HomeTeamLastH2HMatchGoalsConcededHome { get; set; }


        // Last 4 H2H matches
        [Name("HomeTeamLast4H2HMatchesPointsPerMatchHome")]
        public double HomeTeamLast4H2HMatchesPointsPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesWinsPerMatchHome")]
        public double HomeTeamLast4H2HMatchesWinsPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesDrawsPerMatchHome")]
        public double HomeTeamLast4H2HMatchesDrawsPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesLosesPerMatchHome")]
        public double HomeTeamLast4H2HMatchesLosesPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesGoalsScoredPerMatchHome")]
        public double HomeTeamLast4H2HMatchesGoalsScoredPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesGoalsConcededPerMatchHome")]
        public double HomeTeamLast4H2HMatchesGoalsConcededPerMatchHome { get; set; }

        [Name("HomeTeamLast4H2HMatchesCleanSheatsPerMatchHome")]
        public double HomeTeamLast4H2HMatchesCleanSheatsPerMatchHome { get; set; }


















        //Away Team stats:

        [Name("AwayTeam")]
        public string? AwayTeam { get; set; }

        //General stats:
        [Name("AwayTeamNumberOfSeasonsInPL")]
        public double AwayTeamNumberOfSeasonsInPL { get; set; }

        [Name("AwayTeamIsFromBigSix")]
        public int AwayTeamIsFromBigSix { get; set; }

        [Name("AwayTeamIsNewInPL")]
        public int AwayTeamIsNewInPL { get; set; }

        [Name("AwayTeamRedCardsInLastMatch")]
        public int AwayTeamRedCardsInLastMatch { get; set; }

        //Current season:
        [Name("AwayTeamCurrentSeasonPointsPerMatch")]
        public double AwayTeamCurrentSeasonPointsPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonPointsPerMatchAaway")]
        public double AwayTeamCurrentSeasonPointsPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonWinsPerMatch")]
        public double AwayTeamCurrentSeasonWinsPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonWinsPerMatchAway")]
        public double AwayTeamCurrentSeasonWinsPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonDrawsPerMatch")]
        public double AwayTeamCurrentSeasonDrawsPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonDrawsPerMatchAway")]
        public double AwayTeamCurrentSeasonDrawsPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonLosesPerMatch")]
        public double AwayTeamCurrentSeasonLosesPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonLosesPerMatchAway")]
        public double AwayTeamCurrentSeasonLosesPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonGoalsScoredPerMatch")]
        public double AwayTeamCurrentSeasonGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonGoalsScoredPerMatchAway")]
        public double AwayTeamCurrentSeasonGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonGoalsConcededPerMatch")]
        public double AwayTeamCurrentSeasonGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonGoalsConcededPerMatchAway")]
        public double AwayTeamCurrentSeasonGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamCurrentSeasonCleanSheatsPerMatch")]
        public double AwayTeamCurrentSeasonCleanSheatsPerMatch { get; set; }

        [Name("AwayTeamCurrentSeasonCleanSheatsPerMatchAway")]
        public double AwayTeamCurrentSeasonCleanSheatsPerMatchAway { get; set; }

        // Last season

        [Name("AwayTeamLastSeasonPointsPerMatch")]
        public double AwayTeamLastSeasonPointsPerMatch { get; set; }

        [Name("AwayTeamLastSeasonPointsPerMatchAaway")]
        public double AwayTeamLastSeasonPointsPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonWinsPerMatch")]
        public double AwayTeamLastSeasonWinsPerMatch { get; set; }

        [Name("AwayTeamLastSeasonWinsPerMatchAway")]
        public double AwayTeamLastSeasonWinsPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonDrawsPerMatch")]
        public double AwayTeamLastSeasonDrawsPerMatch { get; set; }

        [Name("AwayTeamLastSeasonDrawsPerMatchAway")]
        public double AwayTeamLastSeasonDrawsPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonLosesPerMatch")]
        public double AwayTeamLastSeasonLosesPerMatch { get; set; }

        [Name("AwayTeamLastSeasonLosesPerMatchAway")]
        public double AwayTeamLastSeasonLosesPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonGoalsScoredPerMatch")]
        public double AwayTeamLastSeasonGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamLastSeasonGoalsScoredPerMatchAway")]
        public double AwayTeamLastSeasonGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonGoalsConcededPerMatch")]
        public double AwayTeamLastSeasonGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamLastSeasonGoalsConcededPerMatchAway")]
        public double AwayTeamLastSeasonGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamLastSeasonCleanSheatsPerMatch")]
        public double AwayTeamLastSeasonCleanSheatsPerMatch { get; set; }

        [Name("AwayTeamLastSeasonCleanSheatsPerMatchAway")]
        public double AwayTeamLastSeasonCleanSheatsPerMatchAway { get; set; }

        // Last 3 seasons
        [Name("AwayTeamLast3SeasonsPointsPerMatch")]
        public double AwayTeamLast3SeasonsPointsPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsPointsPerMatchAaway")]
        public double AwayTeamLast3SeasonsPointsPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsWinsPerMatch")]
        public double AwayTeamLast3SeasonsWinsPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsWinsPerMatchAway")]
        public double AwayTeamLast3SeasonsWinsPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsDrawsPerMatch")]
        public double AwayTeamLast3SeasonsDrawsPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsDrawsPerMatchAway")]
        public double AwayTeamLast3SeasonsDrawsPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsLosesPerMatch")]
        public double AwayTeamLast3SeasonsLosesPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsLosesPerMatchAway")]
        public double AwayTeamLast3SeasonsLosesPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsGoalsScoredPerMatch")]
        public double AwayTeamLast3SeasonsGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsGoalsScoredPerMatchAway")]
        public double AwayTeamLast3SeasonsGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsGoalsConcededPerMatch")]
        public double AwayTeamLast3SeasonsGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsGoalsConcededPerMatchAway")]
        public double AwayTeamLast3SeasonsGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamLast3SeasonsCleanSheatsPerMatch")]
        public double AwayTeamLast3SeasonsCleanSheatsPerMatch { get; set; }

        [Name("AwayTeamLast3SeasonsCleanSheatsPerMatchAway")]
        public double AwayTeamLast3SeasonsCleanSheatsPerMatchAway { get; set; }

        // Last 6 seasons
        [Name("AwayTeamLast6SeasonsPointsPerMatch")]
        public double AwayTeamLast6SeasonsPointsPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsPointsPerMatchAaway")]
        public double AwayTeamLast6SeasonsPointsPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsWinsPerMatch")]
        public double AwayTeamLast6SeasonsWinsPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsWinsPerMatchAway")]
        public double AwayTeamLast6SeasonsWinsPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsDrawsPerMatch")]
        public double AwayTeamLast6SeasonsDrawsPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsDrawsPerMatchAway")]
        public double AwayTeamLast6SeasonsDrawsPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsLosesPerMatch")]
        public double AwayTeamLast6SeasonsLosesPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsLosesPerMatchAway")]
        public double AwayTeamLast6SeasonsLosesPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsGoalsScoredPerMatch")]
        public double AwayTeamLast6SeasonsGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsGoalsScoredPerMatchAway")]
        public double AwayTeamLast6SeasonsGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsGoalsConcededPerMatch")]
        public double AwayTeamLast6SeasonsGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsGoalsConcededPerMatchAway")]
        public double AwayTeamLast6SeasonsGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamLast6SeasonsCleanSheatsPerMatch")]
        public double AwayTeamLast6SeasonsCleanSheatsPerMatch { get; set; }

        [Name("AwayTeamLast6SeasonsCleanSheatsPerMatchAway")]
        public double AwayTeamLast6SeasonsCleanSheatsPerMatchAway { get; set; }

        // Last 9 seasons
        [Name("AwayTeamLast9SeasonsPointsPerMatch")]
        public double AwayTeamLast9SeasonsPointsPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsPointsPerMatchAaway")]
        public double AwayTeamLast9SeasonsPointsPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsWinsPerMatch")]
        public double AwayTeamLast9SeasonsWinsPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsWinsPerMatchAway")]
        public double AwayTeamLast9SeasonsWinsPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsDrawsPerMatch")]
        public double AwayTeamLast9SeasonsDrawsPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsDrawsPerMatchAway")]
        public double AwayTeamLast9SeasonsDrawsPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsLosesPerMatch")]
        public double AwayTeamLast9SeasonsLosesPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsLosesPerMatchAway")]
        public double AwayTeamLast9SeasonsLosesPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsGoalsScoredPerMatch")]
        public double AwayTeamLast9SeasonsGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsGoalsScoredPerMatchAway")]
        public double AwayTeamLast9SeasonsGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsGoalsConcededPerMatch")]
        public double AwayTeamLast9SeasonsGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsGoalsConcededPerMatchAway")]
        public double AwayTeamLast9SeasonsGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamLast9SeasonsCleanSheatsPerMatch")]
        public double AwayTeamLast9SeasonsCleanSheatsPerMatch { get; set; }

        [Name("AwayTeamLast9SeasonsCleanSheatsPerMatchAway")]
        public double AwayTeamLast9SeasonsCleanSheatsPerMatchAway { get; set; }


        // Last 5 matches

        [Name("AwayTeamLast5MatchesPointsPerMatch")]
        public double AwayTeamLast5MatchesPointsPerMatch { get; set; }

        [Name("AwayTeamLast5MatchesWinsPerMatch")]
        public double AwayTeamLast5MatchesWinsPerMatch { get; set; }

        [Name("AwayTeamLast5MatchesDrawsPerMatch")]
        public double AwayTeamLast5MatchesDrawsPerMatch { get; set; }

        [Name("AwayTeamLast5MatchesLosesPerMatch")]
        public double AwayTeamLast5MatchesLosesPerMatch { get; set; }

        [Name("AwayTeamLast5MatchesGoalsScoredPerMatch")]
        public double AwayTeamLast5MatchesGoalsScoredPerMatch { get; set; }

        [Name("AwayTeamLast5MatchesGoalsConcededPerMatch")]
        public double AwayTeamLast5MatchesGoalsConcededPerMatch { get; set; }

        [Name("AwayTeamLast5MatcheCleanSheatsPerMatch")]
        public double AwayTeamLast5MatcheCleanSheatsPerMatch { get; set; }


        // Last H2H match

        [Name("AwayTeamLastH2HMatchResultAway")]
        public string AwayTeamLastH2HMatchResultAway { get; set; }

        [Name("AwayTeamLastH2HMAtchGoalsScoredAway")]
        public double AwayTeamLastH2HMAtchGoalsScoredAway { get; set; }

        [Name("AwayTeamLastH2HMatchGoalsConcededAway")]
        public double AwayTeamLastH2HMatchGoalsConcededAway { get; set; }


        // Last 4 H2H matches
        [Name("AwayTeamLast4H2HMatchesPointsPerMatchAway")]
        public double AwayTeamLast4H2HMatchesPointsPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesWinsPerMatchAway")]
        public double AwayTeamLast4H2HMatchesWinsPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesDrawsPerMatchAway")]
        public double AwayTeamLast4H2HMatchesDrawsPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesLosesPerMatchAway")]
        public double AwayTeamLast4H2HMatchesLosesPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesGoalsScoredPerMatchAway")]
        public double AwayTeamLast4H2HMatchesGoalsScoredPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesGoalsConcededPerMatchAway")]
        public double AwayTeamLast4H2HMatchesGoalsConcededPerMatchAway { get; set; }

        [Name("AwayTeamLast4H2HMatchesCleanSheatsPerMatchAway")]
        public double AwayTeamLast4H2HMatchesCleanSheatsPerMatchAway { get; set; }
    }
}
