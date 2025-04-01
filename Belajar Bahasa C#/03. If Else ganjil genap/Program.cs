// See https://aka.ms/new-console-template for more information
using System;

class IfElseExample
{
    static void Main()
    {
        Console.Write("Masukkan angka: ");
        int angka = Convert.ToInt32(Console.ReadLine());
        
        if (angka % 2 == 0)
        {
            Console.WriteLine("Angka genap.");
        }
        else
        {
            Console.WriteLine("Angka ganjil.");
        }
    }
}

