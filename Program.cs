using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Игра БЫКИ И КОРОВЫ.");
                Console.WriteLine("МЕНЮ.");
                Console.WriteLine("1.Новая игра.");
                Console.WriteLine("2.Выход.");
                int k;
                bool result1 = int.TryParse(Console.ReadLine(), out k);
                if (result1 == true && (k == 1 || k == 2))
                {
                    switch (k)
                    {
                        case 1:
                            int[] value = new int[4];
                            int number, i, j, key, cow, bull, kol = 0;
                            bool result2 = false, result3 = false;
                            //Компьютер загадывает число.
                            Random rnd = new Random();
                            value[0] = rnd.Next(1, 9);
                            for (i = 1; i < 4; i++)
                            {
                                number = rnd.Next(0, 9);
                                for (j = 0; j < i; j++)
                                {
                                    if (number == value[j])
                                    {
                                        i--;
                                        break;
                                    }
                                    else
                                    {
                                        value[i] = number;
                                    }
                                }
                            }
                            Console.WriteLine("Компьютер задумал число");
                            //Игрок угадывает число.
                            do
                            {
                                string str;
                                bull = 0; cow = 0;
                                Console.WriteLine("Введите число:");
                                str = Console.ReadLine();
                                result2 = int.TryParse(str, out key);   //Проверка на тип int
                                if (str.Length == 4 && result2 == true)
                                {
                                    for (i = 0; i < 4; i++)             //Проверка на неповторяемость цифр в числе.
                                    {
                                        for (j = 0; j < 4; j++)
                                        {
                                            if (i == j && i != j || 0 - '0' == 0)
                                            {
                                                result2 = false;
                                            }
                                        }
                                    }
                                    if (result2 == true)                   //Выявление быков и коров
                                    {
                                        for (i = 0; i < 4; i++)
                                        {
                                            for (j = 0; j < 4; j++)
                                            {
                                                if (value[i] == (str[j] - '0'))
                                                {
                                                    if (i == j)
                                                    {
                                                        bull++;
                                                    }
                                                    else
                                                    {
                                                        cow++;
                                                    }
                                                }
                                            }
                                        }
                                        kol++;
                                        if (bull == 4)
                                        {
                                            Console.WriteLine("Поздравляю! Вы угадали загаданное число.");
                                            Console.WriteLine("Количество сделанных ходов:{0}", kol);
                                            result3 = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("{0} бык(а) и {1} корова(ы)", bull, cow);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Данные введены некорректно.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Данные введены некорректно.");
                                }
                            } while (result3 != true);
                            break;
                        case 2:
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
    }
}