using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru1
{
    class Program
    {

        public static void SiralaDizi(int[] dizi)
        {
            for(int i = 0; i < dizi.Length-1; i++)
            {
                for(int j = 0; j < dizi.Length - i - 1; j++)
                {
                    if (dizi[j + 1]< dizi[j])
                    {
                        int temp = dizi[j + 1];
                        dizi[j+1] = dizi[j];
                        dizi[j] = temp;
                    }
                }



            }
            foreach (int eleman in dizi)
            {
                Console.Write(eleman+" ");
            }
            Console.WriteLine();

        }

        public static int Arama(int[]array,int aranan)
        {
            int sol = 0;
            int sag =array.Length-1;

            while (sol<=sag)
            {
                int orta = (sol + sag) / 2;
                if (array[orta]==aranan) {
                    return orta;
                }  

                else if (array[orta]>aranan)
                {
                    sag = orta - 1;
                    
                }
                else
                {
                    sol = orta + 1;
                }
                

            }

            return -1;
           
        }




        static void Main(string[] args)
        {

            int[] dizii = { 5, 8, 10, 2, 4, 1, 6 };


            SiralaDizi(dizii);
            

            int index = Arama(dizii,20);

            if (index != -1)
                Console.WriteLine("Aranan eleman " + index + " indexinde bulundu");

            else
            {
                Console.WriteLine("Eleman bulunamadı!");
            }
            Console.ReadLine();
        }
    }
}
