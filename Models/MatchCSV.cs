namespace Engineering_Diploma_Project_Csharp.Models
{
    public class MatchCSV
    {
        public DateOnly Date { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public int FTHG { get; set; }
        public int FTAG { get; set; }
        public string FTR { get; set; } = string.Empty;
        public int HTHG { get; set; }
        public int HTAG { get; set; }
        public string HTR { get; set; } = string.Empty;
        public int HS { get; set; }
        public int AS { get; set; }
        public int HST { get; set; }
        public int AST { get; set; }
        public int HF { get; set; }
        public int AF { get; set; }
        public int HC { get; set; }
        public int AC { get; set; }
        public int HY { get; set; }
        public int AY { get; set; }
        public int HR { get; set; }
        public int AR { get; set; }
    }
}
