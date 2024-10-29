using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru3
{
    class Program
    {

        public static List<int> SayiListesi()
        {
            List<int> SayiListesi = new List<int>();

            Console.WriteLine("Sayıları girin:");

            int girilenSayi = Convert.ToInt32(Console.ReadLine());

            while (girilenSayi != 0)
            {
                SayiListesi.Add(girilenSayi);
                girilenSayi = Convert.ToInt32(Console.ReadLine());
            }
            SayiListesi.Sort();

            return SayiListesi;
        }

        static void ArdisikGruplariBul(List<int> sayilar)
        {
            if (sayilar.Count < 2)
            {
                Console.WriteLine("Ardışık grup bulunamadı. En az 2 sayı gerekli.");
                return;
            }

            int baslangic = sayilar[0];
            int oncekiSayi = sayilar[0];
            bool grupBulundu = false;

            for (int i = 1; i <= sayilar.Count; i++)
            {
                if (i == sayilar.Count || sayilar[i] != oncekiSayi + 1)
                {
                    if (baslangic != oncekiSayi)
                    {
                        Console.WriteLine($"Ardışık Grup: {baslangic}-{oncekiSayi}");
                        grupBulundu = true;
                    }

                    if (i < sayilar.Count)
                    {
                        baslangic = sayilar[i];
                    }
                }

                if (i < sayilar.Count)
                {
                    oncekiSayi = sayilar[i];
                }
            }

            if (!grupBulundu)
            {
                Console.WriteLine("Ardışık grup bulunamadı.");
            }
        }



        static void Main(string[] args)
        {
            List<int> Listem = new List<int>();

            Listem=SayiListesi();

            ArdisikGruplariBul(Listem);
            Console.ReadLine();

        }
    }
}
