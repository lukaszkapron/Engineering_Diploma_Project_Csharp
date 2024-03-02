namespace Engineering_Diploma_Project_Csharp
{
    internal class DataVisualizations
    {
        private readonly CSVReaderHelper _csvReaderHelper;

        public DataVisualizations()
        {
            _csvReaderHelper = new CSVReaderHelper();

        }

        public int CountDifferentTeams()
        {
            var allMatches = _csvReaderHelper.Matches;
            Console.WriteLine(allMatches.Count());

            List<string> teams = new();
            foreach (var match in allMatches)
            {
                if (!teams.Contains(match.HomeTeam))
                {
                    teams.Add(match.HomeTeam);
                }
            }
            return teams.Count();
        }

        public void GetTeamsNumberOfSeasons()
        {
            var allMatches = _csvReaderHelper.Matches;

            var groupedMatches = allMatches.GroupBy(d => d.HomeTeam).ToList();
            foreach (var item in groupedMatches)
            {
                Console.WriteLine(item.Key + "\t" + item.Count() / 19);
            }
        }
    }
}
