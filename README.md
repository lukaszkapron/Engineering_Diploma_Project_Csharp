Projekt stworzony na potrzeby pracy dyplowej


Temat pracy: "Wykorzystanie uczenia mszynowego do przewidywania wyników meczów piłkarskich"

Data obrony: 07.02.2024r.

Streszczenie: "Niniejsza praca zawiera proces budowy modelu predykcyjnego opartego o algorytmy uczenia
maszynowego w celu predykcji wyników meczów piłkarskich. Początek pracy jest wprowadzeniem do
badanego problemu oraz przeglądem literatury odnoszącej się do podobnej tematyki. Następnie na
podstawie postawionego celu, pozyskano odpowiednie dane o meczach piłkarskich i przystąpiono do
budowania skutecznego, wieloklasowego modelu predykcyjnego. Pierwszym etapem było odpowiednie
wyliczenie statystyk meczowych, mogących mieć największy wpływ na końcowy rezultat spotkania oraz
uzupełnienie braków danych. Następnie wykorzystując wizualizacje danych oraz metody selekcji
zmiennych wybrano te, które będą mogły przynieść najlepsze rezultaty. Na podstawie tak
przygotowanych zmiennych wytrenowano 3 algorytmy uczenia maszynowego, a następnie przetestowano
zbudowane modele na zbiorze danych testowych, starając się przy tym osiągnąć jak najbardziej
jakościowe wyniki. Na koniec omówiono uzyskane rezultaty oraz porównano je do innych, tego typu
systemów."


Projekt zawiera proces tworzenia zmiennych wykorzystanych w algorytmach uczenia maszynowego w celu
przewidywania wyników meczów piłkarskich. Surowe dane hisotoryczne zostały przekształcone w 
odpowiedne zmienne objaśniające. Główną częścią projektu jest plik MatchStatsService.cs, który
zawiera wszystkie funkcje potrzebne do obliczania zmiennych. Wyliczone zostały 168 zmienne z podziałem
na drużynę domową i wyjazdową z kilkoma przedziałami czasu. Następnie zmienne te zostały zapisane do pliku csv.


Uwaga: dane użyte w procesie przygotowania zmiennych znajdują się pod adresem:
- https://www.football-data.co.uk/englandm.php

Przygtowane dane zostały wykorzystane w algorytmach uczenia maszynowego. Projekt jest dostępny pod adresem:
- https://github.com/lukaszkapron/Engineering_Diploma_Project_Csharp
