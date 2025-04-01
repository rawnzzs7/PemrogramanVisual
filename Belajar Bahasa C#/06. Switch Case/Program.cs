// See https://aka.ms/new-console-template for more information
using System;

class SwitchCaseExample
{
    static void Main()
    {
        Console.Write("Masukkan angka (1-3): ");
        int pilihan = Convert.ToInt32(Console.ReadLine());

        switch (pilihan)
        {
            case 1:
                Console.WriteLine("Anda memilih angka satu.");
                break;
            case 2:
                Console.WriteLine("Anda memilih angka dua.");
                break;
            case 3:
                Console.WriteLine("Anda memilih angka tiga.");
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;
        }
    }
}
