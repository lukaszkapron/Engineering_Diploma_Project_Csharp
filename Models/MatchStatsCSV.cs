using CsvHelper.Configuration.Attributes;

namespace Engineering_Diploma_Project_Csharp.Models
{
    public class MatchStatsCSV
    {
        [Name("Id")]
        public int Id { get; set; }

        [Name("HomeTeam")]
        public string? HomeTeam { get; set; }

        //[Name("HomeNumberOfSeasonsInPLPerSeason")]
        //public int HomeNumberOfSeasonsInPLPerSeason { get; set; }

        [Name("HomeIsFromBigSix")]
        public int HomeIsFromBigSix { get; set; }

        [Name("HomeIsNewInPL")]
        public int HomeIsNewInPL { get; set; }

        [Name("HomeRedCardsInLastMatch")]
        public int HomeRedCardsInLastMatch { get; set; }


        [Name("AwayTeam")]
        public string? AwayTeam { get; set; }

        //[Name("AwayNumberOfSeasonsInPLPerSeason")]
        //public int AwayNumberOfSeasonsInPLPerSeason { get; set; }

        [Name("AwayIsFromBigSix")]
        public int AwayIsFromBigSix { get; set; }

        [Name("AwayIsNewInPL")]
        public int AwayIsNewInPL { get; set; }

        [Name("AwayRedCardsInLastMatch")]
        public int AwayRedCardsInLastMatch { get; set; }


        [Name("FullTimeResult")]
        public string FullTimeResult { get; set; }
    }
}
