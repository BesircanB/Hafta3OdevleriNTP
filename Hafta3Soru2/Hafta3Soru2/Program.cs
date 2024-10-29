using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru2
{
    class Program
    {
        //Listeye girilen sayıları ekleme
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

            return SayiListesi;
        }

        //Toplamını bul
        public static double Ort(List<int> Sayilar)
        {
            double top = 0;
            

            double sayac = Sayilar.Count;

            for(int i = 0; i < Sayilar.Count; i++)
            {
                top += Sayilar[i];
            }
            double ort = top / sayac;

            return top;
        }

        //Medyan(ortanca) bulma  (ilk terim +son terim)/2 önce küçükten büyüğe sırala
        public static double Med(List<int> Sayilar)
        {
            double medyan;
            for(int i = 0; i < Sayilar.Count - 1; i++)
            {
                for(int j = 0; j < Sayilar.Count - i - 1; j++)
                {
                    if (Sayilar[j + 1] < Sayilar[j])
                    {
                        int temp = Sayilar[j + 1];
                        Sayilar[j + 1] = Sayilar[j];
                        Sayilar[j] = temp;
                    }
                }
            }
            double ilk = Sayilar[0];
            double son = Sayilar[Sayilar.Count - 1];

            medyan = (ilk + son) / 2;




            return medyan;
        }


        static void Main(string[] args)
        {
            List<int> liste = SayiListesi();
            Console.WriteLine("Girilen Sayılar:");

            foreach(int sayi in liste)
            {
                Console.Write(sayi + " ");
            }
            Console.WriteLine();

            Console.WriteLine("ortalama:"+Ort(liste));
            Console.WriteLine("Medyan:"+Med(liste));
            Console.ReadLine();

           

        }
    }
}
