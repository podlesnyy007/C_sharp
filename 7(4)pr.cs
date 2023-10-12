using System;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Первый массив:");
        int[][] mas_1 = new int[n][];
        for (int i = 0; i < mas_1.Length; i++)
        {
            mas_1[i] = new int[n];
            for (int j = 0; j < mas_1[i].Length; j++)
            {
                mas_1[i][j] = int.Parse(Console.ReadLine());
            }
        }
        int[] mas_2 = new int[n];
        for (int i = 0; i < mas_2.Length; i++)
        {
            mas_2[i] = 1;
            for (int j = 0; j < mas_1[i].Length; j++)
            {
                mas_2[i] *= mas_1[j][i];
            }
        }
        Console.WriteLine("Второй массив:");
        foreach (int elem in mas_2)
        {
            Console.Write(elem + " ");
        }
        int min = mas_2[0]; //в качестве наименьшего значения полагаем нулевой элемент массива
        for (int i = 0; i < mas_2.Length; i++)
        {
            if (mas_2[i] < min)
            {
                min = mas_2[i];
            }
        }
        Console.WriteLine("\nМинимальный элеменет во втором массиве: " + min);
    }
}

/*
n = 3
Первый массив:
1
2
3
4
5
6
7
8
9
Второй массив:
28 80 162
Минимальный элеменет во втором массиве: 28
*/
