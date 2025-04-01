// See https://aka.ms/new-console-template for more information
using System;

class ArrayExample
{
    static void Main()
    {
        string[] buah = { "Apel", "Mangga", "Pisang", "Jeruk" };

        Console.WriteLine("Daftar buah:");
        foreach (string item in buah)
        {
            Console.WriteLine("- " + item);
        }
    }
}
