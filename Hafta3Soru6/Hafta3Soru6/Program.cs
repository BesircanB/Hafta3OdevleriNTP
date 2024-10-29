using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zaman Makinesi Tarih Hesaplayıcı");
            Console.WriteLine("--------------------------------");

            // Şimdiki zamanı al
            DateTime simdikiZaman = DateTime.Now;
            List<string> uygunTarihler = new List<string>();

            // 2000-3000 yılları arasını kontrol et
            for (int yil = 2000; yil <= 3000; yil++)
            {
                // Yıl kontrolü
                if (!YilKontrol(yil)) continue;

                // 12 ay için kontrol
                for (int ay = 1; ay <= 12; ay++)
                {
                    // Ay kontrolü
                    if (!AyKontrol(ay)) continue;

                    // O aydaki gün sayısını bul
                    int gunSayisi = DateTime.DaysInMonth(yil, ay);

                    // Günleri kontrol et
                    for (int gun = 1; gun <= gunSayisi; gun++)
                    {
                        // Gün kontrolü
                        if (!GunKontrol(gun)) continue;

                        // Tarih oluştur
                        DateTime tarih = new DateTime(yil, ay, gun);

                        // Geçmiş tarihleri atlama kontrolü
                        if (tarih <= simdikiZaman) continue;

                        // Tüm koşullar sağlandıysa listeye ekle
                        uygunTarihler.Add($"{gun}/{ay}/{yil}");
                    }
                }
            }

            // Sonuçları yazdır
            Console.WriteLine("\nUygun Tarihler:");
            Console.WriteLine("----------------");
            foreach (string tarih in uygunTarihler)
            {
                Console.WriteLine(tarih);
            }
            Console.WriteLine($"\nToplam {uygunTarihler.Count} adet uygun tarih bulundu.");
            Console.ReadLine();
        }

        // Günün asal sayı olup olmadığını kontrol et
        static bool GunKontrol(int gun)
        {
            if (gun < 2) return false;
            for (int i = 2; i <= Math.Sqrt(gun); i++)
            {
                if (gun % i == 0) return false;
            }
            return true;
        }

        // Ay rakamları toplamının çift olup olmadığını kontrol et
        static bool AyKontrol(int ay)
        {
            int toplam = 0;
            string ayString = ay.ToString();
            foreach (char rakam in ayString)
            {
                toplam += int.Parse(rakam.ToString());
            }
            return toplam % 2 == 0;
        }

        // Yıl rakamları toplamının yılın dörtte birinden küçük olup olmadığını kontrol et
        static bool YilKontrol(int yil)
        {
            int toplam = 0;
            string yilString = yil.ToString();
            foreach (char rakam in yilString)
            {
                toplam += int.Parse(rakam.ToString());
            }
            return toplam < (yil / 4.0);
        }
    }
}
