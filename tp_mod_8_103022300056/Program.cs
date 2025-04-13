// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? (dalam satuan {config.satuan_suhu})");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu anda terkena Demam?");
        double hari = double.Parse(Console.ReadLine());

        bool suhuAman = false;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            suhuAman = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhuAman = suhu >= 97.7 && suhu <= 99.5;
        }

        bool jarakAman = hari <= config.batas_demam;

        if (suhuAman && jarakAman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        Console.WriteLine("\nApakah anda ingin mengubah satuan suhu? (y/n)");
        string jawab = Console.ReadLine();

        if (jawab.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan suhu berhasil diubah!");
        }
    }
}

