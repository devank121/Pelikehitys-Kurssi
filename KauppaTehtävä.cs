using System;

enum KarkiTyyppi
{
    Puu,
    Teras,
    Timantti
}

enum PeranTyyppi
{
    Lehti,
    Kanansulka,
    Kotkansulka
}

class Nuoli
{
    public KarkiTyyppi Karki { get; }
    public PeranTyyppi Pera { get; }
    public int Pituus { get; }

    public Nuoli(KarkiTyyppi karki, PeranTyyppi pera, int pituus)
    {
        Karki = karki;
        Pera = pera;
        Pituus = pituus;
    }

    public int PalautaHinta()
    {
        int hinta = 0;

        // Kärjen hinta
        switch (Karki)
        {
            case KarkiTyyppi.Puu: hinta += 3; break;
            case KarkiTyyppi.Teras: hinta += 5; break;
            case KarkiTyyppi.Timantti: hinta += 50; break;
        }

        // Perän hinta
        switch (Pera)
        {
            case PeranTyyppi.Lehti: hinta += 0; break;
            case PeranTyyppi.Kanansulka: hinta += 1; break;
            case PeranTyyppi.Kotkansulka: hinta += 5; break;
        }

        // Varren hinta (0.05 per cm)
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
            "teras" => KarkiTyyppi.Teras, // in case user types without umlaut
            "timantti" => KarkiTyyppi.Timantti,
            _ => KarkiTyyppi.Puu
        };

        PeranTyyppi pera = peraInput switch
        {
            "lehti" => PeranTyyppi.Lehti,
            "kanansulka" => PeranTyyppi.Kanansulka,
            "kotkansulka" => PeranTyyppi.Kotkansulka,
            _ => PeranTyyppi.Lehti
        };

        Nuoli nuoli = new Nuoli(karki, pera, pituus);

        Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultarahaa.");
    }
}