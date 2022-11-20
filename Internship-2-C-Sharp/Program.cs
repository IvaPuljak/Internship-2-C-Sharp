using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Collections;

var players = new Dictionary<string, (string position, int rating)>()
{
    { "Luka Modrić", ("MF", 88) },
    { "Marcelo Brozović", ("MF", 86) },
    { "Mateo Kovačić", ("MF", 84) },
    { "Ivan Perišić", ("MF", 84) },
    { "Andrej Kramarić", ("FW", 82) },
    { "Ivan Rakitić", ("MF", 82) },
    { "Joško Gvardiol", ("DF", 81) },
    { "Mario Pašalić", ("MF", 81) },
    { "Lovro Majer", ("MF", 80) },
    { "Dominik Livaković", ("GK", 80) },
    { "Ante Rebić", ("FW", 80) },
    { "Josip Brekalo", ("MF", 79) },
    { "Borna Sosa", ("DF", 78) },
    { "Duje Ćaleta-Car", ("DF", 78) },
    { "Nikola Vlašić", ("MF", 78) },
    { "Dejan Lovren", ("DF", 78) },
    { "Mislav Oršić", ("FW", 77) },
    { "Marko Livaja", ("FW", 77) },
    { "Domagoj Vida", ("DF", 76) },
    { "Ante Budimir", ("FW", 78) }

};
var games = new List<Dictionary<string, int>>()
{
     new Dictionary<string, int>()
     {
    {"Hrvatska", 0},
    {"Belgija", 0 },
    {"Kanada", 0 },
    {"Maroko", 0 } },
     new Dictionary<string, int>()
     {
    {"Hrvatska", 0},
    {"Kanada", 0 },
    {"Belgija", 0 },
    {"Maroko", 0 } }

};
var theFirstElevenTotal = new Dictionary<string, int>();
int numGK = 1;
int numMF = 3;
int numFW = 3;
int numDF = 4;

    foreach (var item in players)
    {
        
        if (Equals(item.Value.position, "GK") == true)
        {
            theFirstElevenTotal.Add(item.Key, 0);
            numGK--;
        }
        if (numGK == 0)
            break;
    }
    foreach (var item in players.OrderByDescending(Key => Key.Value.rating))
    {

        if (Equals(item.Value.position, "DF") == true)
        {
            theFirstElevenTotal.Add(item.Key, 0);
            numDF--;
        }
        if (numDF == 0)
            break;

    }
    foreach (var item in players.OrderByDescending(Key => Key.Value.rating))
    {

        if (Equals(item.Value.position, "MF") == true)
        {
            theFirstElevenTotal.Add(item.Key,0);
            numMF--;
        }
        if (numMF == 0)
            break;

    }
    foreach (var item in players.OrderByDescending(Key => Key.Value.rating))
    {

        if (Equals(item.Value.position, "FW") == true)
        {
            theFirstElevenTotal.Add(item.Key, 0);
            numFW--;
        }
        if (numFW == 0)
            break;

    }

var decision = 17;
var command = 0;
int ratingNew;
do
{
    Console.Clear();
    Console.WriteLine("     ~ IZBORNIK ~  ");
    Console.WriteLine("");
    Console.WriteLine("1 - Odradi trening");
    Console.WriteLine("2 - Odigraj utakmicu");
    Console.WriteLine("3 - Statistika");
    Console.WriteLine("4 - Kontrola igraca");
    Console.WriteLine("0 - Izlaz iz aplikacije");

    Console.Write("\nUnesi naredbu: ");
    Console.WriteLine("");
    bool IsThisTrue = int.TryParse(Console.ReadLine(), out command);
    if (!IsThisTrue)
    {
        Console.WriteLine("");
        Console.WriteLine("Probaj opet");
        Console.WriteLine("");
        Console.WriteLine("1 - Odradi trening");
        Console.WriteLine("2 - Odigraj utakmicu");
        Console.WriteLine("3 - Statistika");
        Console.WriteLine("4 - Kontrola igraca");
        Console.WriteLine("0 - Izlaz iz aplikacije");

        Console.Write("\nUnesi naredbu opet: ");
        command = 17;
        continue;
    }

    switch (command)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("       ~ ODRADI TRENING ~    ");
            Console.WriteLine("");
            Console.WriteLine(" ~ STARI RATING ~ ");
            Console.WriteLine("");
            foreach (var item in players)
                Console.WriteLine($"{item.Key} --> {item.Value.rating}");

            foreach (var item in players)
            {
                Random r = new Random();
                int rInt = r.Next(-5, 6);
                players[item.Key] = (item.Value.position, item.Value.rating + rInt);

            }
            foreach (var item in players)
            {
                if (item.Value.rating >= 100)
                    players[item.Key] = (item.Value.position, 100);
            }

            Console.WriteLine("");
            Console.WriteLine(" ~ NOVI RATING ~ ");
            Console.WriteLine("");
            foreach (var item in players)
                Console.WriteLine($"{item.Key} --> {item.Value.rating}");
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Povratak na izbornik: DA ili NE");
                string menu = Console.ReadLine();
                string result = menu.ToUpper();
                if (result == "DA")
                {
                    decision = 1;
                    break;
                }
                else if (result == "NE")
                {
                    decision = 0;
                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Krivo si unio/unijela :(");
                    Console.WriteLine("");
                    Console.WriteLine("Probaj opet:");

                    continue;

                }

            } while (true);
            if (decision == 0)
                return;
            else
                continue;

       case 2:
            Console.Clear();
            Console.WriteLine("     ~ODIGRAJ UTAKMICU~    ");
            
            if(theFirstElevenTotal.Count()<11)
                Console.WriteLine("\nNema dovoljno igrača za odigrati utakmicu!");
            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("     ~POSTAVA~    ");
                foreach(var item in theFirstElevenTotal)
                    Console.WriteLine(item.Key);
            }
            Console.WriteLine("");
            Console.WriteLine("2 - odigraj utakmicu");
            Console.WriteLine("1 - vrati se na izbornik");
            Console.WriteLine("0 - izađi iz aplikacije ");
            Console.WriteLine("");
            Console.WriteLine("Unesi naredbu: ");
            bool IsThisFalse = int.TryParse(Console.ReadLine(), out command);
            if (!IsThisFalse)
            {
                Console.WriteLine("");
                Console.WriteLine("Probaj opet");
                Console.WriteLine("");
                Console.WriteLine("2 - odigraj utakmicu");
                Console.WriteLine("1 - vrati se na izbornik");
                Console.WriteLine("0 - izađi iz aplikacije ");

                Console.Write("\nUnesi naredbu opet: ");
                command = 17;
                continue;
            }
            switch (command)
            {
                case 0:
                    Console.WriteLine("Izasli ste iz aplaikacije");
                    return;
                case 1:
                    Console.Clear();
                    break;
                case 2:

                    int k = 0;
                    Console.Clear();
                    do { 
                        Console.WriteLine($"     ~ {k + 1}. utakmica ~   ");
                        var teams = games.ElementAt(k);
                        foreach (var item in teams)
                        {


                            Random goals = new Random();
                            int goalsInt = goals.Next(0, 10);
                            teams[item.Key] = goalsInt;

                            if (item.Key == "Hrvatska")
                            {
                                var theFirstEleven = new Dictionary<string, int>()
                            {
                                { "Luka Modrić", 0 },
                                { "Marcelo Brozović",  0},
                                { "Mateo Kovačić", 0 },
                                { "Andrej Kramarić",0  },
                                { "Joško Gvardiol", 0 },
                                { "Dominik Livaković",0  },
                                { "Ante Rebić", 0 },
                                { "Borna Sosa", 0 },
                                { "Duje Ćaleta-Car", 0 },
                                { "Dejan Lovren", 0 },
                                { "Ante Budimir",0 }



                            };
                                var listOf11 = new List<string>(theFirstEleven.Keys);

                                while (goalsInt > 0)
                                {
                                    Console.WriteLine(goalsInt);
                                    Random goal = new Random();
                                    int golovi = goal.Next(1, goalsInt);
                                    Console.WriteLine(golovi);
                                    Random rand = new Random();
                                    string randomKey = listOf11[rand.Next(listOf11.Count)];
                                    Console.WriteLine(randomKey);
                                    listOf11.Remove(randomKey);
                                    theFirstEleven.Remove(randomKey);
                                    theFirstEleven.Add(randomKey, golovi);
                                    theFirstElevenTotal[randomKey] = theFirstElevenTotal[randomKey] + golovi;
                                    foreach (var item2 in players)
                                    {
                                        if (item2.Key == randomKey)
                                            players[item2.Key] = (item2.Value.position, item2.Value.rating + 5);
                                    }
                                    goalsInt -= golovi;
                                }


                            }


                        }
                        Console.WriteLine($"\nRezultat {k + 1}. utakmice:");
                        var teamsKeys = new List<string>(teams.Keys);
                        for (var i = 1; i < teams.Count(); i += 2)
                        {
                            var key1 = teamsKeys.ElementAt(i - 1);
                            var key2 = teamsKeys.ElementAt(i);
                            Console.WriteLine($"{key1} - {key2} -> {teams[key1]} - {teams[key2]}");
                            if (key1 == "Hrvatska" && teams[key1] > teams[key2])
                            {
                                foreach (var item in players)
                                    players[item.Key] = (item.Value.position, item.Value.rating + 2);
                            }
                            else if (key1 == "Hrvatska" && teams[key1] < teams[key2])
                            {
                                foreach (var item in players)
                                    players[item.Key] = (item.Value.position, item.Value.rating - 2);
                            }
                        }

                        Console.WriteLine("2 - odigrati još jednu utakmicu");
                        Console.WriteLine("1 - vrati se na izbornik");
                        Console.WriteLine("0 - izađi iz aplikacije");

                        Console.WriteLine("\nUnesi naredbu:");
                        bool IsThis = int.TryParse(Console.ReadLine(), out command);
                        if (!IsThis)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Probaj opet");
                            Console.WriteLine("");
                            Console.WriteLine("2 - odigrati još jednu  utakmicu");
                            Console.WriteLine("1 - vrati se na izbornik");
                            Console.WriteLine("0 - izađi iz aplikacije ");

                            Console.Write("\nUnesi naredbu opet: ");
                            command = 17;
                            continue;
                        }
                        k++;
                        switch (command)
                        {
                            case 2:
                                continue;


                            case 1:
                                Console.Clear();
                                break;
                            case 0:
                                Console.WriteLine("Izašli ste iz aplikacije");
                                return;
                        }

            }while (true) ;     

                    
                //  ako je k > 5
                break;
            }



            do
            {

                Console.WriteLine("");
                Console.WriteLine("Povratak na izbornik: DA ili NE");
                string menu = Console.ReadLine();
                string result = menu.ToUpper();
                if (result == "DA")
                {
                    decision = 1;
                    break;
                }
                else if (result == "NE")
                {
                    decision = 0;

                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Krivo si unio/unijela :(");
                    Console.WriteLine("");
                    Console.WriteLine("Probaj opet:");
                    continue;

                }

            } while (true);
            if (decision == 0)
            {
                Console.WriteLine("Izašli ste iz aplikacije");
                return;
            }
            else
                continue;

        case 3:
            Console.Clear();
            Console.WriteLine("      ~ STATISTIKA ~    ");
            Console.WriteLine("");
            Console.WriteLine("1 - Ispis svih igrača");
            Console.Write("\nUnesi naredbu " +
                "(ako uneseš bilo koji drugi znak osim 1 vraćaš se na IZBORNIK): ");
            string command3 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
            
            Console.WriteLine("");
            if (command3 == "1")
            {
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("      ~ ISPIS SVIH IGRAČA ~    ");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Ispis onako kako su spremljeni");
                    Console.WriteLine("2 - Ispis po ratingu uzlazno");
                    Console.WriteLine("3 - Ispis po ratingu silazno");
                    Console.WriteLine("4 - Ispis igrača po imenu i prezimenu (ispis pozicije i ratinga)");
                    Console.WriteLine("5 - Ispis igrača po ratingu");
                    Console.WriteLine("6 - Ispis igrača po poziciji ");
                    Console.WriteLine("7 - Ispis trenutnih prvih 11 igrača");
                    Console.WriteLine("8 - Ispis strijelaca i koliko golova imaju");
                    Console.WriteLine("9 - Ispis svih rezultata ekipe");
                    Console.WriteLine("10 - Ispis rezultat svih ekipa");
                    Console.WriteLine("11 - Ispis tablice grupe");
                    Console.WriteLine("");
                    Console.WriteLine("Unesi što želiš ispisati: ");

                    IsThisTrue = int.TryParse(Console.ReadLine(), out command);

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("       ~ ISPIS ONAKO KAKO SU SPREMLJENI ~     ");
                            Console.WriteLine("");

                            foreach (var item in players)
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("       ~ SORTIRANI PO RATINGU UZLAZNO ~     ");
                            Console.WriteLine("");
                            foreach (var item in players.OrderBy(Key => Key.Value.rating))
                            {
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("       ~ SORTIRANI PO RATINGU SILAZNO ~     ");
                            Console.WriteLine("");
                            foreach (var item in players.OrderByDescending(Key => Key.Value.rating))
                            {
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            }

                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("       ~ SORTIRANI PO IMENU I PREZIMENU ~      ");
                            Console.WriteLine("");
                            foreach (var item in players.OrderBy(Key => Key.Key))
                            {
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("       ~ SORITRANI IGRAČI PO RATINGU ~      ");
                            Console.WriteLine("");
                            foreach (var item in players.OrderBy(Key => Key.Value.rating))
                            {
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            }
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("       ~ SORTIRANI IGRAČI PO POZICIJI ~     ");
                            Console.WriteLine("");
                            foreach (var item in players.OrderByDescending(Key => Key.Value.position))
                            {
                                Console.WriteLine($"{item.Key}, {item.Value.position},{item.Value.rating}");
                            }

                            break;
                        case 7:
                            Console.WriteLine("");
                            Console.WriteLine("        ~ PRVIH 11 IGRAČA ~     ");
                            foreach (var item in theFirstElevenTotal)
                                Console.WriteLine($"{item.Key}");
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;

                    }
                } while (command != 1 && command != 2 && command != 3 && command != 4 && command != 5 && command != 6 && command != 7 && command != 8 && command != 9 && command != 10 && command != 11);



            do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Povratak na izbornik: DA ili NE");
                    string menu = Console.ReadLine();
                    string result = menu.ToUpper();
                    if (result == "DA")
                    {
                        decision = 1;
                        break;
                    }
                    else if (result == "NE")
                    {
                        decision = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Krivo si unio/unijela :(");
                        Console.WriteLine("");
                        Console.WriteLine("Probaj opet:");
                        continue;

                    }

                } while (true);
                if (decision == 0)
                {
                    Console.WriteLine("Izašli ste iz aplikacije");
                    return;
                }
                else
                {
                    continue;
                }


            }
            break;
        case 4:
            Console.Clear();
            string positionNew;
            Console.WriteLine("      ~ UREĐIVANJE ~    ");
            Console.WriteLine("");
            Console.WriteLine("1 - Unos novog igrača");
            Console.WriteLine("2 - Brisanje igrača");
            Console.WriteLine("3 - Uređivanje igrača");
            Console.WriteLine("Unesi naredbu: ");
            IsThisTrue = int.TryParse(Console.ReadLine(), out command);
            if (!IsThisTrue)
            {

                Console.WriteLine("Krivo si unio/unijela");
                Console.WriteLine("");
                Console.WriteLine("1 - Unos novog igrača");
                Console.WriteLine("2 - Brisanje igrača");
                Console.WriteLine("3 - Uređivanje igrača");
                Console.WriteLine("Unesi naredbu opet: ");
                command = 17;
                continue;
            }
            switch(command)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("     ~ UNOS NOVOG IGRAČA ~    ");
                    if (players.Count() > 26)
                        Console.WriteLine("Nažalost ne možeš unijesti novog igrača jer je makismalan broj igrača u ekipi je 26!");
                   int br = 20;
                    Console.WriteLine("Koliko novih igrača želiš unijeti:");
                    var novi = int.Parse(Console.ReadLine());
                    var brojac = 0;
                    if (novi > 6 && br == 20)
                    {
                        Console.WriteLine("Nažalost ne možeš unijesti toliko igrača jer je makismalan broj igrača u ekipi je 26!");
                        Console.WriteLine("Možeš unijeti 6 igrača");
                        brojac = br + 6;
                    }
                    brojac = br + novi;
                    do
                    {
                        Console.WriteLine("Unesi ime i prezime igrača:");
                        string name = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Pozicije koje možete unijeti su: MF, DF, FW, GK");
                        do
                        {
                            Console.WriteLine("Unesi poziciju igrača:");
                            positionNew = Console.ReadLine();
                        } while (positionNew != "MF" && positionNew != "DF" && positionNew != "FW" && positionNew != "GK");
                        Console.WriteLine("");
                        Console.WriteLine("Rating koji možete unijeti je rasponu [1, 100]");
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Unesi rating igrača:");
                            ratingNew = int.Parse(Console.ReadLine());
                            Console.WriteLine("");
                        } while (!(ratingNew >= 1 && ratingNew <= 100));

                        players.Add(name, (positionNew, ratingNew));

                        br++;

                    } while (br != brojac);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("      ~ BRISANJE IGRAČA ~     ");

                    Console.WriteLine("Koliko igrača želiš izbrisati: ");
                    var delete = int.Parse(Console.ReadLine());
                    int br1 = 0;
                    Console.WriteLine("");
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Unesi ime i prezime igrača:");
                        Console.WriteLine("");
                        string name = Console.ReadLine();

                        players.Remove(name);

                        br1++;

                    } while (br1 != delete);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("      ~ UREĐIVANJE IGRAČA ~   ");
                    Console.WriteLine("1 - Uredi ime i prezime igrača");
                    Console.WriteLine("2 - Uredi poziciju igrača (GK, DF, MF ili FW)");
                    Console.WriteLine("3 - Uredi rating igrača (od 1 do 100)");
                    Console.WriteLine("Unesi naredbu: ");
                    var edit = int.Parse(Console.ReadLine());
                    switch(edit)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("     ~ UREDI IME I PREZIME IGRAČA ~     ");
                            Console.WriteLine("Unesi ime i prezime igrača kojeg želiš urediti: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Uredi:");
                            string nameNew = Console.ReadLine();
                            players[nameNew] = players[name];
                            players.Remove(name);
                            Console.WriteLine("");
                            Console.WriteLine("Uspiješno uređen");
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("      ~ UREDI POZICIJU IGRAČA ~    ");
                            Console.WriteLine("Unesi ime i prezime igrača kojeg želiš urediti: ");
                            name = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Uredi poziciju tog igrača:");
                            string positionChanged = Console.ReadLine();
                            foreach(var item in players)
                            {
                                players[name] = (positionChanged, item.Value.rating);
                            }

                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("     ~ UREDI RATING IGRAČA ~    ");
                            Console.WriteLine("Unesi ime i prezime igrača kojeg želiš urediti: ");
                            name = Console.ReadLine();
                            Console.WriteLine("");
                            int ratingChanged;
                            do
                            {
                                Console.WriteLine("Uredi rating tog igrača:");
                                ratingChanged = int.Parse(Console.ReadLine());
                            } while (!(ratingChanged >= 1 && ratingChanged <=100));
                            foreach (var item in players)
                            {
                                players[name] = (item.Value.position, ratingChanged);
                            }

                            break;
                    }
                    
                   
                    break;

            }
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Povratak na izbornik: DA ili NE");
                string menu = Console.ReadLine();
                string result = menu.ToUpper();
                if (result == "DA")
                {
                    decision = 1;
                    break;
                }
                else if (result == "NE")
                {
                    decision = 0;
                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Krivo si unio/unijela :(");
                    Console.WriteLine("");
                    Console.WriteLine("Probaj opet:");
                    Console.WriteLine("") ;
                    continue;

                }

            } while (true);
            if (decision == 0)
            {
                Console.WriteLine("Izašli ste iz aplikacije");
                return;

            }
            else
                continue;

            

        case 0:
            Console.WriteLine("Izašli ste iz aplikacije");
            return;
    }
} while (true);
