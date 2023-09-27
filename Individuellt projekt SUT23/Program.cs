namespace Individuellt_projekt_SUT23
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.BackgroundColor = ConsoleColor.Blue;//Since I have choose Nordea and their colors is blue and white I thought this had to be added.
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            
            var i = 1;
            
            start://I set the start here so i can loop back to it if the user writes the wrong credentials.
            //This is the log in menu. The user needs to match both the username and password to access the rest.
                Console.WriteLine("Välkommen till Nordea!");
                Console.WriteLine("\nVänligen logga in nedan:");
                Console.Write("Användarnamn: ");
                var UserName = Console.ReadLine().ToLower();

                Console.Write("Lösenord: ");
                var PassWord = Console.ReadLine().ToLower();

            //I choose to make a separate method for each user to easier work with errors. And to make the main method more easy to read. 
                if (UserName == "tobias" && PassWord == "qlok")
                {
                    Console.WriteLine("Välkommen Tobias!");
                    MainMenuTobias();
                }
                if (UserName == "anas" && PassWord == "spaghetti")
                {
                    Console.WriteLine("Välkommen Anas!");
                MainMenuAnas();
            }
            if (UserName == "johanna" && PassWord == "miro")
                {
                    Console.WriteLine("Välkommen Johanna!");
                MainMenuJohanna();
            }
                if (UserName == "pär" && PassWord == "campus")
                {
                    Console.WriteLine("Välkommen Pär!");
                MainMenuPär();
            }
                if (UserName == "eddie" && PassWord == "tidaholm")
                {
                    Console.WriteLine("Välkommen Eddie!");
                MainMenuEddie();
            }
                else
                {
                    Console.WriteLine("Felaktigt inlogg");
                    Console.WriteLine("Du har försökt " + i + " gånger!");
                    if (i < 3)
                    {
                        i++;
                    goto start;
                    }
                    if (i == 3)//If i equals 3 the user have entered the wrong credentials 3 times and the console closes.
                    {
                        Console.WriteLine("Du har överskridit dina 3 försök!");
                        System.Environment.Exit(0);
                    }
                }
        }
        public static void MainMenuTobias()
        {
            //I declare the diffrent accounts here so thay have a value that can be change later on.
            var TobiasKontoLön = 13854.45;
            var TobiasKontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)
            {
                Console.Clear();
                Console.WriteLine("---------- Huvudmeny ----------"); 
                Console.WriteLine("\n [1] Konton och saldo");
                Console.WriteLine("\n [2] Överföring");
                Console.WriteLine("\n [3] Uttag");
                Console.WriteLine("\n [4] Avsluta");
                try//I have added try/catch to catch the faulty inputs from the user.
                {
                    var menuoption = Convert.ToInt32(Console.ReadLine());
                    switch (menuoption)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {TobiasKontoLön} KR");
                            Console.WriteLine($"Sparkonto: {TobiasKontoSpar} KR");
                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")
                            {
                                Console.WriteLine("Vad vill du döpa ditt konto till?");
                                var kontonamn = Console.ReadLine();
                                Kontolist.Add(kontonamn);
                                Console.WriteLine($"Du har lagt till {kontonamn}");
                            }
                            else
                            {
                                break;
                            }
                            break;

                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("---------- Överföring ----------");
                                Console.WriteLine("Överföring:");
                                Console.WriteLine($"Från: [1] Lönekonto: {TobiasKontoLön} KR ");
                                Console.WriteLine($"Från: [2] Sparkonto: {TobiasKontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < TobiasKontoLön)
                                        {
                                            TobiasKontoLön -= transfer;
                                            TobiasKontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {TobiasKontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();

                                        }
                                    }
                                    else if (ÖverföringInput == 2)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        TobiasKontoLön += transfer;
                                        TobiasKontoSpar -= transfer;
                                        Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {TobiasKontoLön}");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Felaktig inmatning!, försök igen.");
                                    Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                    Console.ReadKey();
                                }
                                break;
                            }

                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("---------- Uttag ----------");
                                Console.WriteLine($"Från: [1] Lönekonto: {TobiasKontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {TobiasKontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    TobiasKontoLön -= transfer;

                                    Console.WriteLine($"Du har tagit ut {transfer} kr från {TobiasKontoLön}");
                                    Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                    Console.ReadKey();
                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    TobiasKontoSpar -= transfer;
                                    Console.WriteLine($"Du har tagit ut {transfer} kr från {TobiasKontoSpar}");
                                    Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen ange 1 eller 2.");
                                    Console.ReadKey();
                                }
                                break;
                            }

                        case 4:
                            Console.WriteLine("Tack för idag, Ha en fin dag.");
                            System.Environment.Exit(0);
                            mainbool = false;
                            break;
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Felaktig inmatning!, försök igen.");
                    Console.ReadKey();
                }
            }
        }
        
        public static void MainMenuJohanna()
        {
            var JohannaKontoLön = 2137.54;
            var JohannaKontoSpar = 5762.23;
            var mainbool = true;
            while (mainbool)
            {
                Console.Clear();
                Console.WriteLine("---------- Huvudmeny ----------");
                Console.WriteLine("\n [1] Konton och saldo");
                Console.WriteLine("\n [2] Överföring");
                Console.WriteLine("\n [3] Uttag och insättning");
                Console.WriteLine("\n [4] Avsluta");
                var menuoption = Convert.ToInt32(Console.ReadLine());

                switch (menuoption)
                {
                    case 1:
                        Console.WriteLine("---------- Konton och saldo ----------");
                        Console.Write($"Lönekonto: {JohannaKontoLön}");
                        Console.Write($"Sparkonto: {JohannaKontoSpar}");
                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Överföring ----------");
                            Console.WriteLine("Överföring:");
                            Console.WriteLine($"Från: [1] Lönekonto: {JohannaKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {JohannaKontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                JohannaKontoLön -= transfer;
                                JohannaKontoSpar += transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {JohannaKontoLön} till {JohannaKontoSpar}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                JohannaKontoLön += transfer;
                                JohannaKontoSpar -= transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {JohannaKontoSpar} till {JohannaKontoLön}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Uttag ----------");
                            Console.WriteLine($"Från: [1] Lönekonto: {JohannaKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {JohannaKontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                JohannaKontoLön -= transfer;

                                Console.WriteLine($"Du har tagit ut {transfer} kr från {JohannaKontoLön}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                JohannaKontoSpar -= transfer;
                                Console.WriteLine($"Du har tagit ut {transfer} kr från {JohannaKontoSpar}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }

                    case 4:
                        Console.WriteLine("Tack för idag, Ha en fin dag.");
                        mainbool = false;
                        break;


                    default:
                        Console.WriteLine("Vänligen välj ett alternativ ur listan");
                        break;
                }
            }


        }

        public static void MainMenuAnas()
        {

            var AnasKontoLön = 3575.78;
            var AnaskontoSpar = 8951.92;
            var mainbool = true;


            while (mainbool)
            {
                Console.Clear();
                Console.WriteLine("---------- Huvudmeny ----------");
                Console.WriteLine("\n [0] Konton och saldo");
                Console.WriteLine("\n [1] Överföring");
                Console.WriteLine("\n [2] Uttag och insättning");
                Console.WriteLine("\n [3] Avsluta");
                var menuoptionAnas = Convert.ToInt32(Console.ReadLine());

                switch (menuoptionAnas)
                {
                    case 0:
                        Console.WriteLine("---------- Konton och saldo ----------");
                        Console.Write($"Lönekonto: {AnasKontoLön}");
                        Console.Write($"Sparkonto: {AnaskontoSpar}");
                        break;

                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Överföring ----------");
                            Console.WriteLine("Överföring:");
                            Console.WriteLine($"Från: [1] Lönekonto: {AnasKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {AnaskontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                AnasKontoLön -= transfer;
                                AnaskontoSpar += transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {AnasKontoLön} till {AnaskontoSpar}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                AnasKontoLön += transfer;
                                AnaskontoSpar -= transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {AnaskontoSpar} till {AnasKontoLön}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Uttag ----------");
                            Console.WriteLine($"Från: [1] Lönekonto: {AnasKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {AnaskontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                AnasKontoLön -= transfer;

                                Console.WriteLine($"Du har tagit ut {transfer} kr från {AnasKontoLön}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                AnaskontoSpar -= transfer;
                                Console.WriteLine($"Du har tagit ut {transfer} kr från {AnaskontoSpar}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }

                    case 3:
                        Console.WriteLine("Tack för idag, Ha en fin dag.");
                        mainbool = false;
                        break;


                    default:
                        Console.WriteLine("Vänligen välj ett alternativ ur listan");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("---------- Huvudmeny ----------");
            Console.WriteLine("\n [1] Konton och saldo");
            Console.WriteLine("\n [2] Överföring och betalningar");
            Console.WriteLine("\n [3] uttag och insättning");
            Console.WriteLine("\n [4] Avsluta");
            var menuoption = Convert.ToInt32(Console.ReadLine());

            switch (menuoption)
            {
                case 1:
                    Console.WriteLine("---------- Konton och saldo ----------");
                    Console.Write($"Lönekonto: {AnasKontoLön}");
                    Console.Write($"Sparkonto: {AnaskontoSpar}");
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:
                    Console.WriteLine("Tack för idag, Ha en fin dag.");
                    break;

                default:
                    Console.WriteLine("Vänligen välj ett alternativ ur listan");
                    break;
            }


        }
        public static void MainMenuPär()
        {
            var PärKontoLön = 12378.12;
            var PärKontoSpar = 11067.34;
            var mainbool = true;

            
            while (mainbool)
            {
                Console.Clear();
                Console.WriteLine("---------- Huvudmeny ----------");
                Console.WriteLine("\n [1] Konton och saldo");
                Console.WriteLine("\n [2] Överföring");
                Console.WriteLine("\n [3] Uttag och insättning");
                Console.WriteLine("\n [4] Avsluta");
                var menuoption = Convert.ToInt32(Console.ReadLine());

                switch (menuoption)
                {
                    case 1:
                        Console.WriteLine("---------- Konton och saldo ----------");
                        Console.Write($"Lönekonto: {PärKontoLön}");
                        Console.Write($"Sparkonto: {PärKontoSpar}");
                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Överföring ----------");
                            Console.WriteLine("Överföring:");
                            Console.WriteLine($"Från: [1] Lönekonto: {PärKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {PärKontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                PärKontoLön -= transfer;
                                PärKontoSpar += transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {PärKontoLön} till {PärKontoSpar}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                PärKontoLön += transfer;
                                PärKontoSpar -= transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {PärKontoSpar} till {PärKontoLön}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }



                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Uttag ----------");
                            Console.WriteLine($"Från: [1] Lönekonto: {PärKontoLön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {PärKontoSpar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                PärKontoLön -= transfer;

                                Console.WriteLine($"Du har tagit ut {transfer} kr från {PärKontoLön}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                PärKontoSpar -= transfer;
                                Console.WriteLine($"Du har tagit ut {transfer} kr från {PärKontoSpar}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }

                    case 4:
                        Console.WriteLine("Tack för idag, Ha en fin dag.");
                        mainbool = false;
                        break;


                    default:
                        Console.WriteLine("Vänligen välj ett alternativ ur listan");
                        break;
                }
            }


        }
        public static void MainMenuEddie()
        {
            var EddieKontolön = 17671.69;
            var EddieKontospar = 10004.42;

            var mainbool = true;
            while (mainbool)
            {
                Console.Clear();
                Console.WriteLine("---------- Huvudmeny ----------");
                Console.WriteLine("\n [1] Konton och saldo");
                Console.WriteLine("\n [2] Överföring");
                Console.WriteLine("\n [3] Uttag och insättning");
                Console.WriteLine("\n [4] Avsluta");
                var menuoption = Convert.ToInt32(Console.ReadLine());

                switch (menuoption)
                {
                    case 1:
                        Console.WriteLine("---------- Konton och saldo ----------");
                        Console.Write($"Lönekonto: {EddieKontolön}");
                        Console.Write($"Sparkonto: {EddieKontospar}");
                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Överföring ----------");
                            Console.WriteLine("Överföring:");
                            Console.WriteLine($"Från: [1] Lönekonto: {EddieKontolön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {EddieKontospar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                EddieKontolön -= transfer;
                                EddieKontospar += transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {EddieKontolön} till {EddieKontospar}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du föra över?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                EddieKontolön += transfer;
                                EddieKontospar -= transfer;
                                Console.WriteLine($"Det har överförts {transfer} kr från {EddieKontospar} till {EddieKontolön}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }



                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("---------- Uttag ----------");
                            Console.WriteLine($"Från: [1] Lönekonto: {EddieKontolön} kr ");
                            Console.WriteLine($"Från: [2] Sparkonto: {EddieKontospar} kr ");
                            var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                            if (ÖverföringInput == 1)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                EddieKontolön -= transfer;

                                Console.WriteLine($"Du har tagit ut {transfer} kr från {EddieKontolön}");
                            }
                            if (ÖverföringInput == 2)
                            {
                                Console.WriteLine("Hur mycket vill du ta ut?");
                                var transfer = Convert.ToInt32(Console.ReadLine());
                                EddieKontospar -= transfer;
                                Console.WriteLine($"Du har tagit ut {transfer} kr från {EddieKontospar}");
                            }
                            else
                            {
                                Console.WriteLine("Vänligen ange 1 eller 2.");
                            }
                            break;
                        }

                    case 4:
                        Console.WriteLine("Tack för idag, Ha en fin dag.");
                        mainbool = false;
                        break;


                    default:
                        Console.WriteLine("Vänligen välj ett alternativ ur listan");
                        break;
                }
            }


        }


    }
}