using System;

enum KarkiTyyppi  // makes the tip types in to enum
{
    Puu,
    Teras,
    Timantti
}

enum PeranTyyppi  // makes the back types into enum
{
    Lehti,
    Kanansulka,
    Kotkansulka
}

class Nuoli
{
    public KarkiTyyppi Karki { get; }  //gets the types from the enum created before
    public PeranTyyppi Pera { get; }   // same thing but with the back types
    public int Pituus { get; }         //gets the height from the user with the constructor

    // changed from private to public so the static methods can use it from outside
    public Nuoli(KarkiTyyppi karki, PeranTyyppi pera, int pituus)  //the constructor, gets the answers from the user and saves it in a temporary variable
    {
        Karki = karki;
        Pera = pera;
        Pituus = pituus;
    }

    // static preset methods, these are "shortcut builders"
    // you call them like: Nuoli.LuoEliittiNuoli()
    // they create a Nuoli with fixed values, no user input needed
    public static Nuoli LuoEliittiNuoli()
    {
        return new Nuoli(KarkiTyyppi.Timantti, PeranTyyppi.Kotkansulka, 100);
    }

    public static Nuoli LuoAloittelijaNuoli()
    {
        return new Nuoli(KarkiTyyppi.Puu, PeranTyyppi.Kanansulka, 70);
    }

    public static Nuoli LuoPerusNuoli()
    {
        return new Nuoli(KarkiTyyppi.Teras, PeranTyyppi.Kanansulka, 85);
    }

    public int PalautaHinta() //price calculation
    {
        int hinta = 0;   //sets the hinta at 0 from start

        // Kärjen hinta
        switch (Karki) //switch is basically a "multi-if" its like a shortcut instead of writing 'if' for everything you can just do it this way.
        {
            case KarkiTyyppi.Puu: hinta += 3; break; // adds 3 to the og price which was 0
            case KarkiTyyppi.Teras: hinta += 5; break; // same thing diff price
            case KarkiTyyppi.Timantti: hinta += 50; break; // same thing diff price
        }

        // Perän hinta
        switch (Pera) // same thing but with the back instead of the tip
        {
            case PeranTyyppi.Lehti: hinta += 0; break;
            case PeranTyyppi.Kanansulka: hinta += 1; break;
            case PeranTyyppi.Kotkansulka: hinta += 5; break;
        }

        // sticks hinta (0.05 per cm)
        hinta += (int)(Pituus * 0.05);
        return hinta;
    }
}

class Program
{
    static void Main()
    {
        // loop so the user can keep buying arrows, runs forever until program is closed
        while (true)
        {
            Console.WriteLine("\nTervetuloa nuolikauppaan. Haluatko:");
            Console.WriteLine("1. Teettää nuolen tilaustyönä?");
            Console.WriteLine("2. Ostaa valmiin nuolen?");
            Console.Write("Valinta: ");
            string valinta = Console.ReadLine();

            Nuoli nuoli = null; // empty nuoli variable, gets filled depending on what the user picks

            if (valinta == "1")
            {
                Console.Write("Minkälainen kärki (puu, teräs, timantti)?: ");
                string karkiInput = Console.ReadLine().ToLower();
                Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
                string peraInput = Console.ReadLine().ToLower();
                Console.Write("Nuolen pituus sentteinä (60-100): ");
                int pituus = int.Parse(Console.ReadLine());

                KarkiTyyppi karki = karkiInput switch
                {
                    "puu" => KarkiTyyppi.Puu,
                    "teräs" => KarkiTyyppi.Teras,
                    "teras" => KarkiTyyppi.Teras,
                    "timantti" => KarkiTyyppi.Timantti,
                    _ => KarkiTyyppi.Puu // makes it so if user types anything other than the options it defaults back to puu
                };

                PeranTyyppi pera = peraInput switch
                {
                    "lehti" => PeranTyyppi.Lehti,
                    "kanansulka" => PeranTyyppi.Kanansulka,
                    "kotkansulka" => PeranTyyppi.Kotkansulka,
                    _ => PeranTyyppi.Lehti  //same thing as the puu but with leaf
                };

                nuoli = new Nuoli(karki, pera, pituus); //makes a new arrow with the users option chose
            }
            else if (valinta == "2")
            {
                // show the preset options and call the matching static method
                Console.WriteLine("Valitse valmis nuoli:");
                Console.WriteLine("1. Eliittinuoli");
                Console.WriteLine("2. Aloittelijanuoli");
                Console.WriteLine("3. Perusnuoli");
                Console.Write("Valinta: ");
                string nuolivalinta = Console.ReadLine();

                if (nuolivalinta == "1")
                    nuoli = Nuoli.LuoEliittiNuoli();      // calls the static method for elite arrow
                else if (nuolivalinta == "2")
                    nuoli = Nuoli.LuoAloittelijaNuoli();  // calls the static method for beginner arrow
                else if (nuolivalinta == "3")
                    nuoli = Nuoli.LuoPerusNuoli();        // calls the static method for basic arrow
                else
                {
                    Console.WriteLine("Virheellinen valinta.");
                    continue; // skips to the next loop round if input was wrong
                }
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
                continue; // same here, skip to next round
            }

            Console.WriteLine($"Valitsemasi nuolen hinta on {nuoli.PalautaHinta()} kultarahaa."); // and this returns to the user.
        }
    }
}