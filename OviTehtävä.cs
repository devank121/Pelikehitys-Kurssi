using System;

class Program
{
    // Enum oven tiloille
    enum OvenTila
    {
        Auki,
        Kiinni,
        Lukossa
    }

    // Enum toiminnoille
    enum Toiminto
    {
        Avaa = 1,
        Sulje = 2,
        Lukitse = 3,
        PoistaLukitus = 4
    }

    static void Main(string[] args)
    {
        // Oven alkutila
        OvenTila ovi = OvenTila.Kiinni;

        // Ikuinen silmukka
        while (true)
        {
            Console.WriteLine($"\nOvi on {ovi}. Mitä haluat tehdä?");
            Console.WriteLine("1 - Avaa");
            Console.WriteLine("2 - Sulje");
            Console.WriteLine("3 - Lukitse");
            Console.WriteLine("4 - Poista lukitus");

            string syote = Console.ReadLine();

            if (int.TryParse(syote, out int valinta))
            {
                if (Enum.IsDefined(typeof(Toiminto), valinta))
                {
                    Toiminto toiminto = (Toiminto)valinta;
                    bool onnistui = false;

                    switch (toiminto)
                    {
                        case Toiminto.Avaa:
                            if (ovi == OvenTila.Kiinni)
                            {
                                ovi = OvenTila.Auki;
                                onnistui = true;
                            }
                            break;

                        case Toiminto.Sulje:
                            if (ovi == OvenTila.Auki)
                            {
                                ovi = OvenTila.Kiinni;
                                onnistui = true;
                            }
                            break;

                        case Toiminto.Lukitse:
                            if (ovi == OvenTila.Kiinni)
                            {
                                ovi = OvenTila.Lukossa;
                                onnistui = true;
                            }
                            break;

                        case Toiminto.PoistaLukitus:
                            if (ovi == OvenTila.Lukossa)
                            {
                                ovi = OvenTila.Kiinni;
                                onnistui = true;
                            }
                            break;
                    }

                    if (onnistui)
                        Console.WriteLine("Toiminto onnistui!");
                    else
                        Console.WriteLine("Toiminto ei onnistunut!");
                }
                else
                {
                    Console.WriteLine("Virheellinen valinta.");
                }
            }
            else
            {
                Console.WriteLine("Syötä numero.");
            }
        }
    }
}