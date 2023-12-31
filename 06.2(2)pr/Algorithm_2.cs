using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ZadachiC_
{
    class Program
    {
        //Метод для получения хеш-значения для подстроки с индексами L и R
        static long GetHash(long[] h, int L, int R)
        {
            if (L > 0) return h[R] - h[L - 1];
            return h[R];
        }

        //Метод для получения хеш-значения для «перевернутой» подстроки с индексами L и R
        static long GetHashRevers(long[] h_r, int L, int R)
        {
            if (R < h_r.Length - 1) return h_r[L] - h_r[R + 1];
            return h_r[L];
        }

        //Метод возвращает true, если строка палиндром, иначе false
        static bool IsPalindrome(long[] h, long[] h_r, long[] pwp, int L, int R)
        {
            return GetHash(h, L, R) * pwp[h.Length - R - 1] == GetHashRevers(h_r, L, R) * pwp[L];
        }

        //Метод для вывода на экран всех палиндром
        static void Print(List<string> palindromes)
        {
            Console.WriteLine("Палиндромы:");
            foreach (string palindrome in palindromes)
            {
                Console.WriteLine(palindrome);
            }
        }

        //Основной метод
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            List<string> words = new List<string>();
            List<string> palindromes = new List<string>();

            try
            {
                string fileInput = "d:/Dop_pr/input.txt";
                using (StreamReader fileIn = new StreamReader(fileInput))
                {
                    string line;
                    while ((line = fileIn.ReadLine()) != null)
                    {
                        words.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    }
                }
                for (int t = 0; t < words.Count; t++)
                {
                    int n = words[t].Length;
                    const long P = 37;

                    //вычисляем массив степеней
                    long[] pwp = new long[n];
                    pwp[0] = 1;
                    for (int i = 1; i < n; i++)
                    {
                        pwp[i] = pwp[i - 1] * P;
                    }

                    //вычисляем массив хэш-значений для всех префиксов строки S и перевернутой строки
                    long[] h = new long[n];
                    long[] h_r = new long[n];
                    for (int i = 0; i < n; i++)
                    {
                        h[i] = (words[t][i] - 'а' + 1) * pwp[i];
                        h_r[n - 1 - i] = (words[t][n - 1 - i] - 'а' + 1) * pwp[i];

                        if (i > 0)
                        {
                            h[i] += h[i - 1];
                            h_r[n - 1 - i] += h_r[n - i];
                        }
                    }

                    //поиск палиндромов нечетной длины
                    int[] oddCount = new int[n];
                    stopwatch.Start();
                    for (int i = 0; i < n; i++)
                    {
                        int left = 1, right = Math.Min(i + 1, n - i);
                        while (left < right)
                        {
                            int middle = (left + right) / 2;
                            if (IsPalindrome(h, h_r, pwp, i - middle + 1, i + middle - 1))
                            {
                                oddCount[i] = middle;
                                left = middle + 1;
                            }
                            else
                            {
                                right = middle - 1;
                            }
                        }
                    }
                    stopwatch.Stop();

                    //поиск палиндромов четной длины
                    int[] evenCount = new int[n];
                    stopwatch.Start();
                    for (int i = 0; i < n; i++)
                    {
                        int left = 1, right = Math.Min(i, n - i);
                        while (left < right)
                        {
                            int middle = (left + right) / 2;
                            if (IsPalindrome(h, h_r, pwp, i - middle, i + middle - 1))
                            {
                                evenCount[i] = middle;
                                left = middle + 1;
                            }
                            else
                            {
                                right = middle - 1;
                            }
                        }
                    }
                    stopwatch.Stop();

                    for (int i = 0; i < oddCount.Length; ++i)
                    {
                        if (oddCount[i] > 1)
                            palindromes.Add(words[t].Substring(i - oddCount[i] + 1, oddCount[i] * 2 - 1));
                    }

                    for (int i = 0; i < evenCount.Length; ++i)
                    {
                        palindromes.Add(words[t].Substring(i - evenCount[i], evenCount[i] * 2));
                    }
                }

                Print(palindromes);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            }

            Console.WriteLine("Время выполнения алгоритма: " + stopwatch.Elapsed.TotalMilliseconds + " мс");
        }
    }
}

//Время выполнения алгоритма: 0,4235 мс
