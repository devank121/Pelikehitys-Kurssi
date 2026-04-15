using System;
using System.Collections.Generic;

// ========================
// BASE CLASS
// ========================
class Tavara
{
    public float Paino { get; }
    public float Tilavuus { get; }

    public Tavara(float paino, float tilavuus)  //da cunstructor
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

// SPECIFIC ITEMS
class Nuoli : Tavara
{
    public Nuoli() : base(0.1f, 0.05f) { }

    public override string ToString()
    {
        return "Nuoli";
    }
}

class Jousi : Tavara
{
    public Jousi() : base(1.0f, 4.0f) { }

    public override string ToString()
    {
        return "Jousi";
    }
}

class Köysi : Tavara
{
    public Köysi() : base(1.0f, 1.5f) { }

    public override string ToString()
    {
        return "Köysi";
    }
}

class Vesi : Tavara
{
    public Vesi() : base(2.0f, 2.0f) { }

    public override string ToString()
    {
        return "Vesi";
    }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1.0f, 0.5f) { }

    public override string ToString()
    {
        return "Ruoka-annos";
    }
}

class Miekka : Tavara
{
    public Miekka() : base(5.0f, 3.0f) { }

    public override string ToString()
    {
        return "Miekka";
    }
}

// BACKPACK CLASS
class Reppu
{
    private int maksimiMaara;
    private float maksimiPaino;
    private float maksimiTilavuus;

    private List<Tavara> tavarat = new List<Tavara>();

    public Reppu(int maksimiMaara, float maksimiPaino, float maksimiTilavuus)
    {
        this.maksimiMaara = maksimiMaara;
        this.maksimiPaino = maksimiPaino;
        this.maksimiTilavuus = maksimiTilavuus;
    }

    // How many items are currently in the backpack
    public int TavaroidenMaara
    {
        get { return tavarat.Count; }
    }

    // Total weight of all items currently in backpack
    public float YhteenlasPaino    //calculates the total weight in tha bag
    {
        get
        {
            float yhteensa = 0f; //sets the bag to 0 first
            foreach (Tavara t in tavarat)  //t is just a temp variable
            {
                yhteensa += t.Paino;
            }
            return yhteensa;
        }
    }

    // Total volume of all items currently in backpack
    public float YhteenlaskettuTilavuus
    {
        get
        {
            float yhteensa = 0f;
            foreach (Tavara t in tavarat)
            {
                yhteensa += t.Tilavuus;
            }
            return yhteensa;
        }
    }

    // Try to add an item - returns true if added, false if backpack is full
    public bool Lisää(Tavara tavara)
    {
        if (TavaroidenMaara + 1 > maksimiMaara)
        {
            return false;
        }
        if (YhteenlasPaino + tavara.Paino > maksimiPaino)
        {
            return false;
        }
        if (YhteenlaskettuTilavuus + tavara.Tilavuus > maksimiTilavuus)
        {
            return false;
        }

        tavarat.Add(tavara);
        return true;
    }

    // Returns the backpack contents as a string
    public override string ToString()
    {
        if (tavarat.Count == 0)
        {
            return "Reppu on tyhjä.";
        }

        string sisalto = "Reppussa on seuraavat tavarat: ";

        foreach (Tavara t in tavarat)
        {
            sisalto += t.ToString() + ", ";
        }

        // Remove the trailing ", " from the end
        sisalto = sisalto.TrimEnd(',', ' ');

        return sisalto;
    }

    // Print the current backpack status
    public void NäytäTila()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("REPPU:");
        Console.WriteLine("Tavarat:  " + TavaroidenMaara + " / " + maksimiMaara);
        Console.WriteLine("Paino:    " + YhteenlasPaino + " / " + maksimiPaino + " kg");
        Console.WriteLine("Tilavuus: " + YhteenlaskettuTilavuus + " / " + maksimiTilavuus + " L");
        Console.WriteLine("-----------------------------");
    }
}


// MAIN PROGRAM

class Program
{
    static void Main()
    {
        // Create backpack with limits: 10 items, 10kg, 15L
        Reppu reppu = new Reppu(10, 10.0f, 15.0f);

        // Print backpack contents before the menu starts
        Console.WriteLine(reppu.ToString());

        bool running = true;

        while (running)
        {
            reppu.NäytäTila();
            Console.WriteLine("Valitse tavara lisättäväksi:");
            Console.WriteLine("1. Nuoli       (0.1kg, 0.05L)");
            Console.WriteLine("2. Jousi       (1kg,   4L)");
            Console.WriteLine("3. Köysi       (1kg,   1.5L)");
            Console.WriteLine("4. Vesi        (2kg,   2L)");
            Console.WriteLine("5. Ruoka-annos (1kg,   0.5L)");
            Console.WriteLine("6. Miekka      (5kg,   3L)");
            Console.WriteLine("0. Lopeta");
            Console.Write("Valinta: ");

            string valinta = Console.ReadLine();

            if (valinta == "1")
            {
                Tavara tavara = new Nuoli();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Nuoli lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "2")
            {
                Tavara tavara = new Jousi();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Jousi lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "3")
            {
                Tavara tavara = new Köysi();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Köysi lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "4")
            {
                Tavara tavara = new Vesi();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Vesi lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "5")
            {
                Tavara tavara = new RuokaAnnos();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Ruoka-annos lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "6")
            {
                Tavara tavara = new Miekka();
                bool onnistui = reppu.Lisää(tavara);
                if (onnistui)
                    Console.WriteLine(" Miekka lisätty!\n");
                else
                    Console.WriteLine(" Ei mahdu reppuun!\n");
            }
            else if (valinta == "0")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.\n");
            }
        }

        Console.WriteLine("\nPeli lopetettu. Näkemiin!");
    }
}