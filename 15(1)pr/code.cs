/*
Дана последовательность целых чисел.
Замечание. Для хранения последовательности можно использовать одномерный массив 
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод 
данных – файловый.
Вывести на экран в порядке убывания все отрицательные трехзначные числа, заменив 
них на противоположное значение.
*/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        StreamReader fileIn = new StreamReader("d:/Linq1/input.txt");
        List<int> list = new List<int>();
        while (!fileIn.EndOfStream)
        {
            string[] str = fileIn.ReadLine().Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str.Length; i++)
            {
                list.Add(int.Parse(str[i]));
            }
        }
        fileIn.Close();
        var numbers =
            from n in list
            where n >= -999 && n <= -100
            orderby n descending
            select -n;
        StreamWriter fileOut = new StreamWriter("d:/Linq1/output.txt");
        foreach (int n in numbers)
        {
            fileOut.WriteLine("{0}", n);
        }
        fileOut.Close();
    }
}

/*
-123 45 -678 987 -456
-50 999 -222 -101 0

101
123
222
456
678
*/
