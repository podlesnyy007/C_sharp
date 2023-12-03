using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Осмысленное сообщение:");
        string str = Console.ReadLine();
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        char[] div = { ' ', ',', '.', '!', '?' };
        string[] words = str.Split(div, StringSplitOptions.RemoveEmptyEntries); //Разбиваем строку на слова
        //Создаем словарь, в котором будут храниться слова и их количество встречаемости
        //Словарь - это структура данных, которая хранит в себе объекты по ключу и значению
        //То есть у нас есть ключ в нашем словаре, и по этому ключу содержится какое-то значение
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        //Подсчет количества повторений каждого слова
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word)) //Метод ContainsKey определяет, содержится ли указанный ключ в словаре
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }
        Console.WriteLine("Слова, встречающиеся более {0} раз:", n);
        foreach (var pair in wordCount)
        {
            if (pair.Value > n) //Value - это наше значение в словаре
            {
                Console.WriteLine(pair.Key); //Key - это наш ключ в словаре
            }
        }
    }
}
