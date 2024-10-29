using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru9
{
    class Program
    {
        static void Main()
        {
            Console.Write("Asteroit ızgarasının boyutunu girin (N): ");
            int boyut = int.Parse(Console.ReadLine());

            int[,] enerjiMatrisi = new int[boyut, boyut];

            // Enerji değerlerini kullanıcıdan al
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Console.Write($"[{i},{j}] koordinatı için enerji değeri: ");
                    enerjiMatrisi[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int enDusukEnerji = EnDusukEnerjiYolunuBul(enerjiMatrisi);
            Console.WriteLine($"En düşük enerji maliyeti: {enDusukEnerji}");

            // En düşük enerji yolunu göster
            YoluGoster(enerjiMatrisi);
            Console.ReadLine();
        }

        static int EnDusukEnerjiYolunuBul(int[,] enerjiMatrisi)
        {
            int boyut = enerjiMatrisi.GetLength(0);
            int[,] enDusukEnerji = new int[boyut, boyut];

            // İlk hücreyi başlangıç değeri olarak ata
            enDusukEnerji[0, 0] = enerjiMatrisi[0, 0];

            // İlk satırı doldur
            for (int j = 1; j < boyut; j++)
            {
                enDusukEnerji[0, j] = enDusukEnerji[0, j - 1] + enerjiMatrisi[0, j];
            }

            // İlk sütunu doldur
            for (int i = 1; i < boyut; i++)
            {
                enDusukEnerji[i, 0] = enDusukEnerji[i - 1, 0] + enerjiMatrisi[i, 0];
            }

            // Diğer hücreleri doldur
            for (int i = 1; i < boyut; i++)
            {
                for (int j = 1; j < boyut; j++)
                {
                    enDusukEnerji[i, j] = enerjiMatrisi[i, j] + MinimumBul(
                        enDusukEnerji[i - 1, j],     // Yukarıdan
                        enDusukEnerji[i, j - 1],     // Soldan
                        enDusukEnerji[i - 1, j - 1]  // Çaprazdan
                    );
                }
            }

            return enDusukEnerji[boyut - 1, boyut - 1];
        }

        static int MinimumBul(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }

        static void YoluGoster(int[,] enerjiMatrisi)
        {
            int boyut = enerjiMatrisi.GetLength(0);
            bool[,] yol = new bool[boyut, boyut];
            int[,] enDusukEnerji = new int[boyut, boyut];

            // En düşük enerji matrisini tekrar hesapla
            enDusukEnerji[0, 0] = enerjiMatrisi[0, 0];
            yol[0, 0] = true;

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Console.Write(yol[i, j] ? "* " : ". ");
                }
                Console.WriteLine();
            }
        }
    }
}
