using System;

class Program
{
    static void Main(string[] args)
    {
        int[] ervenyesCimletek = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5 };

        if (ervenyesCimletek.Length == 0)
        {
            Console.WriteLine("Hiba: Nincsenek érvényes címletek definiálva.");
            return;
        }

        Console.WriteLine("Fizetendő összeg: ");
        int fizetendo = ReadPositiveIntegerInput();

        Console.WriteLine("Átvett összeg: ");
        int atvett = ReadPositiveIntegerInput();

        if (atvett < fizetendo)
        {
            Console.WriteLine("Hiba: Az átvett összeg nem lehet kisebb a fizetendő összegnél.");
            return;
        }

        int visszajaro = atvett - fizetendo;

        Console.WriteLine("Visszajáró összeg (előtte kerekítve): " + visszajaro);

        Console.WriteLine("Címletezve:");
        PrintDenominations(visszajaro, ervenyesCimletek);

        Console.WriteLine("Pénztárca kezelése:");
        Console.WriteLine("Adja meg a rendelkezésre álló címleteket és azok mennyiségét!");

        int[] penztarcaCimletek = new int[ervenyesCimletek.Length];
        for (int i = 0; i < ervenyesCimletek.Length; i++)
        {
            Console.Write("Címlet: " + ervenyesCimletek[i] + " - Mennyiség: ");
            penztarcaCimletek[i] = ReadNonNegativeIntegerInput();
        }

        Console.WriteLine("Fizetendő összeg: ");
        fizetendo = ReadPositiveIntegerInput();

        if (atvett < fizetendo)
        {
            Console.WriteLine("Hiba: Az átvett összeg nem lehet kisebb a fizetendő összegnél.");
            return;
        }

        visszajaro = atvett - fizetendo;

        Console.WriteLine("Visszajáró összeg (utána kerekítve): " + visszajaro);

        Console.WriteLine("Címletezve:");
        PrintDenominations(visszajaro, ervenyesCimletek);

        UpdateWallet(penztarcaCimletek, visszajaro);

        Console.WriteLine("Pénztárca frissítése:");
        PrintDenominationsInWallet(penztarcaCimletek, ervenyesCimletek);
    }

    static int ReadPositiveIntegerInput()
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input) && input >= 0)
            {
                return input;
            }
            Console.WriteLine("Hiba: Kérem, adjon meg egy nemnegatív egész számot.");
        }
    }

    static int ReadNonNegativeIntegerInput()
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input) && input >= 0)
            {
                return input;
            }
            Console.WriteLine("Hiba: Kérem, adjon meg egy nemnegatív egész számot.");
        }
    }

    static void PrintDenominations(int visszajaro, int[] cimletek)
    {
        foreach (int cimlet in cimletek)
        {
            if (visszajaro == 0)
            {
                break;
            }

            int darab = visszajaro / cimlet;
            visszajaro %= cimlet;

            Console.WriteLine(darab + " x " + cimlet);
        }
    }

    static void PrintDenominationsInWallet(int[] penztarcaCimletek, int[] ervenyesCimletek)
    {
        for (int i = 0; i < penztarcaCimletek.Length; i++)
        {
            Console.WriteLine("Címlet: " + ervenyesCimletek[i] + " - Mennyiség: " + penztarcaCimletek[i]);
        }
    }

    static void UpdateWallet(int[] penztarcaCimletek, int visszajaro)
    {
        for (int i = penztarcaCimletek.Length - 1; i >= 0; i--)
        {
            if (visszajaro == 0)
            {
                break;
            }

            int darab = visszajaro / penztarcaCimletek[i];
            darab = Math.Min(darab, penztarcaCimletek[i]);

            visszajaro -= darab * penztarcaCimletek[i];
            penztarcaCimletek[i] -= darab;
        }
    }
}
