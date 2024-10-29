using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zarva Labirent Çözücü");
            Console.WriteLine("---------------------");

            Console.Write("Labirent genişliğini girin (M): ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Labirent yüksekliğini girin (N): ");
            int n = int.Parse(Console.ReadLine());

            bool[,] labirent = new bool[m, n];
            bool[,] ziyaretEdildi = new bool[m, n];
            List<string> yol = new List<string>();

            // Labirenti oluştur
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    labirent[i, j] = KapiKontrol(i, j);
                }
            }

            // Yolu bul
            if (YolBul(0, 0, m - 1, n - 1, labirent, ziyaretEdildi, yol))
            {
                Console.WriteLine("\nŞehre giden yol bulundu!");
                Console.WriteLine("Yol adımları:");
                foreach (string adim in yol)
                {
                    Console.WriteLine(adim);
                }
            }
            else
            {
                Console.WriteLine("\nŞehir kayboldu!");
            }
            Console.ReadLine();
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

        static bool BasamaklarAsalMi(int sayi)
        {
            while (sayi > 0)
            {
                if (!AsalMi(sayi % 10)) return false;
                sayi /= 10;
            }
            return true;
        }

        static bool KapiKontrol(int x, int y)
        {
            if (!BasamaklarAsalMi(x) || !BasamaklarAsalMi(y))
                return false;

            int toplam = x + y;
            int carpim = x * y;

            if (carpim == 0) return true;
            return toplam % carpim == 0;
        }

        static bool YolBul(int x, int y, int hedefX, int hedefY, bool[,] labirent,
                          bool[,] ziyaretEdildi, List<string> yol)
        {
            if (x < 0 || x >= labirent.GetLength(0) || y < 0 || y >= labirent.GetLength(1))
                return false;

            if (!labirent[x, y] || ziyaretEdildi[x, y])
                return false;

            ziyaretEdildi[x, y] = true;
            yol.Add($"({x}, {y})");

            if (x == hedefX && y == hedefY)
                return true;

            int[] hareketX = { 1, 0, -1, 0 };
            int[] hareketY = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int yeniX = x + hareketX[i];
                int yeniY = y + hareketY[i];

                if (YolBul(yeniX, yeniY, hedefX, hedefY, labirent, ziyaretEdildi, yol))
                    return true;
            }

            yol.RemoveAt(yol.Count - 1);
            return false;
        }
    }
}
