using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public double batas_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private static string filePath = "covid_config.json";

    public static CovidConfig LoadConfig()
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<CovidConfig>(jsonString);
        }
        else
        {
            CovidConfig defaultConfig = new CovidConfig
            {
                satuan_suhu = "celsius",
                batas_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilakan untuk masuk ke dalam gedung ini"
            };

            defaultConfig.SaveConfig();
            return defaultConfig;
        }
    }

    public void SaveConfig()
    {
        string jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }

    public void UbahSatuan()
    {
        if (satuan_suhu.ToLower() == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else
        {
            satuan_suhu = "celcius";
        }
        SaveConfig();
    }
}
