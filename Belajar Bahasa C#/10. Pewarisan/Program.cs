// See https://aka.ms/new-console-template for more information
using System;

class Kendaraan
{
    public string Merk;
    public int Tahun;

    public void TampilkanInfo()
    {
        Console.WriteLine("Merk: " + Merk);
        Console.WriteLine("Tahun: " + Tahun);
    }
}

class Mobil : Kendaraan
{
    public int JumlahPintu;

    public void TampilkanDetail()
    {
        TampilkanInfo();
        Console.WriteLine("Jumlah Pintu: " + JumlahPintu);
    }
}

class InheritanceExample
{
    static void Main()
    {
        Mobil myCar = new Mobil();
        myCar.Merk = "Toyota";
        myCar.Tahun = 2022;
        myCar.JumlahPintu = 4;

        Console.WriteLine("Data Mobil:");
        myCar.TampilkanDetail();
    }
}
