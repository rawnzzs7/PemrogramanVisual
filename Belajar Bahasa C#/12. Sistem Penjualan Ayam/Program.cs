using System;

namespace SistemPenjualanAyam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menampilkan Judul Program
            Console.WriteLine("=== Sistem Penjualan Ayam ===");
            
            // Meminta input dari pengguna
            Console.Write("Masukkan jumlah ayam yang dibeli: ");
            int jumlahAyam = int.Parse(Console.ReadLine());
            
            Console.Write("Masukkan harga per ekor ayam: ");
            double hargaPerAyam = double.Parse(Console.ReadLine());
            
            Console.Write("Masukkan diskon (%) (jika tidak ada, masukkan 0): ");
            double diskonPersen = double.Parse(Console.ReadLine());

            // Menghitung total harga tanpa diskon
            double totalHarga = jumlahAyam * hargaPerAyam;
            
            // Menghitung diskon yang diberikan
            double diskon = (diskonPersen / 100) * totalHarga;

            // Menghitung total harga setelah diskon
            double totalSetelahDiskon = totalHarga - diskon;

            // Menampilkan hasil perhitungan
            Console.WriteLine("\n=== Detail Pembelian ===");
            Console.WriteLine($"Jumlah Ayam        : {jumlahAyam} ekor");
            Console.WriteLine($"Harga per Ayam     : Rp {hargaPerAyam}");
            Console.WriteLine($"Diskon             : {diskonPersen}%");
            Console.WriteLine($"Total Harga        : Rp {totalHarga}");
            Console.WriteLine($"Diskon             : Rp {diskon}");
            Console.WriteLine($"Total setelah Diskon: Rp {totalSetelahDiskon}");

            // Menunggu input dari pengguna sebelum menutup aplikasi
            Console.WriteLine("\nTekan tombol apa saja untuk keluar...");
            Console.ReadKey();
        }
    }
}
