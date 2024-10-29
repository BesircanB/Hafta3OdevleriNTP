using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3Soru4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matematiksel ifadeyi girin (örnek: 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3):");
            string ifade = Console.ReadLine();

            // Boşlukları kaldır
            ifade = ifade.Replace(" ", "");

            // İşlemleri gerçekleştir
            var tokenlar = TokenlariAyir(ifade);
            var postfix = InfixToPostfix(tokenlar);
            var sonuc = PostfixDegerlendir(postfix);

            Console.WriteLine($"\nSonuç: {sonuc}");
            Console.ReadLine();
        }

        static List<string> TokenlariAyir(string ifade)
        {
            var tokenlar = new List<string>();
            StringBuilder sayi = new StringBuilder();

            for (int i = 0; i < ifade.Length; i++)
            {
                char c = ifade[i];

                if (char.IsDigit(c) || c == '.')
                {
                    sayi.Append(c);
                }
                else
                {
                    if (sayi.Length > 0)
                    {
                        tokenlar.Add(sayi.ToString());
                        sayi.Clear();
                    }

                    if (c == '-' && (i == 0 || "({[^*/+-".Contains(ifade[i - 1])))
                    {
                        tokenlar.Add("-1");
                        tokenlar.Add("*");
                    }
                    else
                    {
                        tokenlar.Add(c.ToString());
                    }
                }
            }

            if (sayi.Length > 0)
            {
                tokenlar.Add(sayi.ToString());
            }

            return tokenlar;
        }

        static int OncelikAl(string op)
        {
            switch (op)
            {
                case "^": return 4;
                case "*":
                case "/": return 3;
                case "+":
                case "-": return 2;
                case "(": return 1;
                default: return 0;
            }
        }

        static List<string> InfixToPostfix(List<string> tokenlar)
        {
            var postfix = new List<string>();
            var operatorStack = new Stack<string>();

            foreach (var token in tokenlar)
            {
                if (double.TryParse(token, out _))
                {
                    postfix.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0) operatorStack.Pop();
                }
                else
                {
                    while (operatorStack.Count > 0 &&
                           OncelikAl(operatorStack.Peek()) >= OncelikAl(token))
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                postfix.Add(operatorStack.Pop());
            }

            return postfix;
        }

        static double PostfixDegerlendir(List<string> postfix)
        {
            var stack = new Stack<double>();
            int adimNo = 1;

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double sayi))
                {
                    stack.Push(sayi);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double sonuc = IslemYap(a, b, token);

                    Console.WriteLine($"Adım {adimNo}: {a} {token} {b} = {sonuc}");
                    adimNo++;

                    stack.Push(sonuc);
                }
            }

            return stack.Pop();
        }

        static double IslemYap(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "^": return Math.Pow(a, b);
                default: throw new ArgumentException($"Geçersiz operatör: {op}");
            }
        }
    }
}
