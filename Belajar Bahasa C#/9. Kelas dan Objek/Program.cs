// See https://aka.ms/new-console-template for more information
using System;

class Mahasiswa
{
    public string Nama;
    public string NPM;

    public void TampilkanInfo()
    {
        Console.WriteLine("Nama: " + Nama);
        Console.WriteLine("NPM: " + NPM);
    }
}

class ClassExample
{
    static void Main()
    {
        Mahasiswa mhs = new Mahasiswa();
        mhs.Nama = "Ragil Karnoto";
        mhs.NPM = "2213020098";

        Console.WriteLine("Data Mahasiswa:");
        mhs.TampilkanInfo();
    }
}
