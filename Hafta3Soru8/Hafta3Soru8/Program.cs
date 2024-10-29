using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru8
{
    class Program
    {
        static void Main()
        {
            Console.Write("Şifrelenmiş mesajı girin: ");
            string sifreliMesaj = Console.ReadLine();
            string cozulmusMesaj = MesajCoz(sifreliMesaj);
            Console.WriteLine("Çözülmüş mesaj: " + cozulmusMesaj);
            Console.ReadLine();
        }

        static string MesajCoz(string sifreliMesaj)
        {
            StringBuilder cozulmus = new StringBuilder();
            int[] fibonacciDizisi = FibonacciOlustur(sifreliMesaj.Length);

            for (int i = 0; i < sifreliMesaj.Length; i++)
            {
                int pozisyon = i + 1;
                int asciiDeger = (int)sifreliMesaj[i];

                if (AsalMi(pozisyon))
                    asciiDeger = ModIsleminiTersCevir(asciiDeger, 100);
                else
                    asciiDeger = ModIsleminiTersCevir(asciiDeger, 256);

                asciiDeger = asciiDeger / fibonacciDizisi[i];
                cozulmus.Append((char)asciiDeger);
            }

            return cozulmus.ToString();
        }

        static int[] FibonacciOlustur(int uzunluk)
        {
            int[] fibonacci = new int[uzunluk];
            fibonacci[0] = 1;
            if (uzunluk > 1)
                fibonacci[1] = 1;

            for (int i = 2; i < uzunluk; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];

            return fibonacci;
        }

        static bool AsalMi(int sayi)
        {
            if (sayi < 2) return false;
            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0) return false;
            }
            return true;
        }

        static int ModIsleminiTersCevir(int deger, int modulus)
        {
            int orijinal = deger;
            while (true)
            {
                if (orijinal % modulus == deger)
                    return orijinal;
                orijinal += modulus;
            }
        }
    }
}
