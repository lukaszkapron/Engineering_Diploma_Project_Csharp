namespace Engineering_Diploma_Project_Csharp.Models
{
    // Original Data from 20 Last PL Seasons
    // Training model after preprocessing data from last 10 seasons in PL
    public class TeamStatsBeforeMatch
    {
            public int NumberOfSeasonsInPLPerSeason { get; set; }
            public bool IsNewInPL { get; set; }
            public bool IsFromBigSix { get; set; }
            public int RedCardsInLastMatch { get; set; } //Jeżeli pierwszy mecz w sezonie to 0



        // Last 10 seasons:

        // Last 5 seasons:
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

        public int Last5SeasonsRedCards { get; set; }






        // Last 1 season
            public int LastSeasonAveragePointsPerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWinsPerMatch { get; set; }
            public int LastSeasonDrawsPerMatch { get; set; }
            public int LastSeasonLosesPerMatch { get; set; }

            public int LastSeasonAveragePointsHomePerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWinsHomePerMatch { get; set; } 
            public int LastSeasonDrawsHomePerMatch { get; set; }
            public int LastSeasonLosesHomePerMatch { get; set; }

            public int LastSeasonAveragePointsAwayPerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int LastSeasonWinsAwayPerMatch { get; set; } 
            public int LastSeasonDrawsAwayPerMatch { get; set; }
            public int LastSeasonLosesAwayPerMatch { get; set; }

            public int LastSeasonAverageGoalsScoredPerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonAverageGoalsConcededPerMatch { get; set; }

            public int LastSeasonAverageGoalsScoredHomePerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonAverageGoalsConcededHomePerMatch { get; set; }

            public int LastSeasonAverageGoalsScoredAwayPerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonAverageGoalsConcededAwayPerMatch { get; set; }

            public int LastSeasonCleanSheatsPerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonCleanSheatsHomePerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int LastSeasonCleanSheatsAwayPerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu

        public int LastSeasonRedCardsPerMatch { get; set; }





        // Current season
            public double CurrentSeasonAveragePointsPerMatch { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu
                                                                    //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu 

            public int CurrentSeasonWinsPerMatch { get; set; }
            public int CurrentSeasonDrawsPerMatch { get; set; }
            public int CurrentSeasonLosesPerMatch { get; set; }

            public int CurrentSeasonAveragePointsHomePerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int CurrentSeasonWinsHomePerMatch { get; set; }
            public int CurrentSeasonDrawsHomePerMatch { get; set; }
            public int CurrentSeasonLosesHomePerMatch { get; set; }

            public int CurrentSeasonAveragePointsAwayPerMatch { get; set; }    //Jeżeli beniaminek to bierzemy średni wynik beniaminków z ostatniego sezonu
            public int CurrentSeasonWinsAwayPerMatch { get; set; }
            public int CurrentSeasonDrawsAwayPerMatch { get; set; }
            public int CurrentSeasonLosesAwayPerMatch { get; set; }


            public int CurrentSeasonAverageGoalsScored { get; set; } //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu
            public int CurrentSeasonsAverageGoalsConceded { get; set; } //Jeżeli drużyna jest beniaminkiem do bierzemy średni wynik beniaminkow z poprzedniego sezonu

            public int CurrentSeasonAverageGoalsScoredHome { get; set; } //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu
            public int CurrentSeasonsAverageGoalsConcededHome { get; set; } //Jeżeli drużyna jest beniaminkiem do bierzemy średni wynik beniaminkow z poprzedniego sezonu

            public int CurrentSeasonAverageGoalsScoredAway { get; set; } //Jeżeli pierwszy mecz w sezonie to bierzemy średni wynik z poprzedniego sezonu
            public int CurrentSeasonsAverageGoalsConcededAway { get; set; } //Jeżeli drużyna jest beniaminkiem do bierzemy średni wynik beniaminkow z poprzedniego sezonu

            public int CurrentSeasonCleanSheatsPerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int CurrentSeasonCleanSheatsHomePerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu
            public int CurrentSeasonCleanSheatsAwayPerMatch { get; set; }  //Jeżeli beniaminek to bierzemy średni wynik beniaminków z poprzedniego sezonu

        public int CurrentSeasonRedCardsPerMatch { get; set; }



        //Last 5 matches
        //HomeAway?
            public int Last5MatchesAveragePointsFromCurrentSeason { get; set; }     // jeżeli drużyna jest benjaminiek to:
            public int Last5MatchesWinsFromCurrentSeason { get; set; }              // bierzemy 5 ostatnich meczy benjaminków z poprzedniego sezonu
            public int Last5MatchesDrawsFromCurrentSeason { get; set; }             
            public int Last5MatchesLosesFromCurrentSeason { get; set; }             

            public int Last5MatchesAverageGoalsScored { get; set; }     //Jeżeli w obecnym sezonie jeszcze nie zostało rozegrane 5 meczów to bierzemy 
            public int Last5MatchesAverageGoalsConceded { get; set; }   //średni wynik z całego poprzedniego sezonu
                                                                        //Jeżeli drużyna jest beniaminkiem to bierzemy 
                                                                        //średni wynik beniaminków z poprzedniego

            public int Last5MatchesCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu

        public int Last5MatchesRedCardsPerMatch { get; set; }











        //HomeAway?
            public int LastHomeH2HMatchResult { get; set; }     //Jeżeli drużyny jeszcze nie grały ze sobą to CHYBA "D"
            public int LastHomeH2HGoalsScored { get; set; }         //Zastanowić się co zrobić jeżeli w obecnym i poprzednim sezonie drużyny nie grały ze soba?
            public int LastHomeH2HGoalsConceded { get; set; }       // Albo wziąc wynik h2h albo to co wyżej
            public int LastAwayH2HMatchResult { get; set; }     //Jeżeli drużyny jeszcze nie grały ze sobą to CHYBA "D"
            public int LastAwayH2HGoalsScored { get; set; }         //Zastanowić się co zrobić jeżeli w obecnym i poprzednim sezonie drużyny nie grały ze soba?
            public int LastAwayH2HGoalsConceded { get; set; }       // Albo wziąc wynik h2h albo to co wyżej


        public int Last4HomeH2HMatchAveragePoints { get; set; }     //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        public int Last4HomeH2HMatchWins { get; set; }        
        public int Last4HomeH2HMatchDraws { get; set; }
        public int Last4HomeH2HMatchLoses { get; set; }

        public int Last4Away2HMatchAveragePoints { get; set; }     //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        public int Last4AwayH2HMatchWins { get; set; }
        public int Last4AwayH2HMatchDraws { get; set; }
        public int Last4AwayH2HMatchLoses { get; set; }

        public int Last4HomeH2HGoalsScored { get; set; }        //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        public int Last4HomeH2HGoalsConceded { get; set; }

        public int Last4AwayH2HGoalsScored { get; set; }        //Jeżeli drużyny grały mniej niż 4 mecze ze sobą to bierzemy tyle meczy ile mamy 
        public int Last4AwayH2HGoalsConceded { get; set; }

        public int Last4HomeH2HCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu
        public int Last4AwayH2HCleanSheats { get; set; }  //Jeżeli drużyna jest beniaminkiem to bierzemy średni wynik beniaminków z poprzedniego sezonu

        public int Last4H2HRedCardsPerMatch { get; set; }


        //Should be considered?
        //public int DaysFromLastMatch { get; set; } //Jeżeli pierwszy mecz to CHYBA max days

        // Napisać w pracy że można dodać ELO itp, ale nie bo robimy na czystych danych



    }
}
