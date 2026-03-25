using System;

enum KarkiTyyppi  // makes the tip types in to enum
{
    Puu,
    Teras,
    Timantti
}

enum PeranTyyppi // makes the back types into enum
{
    Lehti,
    Kanansulka,
    Kotkansulka
}

class Nuoli
{
    public KarkiTyyppi Karki { get; }  //gets the types from the enum created before
    public PeranTyyppi Pera { get; }   // same thing but with the back types
    public int Pituus { get; }         //gets the height from the user with the constructorgit

    public Nuoli(KarkiTyyppi karki, PeranTyyppi pera, int pituus)  //the contruto, gets the answers from the user and saves it in a temporarry varieble
    {
        Karki = karki;
        Pera = pera;
        Pituus = pituus;
    }

    public int PalautaHinta() //price calculation
    {
        int hinta = 0;   //sets the hinta at 0 from start

        // Kärjen hinta
        switch (Karki) //switch is basically a "multi-if" its like a shortcut instead of writing 'if' for everthying you can just do it this way.
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

        Nuoli nuoli = new Nuoli(karki, pera, pituus); //makes a new arrow with the users option chose

        Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultarahaa."); // and this returns to the user.
    }
}