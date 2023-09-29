namespace Engineering_Diploma_Project_Csharp.Models
{
    // Original Data from 10 Last PL Seasons
    // Training model after preprocessing data from last 8 seasons in PL
    public class TeamStatsBeforeMatch
    {
            public int NumberOfSeasonsInPLPerSeason { get; set; }
            public bool IsNewInPL { get; set; }
            public bool IsFromBigSix { get; set; }
            public int RedCardsInLastMatch { get; set; } //Jeżeli pierwszy mecz w sezonie to 0;





        //or 5 seasons
        public int Last5SeasonsAveragePoints { get; set; }   //Jeżeli 3 ostatnie sezony drużyna grała to 3 ostatnie sezony
        public int Last5SeasonsWins { get; set; }           //Jeżeli 2 sezony z 3 to bierzemy 2 sezony i średni wynik beniaminków z brakującego sezonu
        public int Last5SeasonsDraws { get; set; }          //Jeżeli 1 sezon z 3 to bierzemy 1 sezon i średni wynik beniaminków z dwóch ostatnich sezonów
        public int LastSeasonsLoses { get; set; }          //Jeżeli beniaminek to bierzemy średni wynik beniaminków z trzech ostatnich sezonów

        public int Last5SeasonsAveragePointsHome { get; set; }  //Jeżeli 3 ostatnie sezony drużyna grała to 3 ostatnie sezony
        public int Last5SeasonsWinsHome { get; set; }           //Jeżeli 2 sezony z 3 to bierzemy 2 sezony i średni wynik beniaminków z brakującego sezonu
        public int Last5SeasonsDrawsHome { get; set; }          //Jeżeli 1 sezon z 3 to bierzemy 1 sezon i średni wynik beniaminków z dwóch ostatnich sezonów
        public int Last5SeasonsLosesHome { get; set; }          //Jeżeli beniaminek to bierzemy średni wynik beniaminków z trzech ostatnich sezonów

        public int Last5SeasonsAveragePointsAway { get; set; }  //Jeżeli 3 ostatnie sezony drużyna grała to 3 ostatnie sezony
        public int Last5SeasonsWinsAway { get; set; }           //Jeżeli 2 sezony z 3 to bierzemy 2 sezony i średni wynik beniaminków z brakującego sezonu
        public int Last5SeasonsDrawsAway { get; set; }          //Jeżeli 1 sezon z 3 to bierzemy 1 sezon i średni wynik beniaminków z dwóch ostatnich sezonów
        public int Last5SeasonsLosesAway { get; set; }          //Jeżeli beniaminek to bierzemy średni wynik beniaminków z trzech ostatnich sezonów

        public int Last5SeasonsAverageGoalsScored { get; set; }     //Jeżeli 3 ostatnie sezony drużyna grała to 3 ostatnie sezony
        public int Last5SeasonsAverageGoalsConceded { get; set; }   //Jeżeli 2 sezony z 3 to bierzemy 2 sezony i średni wynik beniaminków z brakującego sezonu
                                                                    //Jeżeli 1 sezon z 3 to bierzemy 1 sezon i średni wynik beniaminków z dwóch ostatnich sezonów
                                                                    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z trzech ostatnich sezonów

        public int Last5SeasonsCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu







            public int LastSeasonAveragePoints { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWins { get; set; }
            public int LastSeasonDraws { get; set; }
            public int LastSeasonLoses { get; set; }

            public int LastSeasonAveragePointsHome { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWinsHome { get; set; } 
            public int LastSeasonDrawsHome { get; set; }
            public int LastSeasonLosesHome { get; set; }

            public int LastSeasonAveragePointsAway { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWinsAway { get; set; } 
            public int LastSeasonDrawsAway { get; set; }
            public int LastSeasonLosesAway { get; set; }

            public int LastSeasonAverageGoalsScored { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonAverageGoalsConceded { get; set; }

            public int LastSeasonCleanSheats { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu







        public double CurrentSeasonAveragePoints { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu
                                                                //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu

        public int CurrentSeasonAverageGoalsScored { get; set; } //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu
        public int CurrentSeasonsAverageGoalsConceded { get; set; } //Jeżeli drużyna jest beniaminkiem do bierzemy średni wynik beniaminkow z poprzedniego sezonu




        public int Last5MatchesAveragePointsFromCurrentSeason { get; set; }     //Jeżeli w obecnym sezonie jeszcze nie zostało rozegrane 5 meczów to bierzemy
        public int Last5MatchesWinsFromCurrentSeason { get; set; }              //średni wynik z całego poprzedniego sezonu
        public int Last5MatchesDrawsFromCurrentSeason { get; set; }             //Jeżeli drużyna jest beniaminkiem to bierzemy 
        public int Last5MatchesLosesFromCurrentSeason { get; set; }             //średni wynik beniaminków z poprzedniego

        public int Last5MatchesAverageGoalsScored { get; set; }     //Jeżeli w obecnym sezonie jeszcze nie zostało rozegrane 5 meczów to bierzemy 
        public int Last5MatchesAverageGoalsConceded { get; set; }   //średni wynik z całego poprzedniego sezonu
                                                                    //Jeżeli drużyna jest beniaminkiem to bierzemy 
                                                                    //średni wynik beniaminków z poprzednieg
                                                                    //o
        public int Last5MatchesCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu








                                                                             




            public int LastH2HMatchResult { get; set; }     //Jeżeli drużyny jeszcze nie grały ze sobą to CHYBA "D"
            public int LastH2HGoalsScored { get; set; }         //Zastanowić się co zrobić jeżeli w obecnym i poprzednim sezonie drużyny nie grały ze soba?
            public int LastH2HGoalsConceded { get; set; }       // Albo wziąc wynik h2h albo to co wyżej

        public int Last4H2HMatchAveragePoints { get; set; }     //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        //public int Last4H2HMatchWins { get; set; }        
        //public int Last4H2HMatchDraws { get; set; }
        //public int Last4H2HMatchLoses { get; set; }

        public int Last4H2HGoalsScored { get; set; }        //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        public int Last4H2HGoalsConceded { get; set; }

        public int Lastt4H2HCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu




        //Should be considered?
        public int DaysFromLastMatch { get; set; } //Jeżeli pierwszy mecz to CHYBA max days
        public int AverageShotsOnTarget { get; set; }

    }
}
