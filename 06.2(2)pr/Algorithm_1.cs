using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ZadachiC_
{
    class Program
    {
        //Метод возвращает true если подстрока палиндром, иначе возвращает false
        static bool IsPalindrom(string s, int left, int right)
        {
            while (left <= right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                ++left;
                --right;
            }
            return true;
        }

        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            List<string> words = new List<string>();
            List<string> palindromes = new List<string>();

            // Чтение входных данных из файла
            string fileInput = "d:/Dop_pr/input.txt";
            try
            {
                using (StreamReader fileIn = new StreamReader(fileInput))
                {
                    string line;
                    while ((line = fileIn.ReadLine()) != null)
                    {
                        words.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
                return;
            }

            // Генерация всех возможных подстрок
            stopwatch.Start();
            foreach (string word in words)
            {
                for (int left = 0; left < word.Length; ++left)
                {
                    for (int right = left + 1; right < word.Length; ++right)
                    {
                        if (IsPalindrom(word, left, right))
                        {
                            palindromes.Add(word.Substring(left, right - left + 1));
                        }
                    }
                }
            }
            stopwatch.Stop();

            // Вывод палиндромов на консоль
            Console.WriteLine("Палиндромы:");
            foreach (string palindrome in palindromes)
            {
                Console.WriteLine(palindrome);
            }

            Console.WriteLine("Время выполнения алгоритма: " + stopwatch.Elapsed.TotalMilliseconds + " мс");
        }
    }
}

//Время выполнения алгоритма: 0,3215 мс
/*
Первый алгоритм быстрее, но не на много. С увеличением входных данных (количество символов в тексте), второй алгоритм будет работать быстрее.
*/
