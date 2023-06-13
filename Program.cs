using System;

class Program
{
    static void Main(string[] args)
    {
        int[] ervenyesCimletek = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5 };

        Console.WriteLine("Fizetendő összeg: ");
        int fizetendo = int.Parse(Console.ReadLine());

        Console.WriteLine("Átvett összeg: ");
        int atvett = int.Parse(Console.ReadLine());

        int visszajaro = atvett - fizetendo;

        Console.WriteLine("Visszajáró összeg: " + visszajaro);

        Console.WriteLine("Címletezve:");

        foreach (int cimlet in ervenyesCimletek)
        {
            int darab = visszajaro / cimlet;
            visszajaro %= cimlet;
            Console.WriteLine(darab + " x " + cimlet);
        }
    }
}
