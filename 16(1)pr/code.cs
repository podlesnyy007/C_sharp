/*
Решить задачи из практикума №15 I, используя методы расширения
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

class Program
{
    static void Main()
    {
        StreamReader fileIn = new StreamReader("d:/MetodRasshireniya1/input.txt");
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
        var numbers = list.Where(n => n >= -999 && n <= -100).OrderByDescending(n => n).Select(x => -x);
        StreamWriter fileOut = new StreamWriter("d:/MetodRasshireniya1/output.txt");
        foreach (int x in numbers)
        {
            fileOut.WriteLine("{0}", x);
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
