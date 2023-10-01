namespace Individuellt_projekt_SUT23
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.BackgroundColor = ConsoleColor.Blue;//Since I have choosen Nordea and their colors is blue and white I thought this had to be added.
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
            string[] UserNameArray = { "tobias", "anas", "johanna", "pär", "eddie" };
            string[] PassWordArray = { "qlok", "spaghetti", "miro", "campus", "tidaholm" };
            //I create Arrays to store the usernames and passwords. This could be converted to lists or a dictionary.

            //I choose to make a separate method for each user to easier work with errors. And to make the main method more easy to read. 
            if (UserName == UserNameArray[0] && PassWord == PassWordArray[0])
            {
                Console.WriteLine("Välkommen Tobias!");
                MainMenuTobias();
            }
            if (UserName == UserNameArray[1] && PassWord == PassWordArray[1])
            {
                Console.WriteLine("Välkommen Anas!");
                MainMenuAnas();
            }
            if (UserName == UserNameArray[2] && PassWord == PassWordArray[2])
            {
                Console.WriteLine("Välkommen Johanna!");
                MainMenuJohanna();
            }
            if (UserName == UserNameArray[3] && PassWord == PassWordArray[3])
            {
                Console.WriteLine("Välkommen Pär!");
                MainMenuPär();
            }
            if (UserName == UserNameArray[4] && PassWord == PassWordArray[4])
            {
                Console.WriteLine("Välkommen Eddie!");
                MainMenuEddie();
            }
            else
            {
                Console.WriteLine("Felaktigt inlogg");
                
                if (i < 3)
                {
                    Console.WriteLine("\nDu har försökt " + i + " gånger!");
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
            var KontoLön = 13854.45;
            var KontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)//I run my mainmenu inside a whileloop so i can comeback to it after the user has finished tha action.
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
                            Console.Clear();//I clear the console so i looks more like a "new" window.
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {KontoLön} KR");
                            Console.WriteLine($"Sparkonto: {KontoSpar} KR");

                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")//Here i play with the add account function to my list. 
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} KR ");//I let the user choose the account the money should be moved from.
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < KontoLön)//If the transfer amount is less than the amount in the account do this.
                                        {
                                            KontoLön -= transfer;
                                            KontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {KontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else//If the transfer amount is greater than the amount in the account do this. We cant have a negative balance.
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
                                        if (transfer < KontoSpar)
                                        {
                                            KontoLön += transfer;
                                            KontoSpar -= transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {KontoLön}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoLön)
                                    {
                                        KontoLön -= transfer;

                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoLön}");
                                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte övertrassera ditt konto!");
                                    }

                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoSpar)
                                    {
                                        KontoSpar -= transfer;
                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoSpar}");
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

            //I declare the diffrent accounts here so thay have a value that can be change later on.
            var KontoLön = 13854.45;
            var KontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)//I run my mainmenu inside a whileloop so i can comeback to it after the user has finished tha action.
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
                            Console.Clear();//I clear the console so i looks more like a "new" window.
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {KontoLön} KR");
                            Console.WriteLine($"Sparkonto: {KontoSpar} KR");

                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")//Here i play with the add account function to my list. 
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} KR ");//I let the user choose the account the money should be moved from.
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < KontoLön)//If the transfer amount is less than the amount in the account do this.
                                        {
                                            KontoLön -= transfer;
                                            KontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {KontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else//If the transfer amount is greater than the amount in the account do this. We cant have a negative balance.
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
                                        if (transfer < KontoSpar)
                                        {
                                            KontoLön += transfer;
                                            KontoSpar -= transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {KontoLön}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoLön)
                                    {
                                        KontoLön -= transfer;

                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoLön}");
                                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte övertrassera ditt konto!");
                                    }

                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoSpar)
                                    {
                                        KontoSpar -= transfer;
                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoSpar}");
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

        public static void MainMenuAnas()
        {
            //I declare the diffrent accounts here so thay have a value that can be change later on.
            var KontoLön = 13854.45;
            var KontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)//I run my mainmenu inside a whileloop so i can comeback to it after the user has finished tha action.
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
                            Console.Clear();//I clear the console so i looks more like a "new" window.
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {KontoLön} KR");
                            Console.WriteLine($"Sparkonto: {KontoSpar} KR");

                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")//Here i play with the add account function to my list. 
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} KR ");//I let the user choose the account the money should be moved from.
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < KontoLön)//If the transfer amount is less than the amount in the account do this.
                                        {
                                            KontoLön -= transfer;
                                            KontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {KontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else//If the transfer amount is greater than the amount in the account do this. We cant have a negative balance.
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
                                        if (transfer < KontoSpar)
                                        {
                                            KontoLön += transfer;
                                            KontoSpar -= transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {KontoLön}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoLön)
                                    {
                                        KontoLön -= transfer;

                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoLön}");
                                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte övertrassera ditt konto!");
                                    }

                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoSpar)
                                    {
                                        KontoSpar -= transfer;
                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoSpar}");
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
        public static void MainMenuPär()
        {

            //I declare the diffrent accounts here so thay have a value that can be change later on.
            var KontoLön = 13854.45;
            var KontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)//I run my mainmenu inside a whileloop so i can comeback to it after the user has finished tha action.
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
                            Console.Clear();//I clear the console so i looks more like a "new" window.
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {KontoLön} KR");
                            Console.WriteLine($"Sparkonto: {KontoSpar} KR");

                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")//Here i play with the add account function to my list. 
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} KR ");//I let the user choose the account the money should be moved from.
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < KontoLön)//If the transfer amount is less than the amount in the account do this.
                                        {
                                            KontoLön -= transfer;
                                            KontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {KontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else//If the transfer amount is greater than the amount in the account do this. We cant have a negative balance.
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
                                        if (transfer < KontoSpar)
                                        {
                                            KontoLön += transfer;
                                            KontoSpar -= transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {KontoLön}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoLön)
                                    {
                                        KontoLön -= transfer;

                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoLön}");
                                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte övertrassera ditt konto!");
                                    }

                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoSpar)
                                    {
                                        KontoSpar -= transfer;
                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoSpar}");
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
        public static void MainMenuEddie()
        {

            //I declare the diffrent accounts here so thay have a value that can be change later on.
            var KontoLön = 13854.45;
            var KontoSpar = 18301.90;
            List<string> Kontolist = new List<string>();//I play with the list function to see if i can make my account system easier.

            var mainbool = true;
            while (mainbool)//I run my mainmenu inside a whileloop so i can comeback to it after the user has finished tha action.
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
                            Console.Clear();//I clear the console so i looks more like a "new" window.
                            Console.WriteLine("---------- Konton och saldo ----------");
                            Console.WriteLine($"Lönekonto: {KontoLön} KR");
                            Console.WriteLine($"Sparkonto: {KontoSpar} KR");

                            Console.WriteLine("\nVill du öppna ett nytt konto tryck 'K'");
                            Console.WriteLine("\nVill du tillbaka till huvudmenyn klicka på valfri tangent!");
                            var kontoinput = Console.ReadLine().ToLower();
                            if (kontoinput == "k")//Here i play with the add account function to my list. 
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} KR ");//I let the user choose the account the money should be moved from.
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} KR ");
                                try
                                {
                                    var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                    if (ÖverföringInput == 1)
                                    {
                                        Console.WriteLine("Hur mycket vill du föra över?");
                                        var transfer = Convert.ToInt32(Console.ReadLine());
                                        if (transfer < KontoLön)//If the transfer amount is less than the amount in the account do this.
                                        {
                                            KontoLön -= transfer;
                                            KontoSpar += transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt sparkonto. Saldot är nu: {KontoSpar} KR");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
                                        else//If the transfer amount is greater than the amount in the account do this. We cant have a negative balance.
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
                                        if (transfer < KontoSpar)
                                        {
                                            KontoLön += transfer;
                                            KontoSpar -= transfer;
                                            Console.WriteLine($"Det har överförts {transfer} KR till ditt lönekonto. Saldot är nu: {KontoLön}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du kan inte övertrassera ditt konto");
                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                            Console.ReadKey();
                                        }
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
                                Console.WriteLine($"Från: [1] Lönekonto: {KontoLön} kr ");
                                Console.WriteLine($"Från: [2] Sparkonto: {KontoSpar} kr ");
                                var ÖverföringInput = Convert.ToInt32(Console.ReadLine());

                                if (ÖverföringInput == 1)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoLön)
                                    {
                                        KontoLön -= transfer;

                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoLön}");
                                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte övertrassera ditt konto!");
                                    }

                                }
                                else if (ÖverföringInput == 2)
                                {
                                    Console.WriteLine("Hur mycket vill du ta ut?");
                                    var transfer = Convert.ToInt32(Console.ReadLine());
                                    if (transfer < KontoSpar)
                                    {
                                        KontoSpar -= transfer;
                                        Console.WriteLine($"Du har tagit ut {transfer} kr från {KontoSpar}");
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
    }
}


        
    
        
    