using System;

using System.Collections.Generic;

namespace ConsoleApp2

{

    // Enums

    enum PaaraakaAine

    {

        Nautaa,

        Kanaa,

        Kasviksia

    }

    enum Lisuke

    {

        Perunaa,

        Riisia,

        Pastaa

    }

    enum Kastike

    {

        Curry,

        Hapanimela,

        Pippuri,

        Chili

    }

    // Class Ateria

    class Ateria

    {

        public PaaraakaAine PaaraakaAine { get; set; }

        public Lisuke Lisuke { get; set; }

        public Kastike Kastike { get; set; }

        public void Tulosta()

        {

            Console.WriteLine($"{PaaraakaAine} ja {Lisuke} {Kastike}-kastikkeella");a

        }

    }

    internal class Program

    {

        static void Main(string[] args)

        {

            List<Ateria> ateriat = new List<Ateria>();

            Console.WriteLine("Tervetuloa ravintolaan!");

            // BONUS: create three meals

            for (int i = 0; i < 3; i++)

            {

                Console.WriteLine($"\nLuo ruoka-annos {i + 1}:");

                Ateria ateria = new Ateria();

                ateria.PaaraakaAine = KysyEnum<PaaraakaAine>("Valitse pääraaka-aine:");

                ateria.Lisuke = KysyEnum<Lisuke>("Valitse lisuke:");

                ateria.Kastike = KysyEnum<Kastike>("Valitse kastike:");

                ateriat.Add(ateria);

            }

            // BONUS CONTINUATION: print all meals

            Console.WriteLine("\nValitsemasi ruoka-annokset:");

            foreach (Ateria a in ateriat)

            {

                a.Tulosta();

            }

        }

        // Generic method for asking enum values

        static T KysyEnum<T>(string otsikko) where T : struct, Enum

        {

            while (true)

            {

                Console.WriteLine(otsikko);

                foreach (string nimi in Enum.GetNames(typeof(T)))

                {

                    Console.WriteLine("- " + nimi);

                }

                string vastaus = Console.ReadLine();

                if (Enum.TryParse(vastaus, true, out T tulos))

                {

                    return tulos;

                }

                Console.WriteLine("Virheellinen valinta, yritä uudelleen.\n");

            }

        }

    }

}

