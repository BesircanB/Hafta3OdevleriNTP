using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polinom İşlemleri Programına Hoş Geldiniz!");
            Console.WriteLine("Çıkmak için 'exit' yazın");
            Console.WriteLine("Polinomları ax^2 + bx + c formatında girin (örnek: 2x^2 + 3x - 5)");

            while (true)
            {
                // İlk polinom girişi
                Console.Write("\nBirinci polinomu girin: ");
                string input1 = Console.ReadLine();

                // Çıkış kontrolü
                if (input1.ToLower() == "exit")
                    break;

                // İkinci polinom girişi
                Console.Write("İkinci polinomu girin: ");
                string input2 = Console.ReadLine();

                // Polinomları parçalara ayır
                int[] polinom1 = PolinomParcala(input1);
                int[] polinom2 = PolinomParcala(input2);

                // Toplama işlemi
                int[] toplam = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    toplam[i] = polinom1[i] + polinom2[i];
                }

                // Çıkarma işlemi
                int[] fark = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    fark[i] = polinom1[i] - polinom2[i];
                }

                // Sonuçları yazdır
                Console.WriteLine("\nSonuçlar:");
                Console.Write("Toplam: ");
                PolinomYazdir(toplam);
                Console.Write("Fark: ");
                PolinomYazdir(fark);
            }

            Console.WriteLine("Program sonlandırıldı.");
        }

        static int[] PolinomParcala(string polinom)
        {
            // Katsayıları tutacak dizi [x^2 katsayısı, x katsayısı, sabit terim]
            int[] katsayilar = new int[3];

            // Boşlukları kaldır
            polinom = polinom.Replace(" ", "");

            try
            {
                // x^2 terimini bul
                if (polinom.Contains("x^2"))
                {
                    int index = polinom.IndexOf("x^2");
                    string katsayi = polinom.Substring(0, index);
                    if (katsayi == "" || katsayi == "+") katsayi = "1";
                    if (katsayi == "-") katsayi = "-1";
                    katsayilar[0] = int.Parse(katsayi);
                    polinom = polinom.Substring(index + 3);
                }

                // x terimini bul
                if (polinom.Contains("x"))
                {
                    int index = polinom.IndexOf("x");
                    string katsayi = "";
                    if (index == 0) katsayi = "1";
                    else
                    {
                        katsayi = polinom.Substring(0, index);
                        if (katsayi == "+" || katsayi == "") katsayi = "1";
                        if (katsayi == "-") katsayi = "-1";
                    }
                    katsayilar[1] = int.Parse(katsayi);
                    polinom = polinom.Substring(index + 1);
                }

                // Sabit terimi bul
                if (polinom != "")
                {
                    katsayilar[2] = int.Parse(polinom);
                }
            }
            catch
            {
                Console.WriteLine("Hatalı polinom girişi! Varsayılan değerler kullanılacak.");
                return new int[] { 0, 0, 0 };
            }

            return katsayilar;
        }

        static void PolinomYazdir(int[] katsayilar)
        {
            bool ilkTerimYazildi = false;

            // x^2 terimi
            if (katsayilar[0] != 0)
            {
                if (katsayilar[0] == 1)
                    Console.Write("x^2");
                else if (katsayilar[0] == -1)
                    Console.Write("-x^2");
                else
                    Console.Write($"{katsayilar[0]}x^2");
                ilkTerimYazildi = true;
            }

            // x terimi
            if (katsayilar[1] != 0)
            {
                if (ilkTerimYazildi)
                {
                    Console.Write(katsayilar[1] > 0 ? " + " : " - ");
                    if (Math.Abs(katsayilar[1]) == 1)
                        Console.Write("x");
                    else
                        Console.Write($"{Math.Abs(katsayilar[1])}x");
                }
                else
                {
                    if (katsayilar[1] == 1)
                        Console.Write("x");
                    else if (katsayilar[1] == -1)
                        Console.Write("-x");
                    else
                        Console.Write($"{katsayilar[1]}x");
                }
                ilkTerimYazildi = true;
            }

            // Sabit terim
            if (katsayilar[2] != 0)
            {
                if (ilkTerimYazildi)
                    Console.Write(katsayilar[2] > 0 ? " + " : " - ");
                Console.Write($"{Math.Abs(katsayilar[2])}");
            }

            // Eğer tüm terimler sıfırsa
            if (!ilkTerimYazildi && katsayilar[2] == 0)
            {
                Console.Write("0");
            }

            Console.WriteLine();
        }
    }
}
