using System;

// ========================
// INTERFACE (replaces abstract class)
// ========================
public interface IRobottiKäsky
{
    void Suorita(Robotti robotti); // no public, no abstract needed
}

// ========================
// ROBOT CLASS (uses IRobottiKäsky now)
// ========================
public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3]; // changed here

    public void Suorita()
    {
        foreach (IRobottiKäsky? käsky in Käskyt) // changed here
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

// ========================
// COMMANDS (use interface now, no override keyword)
// ========================
public class Käynnistä : IRobottiKäsky
{
    public void Suorita(Robotti robotti) // no override!
    {
        robotti.OnKäynnissä = true;
    }
}

public class Sammuta : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

public class YlösKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y += 1;
        }
    }
}

public class AlasKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y -= 1;
        }
    }
}

public class VasenKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X -= 1;
        }
    }
}

public class OikeaKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X += 1;
        }
    }
}

// ========================
// MAIN PROGRAM (exactly the same as before!)
// ========================
class Program
{
    static void Main()
    {
        Robotti robotti = new Robotti();

        Console.WriteLine("Anna kolme käskyä robotille:");
        Console.WriteLine("Vaihtoehdot: kaynnista, sammuta, ylos, alas, vasen, oikea");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Käsky " + (i + 1) + ": ");
            string syote = Console.ReadLine().ToLower().Trim();

            IRobottiKäsky käsky = null; // changed type here

            if (syote == "kaynnista")
                käsky = new Käynnistä();
            else if (syote == "sammuta")
                käsky = new Sammuta();
            else if (syote == "ylos")
                käsky = new YlösKäsky();
            else if (syote == "alas")
                käsky = new AlasKäsky();
            else if (syote == "vasen")
                käsky = new VasenKäsky();
            else if (syote == "oikea")
                käsky = new OikeaKäsky();
            else
            {
                Console.WriteLine("Tuntematon käsky, yritetään uudelleen.");
                i--;
                continue;
            }

            robotti.Käskyt[i] = käsky;
        }

        Console.WriteLine("\nRobotti suorittaa käskyt:");
        robotti.Suorita();
    }
}