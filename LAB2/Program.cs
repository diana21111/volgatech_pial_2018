using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cezar
{
    class Program
    {
        static void Main()
        {
            string alfphabet = "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЬЪЭЮЯ";
            do
            {
                Console.Clear();
                Console.WriteLine("Программа Шифр Цезаря для зашифровки и расшифровки текста на РУССКОМ ЯЗЫКЕ.");
                Console.WriteLine("МЕНЮ.");
                Console.WriteLine("1.Зашифровка.");
                Console.WriteLine("2.Расшифровка.");
                Console.WriteLine("3.Выход.");
                int k;
                bool res = int.TryParse(Console.ReadLine(), out k);
                if (res == true && (k == 1 || k == 2 || k == 3))
                {
                    switch (k)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Введите слово,которое нужно зашифровать:");
                            string s = Console.ReadLine();

                            int m = alfphabet.Length;

                            List<string> result = new List<string>();
                            for (int y = 1; y < 32; y++)
                            {
                                result.Add(Shift(s, alfphabet, y));
                            }

                            foreach (var word in result)
                            {
                                Console.WriteLine("Зашифрованное слово:" + word);
                            }

                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            int n = 1, key = 1;
                            Console.WriteLine("Введите слово,которое нужно дешифровать:");
                            string z = Console.ReadLine();
                            Console.WriteLine("Введите ключ:");
                            res = int.TryParse(Console.ReadLine(), out key);
                            if (res == true && key >= 0)
                            {
                                string z1 = "";
                                m = alfphabet.Length;
                                for (int i = 0; i < z.Length; i++)
                                {
                                    for (int j = 0; j < alfphabet.Length; j++)
                                    {
                                        if (z[i] == alfphabet[j])
                                        {
                                            int temp = j * n - key;
                                            while (temp < 0)
                                                temp += m;
                                            z1 = z1 + alfphabet[temp];
                                        }
                                    }
                                }
                                Console.Write("Дешифрованное слово:");
                                Console.WriteLine(z1);
                            }
                            else
                            {
                                Console.WriteLine("Данные введены некорректно.");
                            }
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Данные введены некорректно.");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static string Shift(string targetWord, string alfphabet, int key)
        {
            string result = string.Empty;
            for (int i = 0; i < targetWord.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (targetWord[i] == alfphabet[j])
                    {
                        int temp = j + key;

                        while (temp >= alfphabet.Length)
                            temp -= alfphabet.Length;

                        result += alfphabet[temp];
                    }
                }
            }
            return result;
        }

    }
}
    

