using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Sayı dizisini boşlukla ayırarak girin: ");
            string[] sayilarStr = Console.ReadLine().Split(' ');
            int[] sayilar = Array.ConvertAll(sayilarStr, int.Parse);

            List<string> tumCozumler = OperatorleriYerlestir(sayilar);

            if (tumCozumler.Count == 0)
            {
                Console.WriteLine("Geçerli çözüm bulunamadı!");
            }
            else
            {
                Console.WriteLine("\nBulunan tüm geçerli çözümler:");
                foreach (string cozum in tumCozumler)
                {
                    Console.WriteLine(cozum);
                }
            }
            Console.ReadLine();

        }

        static List<string> OperatorleriYerlestir(int[] sayilar)
        {
            List<string> cozumler = new List<string>();
            char[] operatorler = { '+', '-', '*', '/' };
            string ifade = sayilar[0].ToString();

            OperatorleriDene(sayilar, 1, ifade, cozumler, operatorler);
            return cozumler;
        }

        static void OperatorleriDene(int[] sayilar, int index, string mevcutIfade,
                                    List<string> cozumler, char[] operatorler)
        {
            if (index == sayilar.Length)
            {
                double sonuc = IfadeyiHesapla(mevcutIfade);
                if (sonuc > 0)
                {
                    cozumler.Add($"{mevcutIfade} = {sonuc}");
                }
                return;
            }

            foreach (char op in operatorler)
            {
                string yeniIfade = mevcutIfade + op + sayilar[index].ToString();
                double araHesap = IfadeyiHesapla(yeniIfade);

                if (araHesap > 0 || op == '+')
                {
                    OperatorleriDene(sayilar, index + 1, yeniIfade, cozumler, operatorler);
                }
            }
        }

        static double IfadeyiHesapla(string ifade)
        {
            try
            {
                Stack<double> sayiStack = new Stack<double>();
                Stack<char> operatorStack = new Stack<char>();
                string sayi = "";

                for (int i = 0; i < ifade.Length; i++)
                {
                    if (char.IsDigit(ifade[i]))
                    {
                        sayi += ifade[i];
                    }
                    else
                    {
                        if (sayi != "")
                        {
                            sayiStack.Push(double.Parse(sayi));
                            sayi = "";
                        }

                        while (operatorStack.Count > 0 && OncelikKontrol(operatorStack.Peek(), ifade[i]))
                        {
                            IslemYap(sayiStack, operatorStack);
                        }

                        operatorStack.Push(ifade[i]);
                    }
                }

                if (sayi != "")
                {
                    sayiStack.Push(double.Parse(sayi));
                }

                while (operatorStack.Count > 0)
                {
                    IslemYap(sayiStack, operatorStack);
                }

                return sayiStack.Pop();
            }
            catch (DivideByZeroException)
            {
                return -1;
            }
        }

        static bool OncelikKontrol(char op1, char op2)
        {
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return true;
            return false;
        }

        static void IslemYap(Stack<double> sayilar, Stack<char> operatorler)
        {
            char op = operatorler.Pop();
            double sayi2 = sayilar.Pop();
            double sayi1 = sayilar.Pop();
            double sonuc = 0;

            switch (op)
            {
                case '+': sonuc = sayi1 + sayi2; break;
                case '-': sonuc = sayi1 - sayi2; break;
                case '*': sonuc = sayi1 * sayi2; break;
                case '/':
                    if (sayi2 == 0) throw new DivideByZeroException();
                    sonuc = sayi1 / sayi2;
                    break;
            }

            sayilar.Push(sonuc);
        }
    }
}
