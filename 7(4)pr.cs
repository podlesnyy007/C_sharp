using System;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Первый массив:");
        int[,] mas_1 = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[{0},{1}]= ", i, j);
                mas_1[i, j] = int.Parse(Console.ReadLine());
            }
        }
        int[] mas_2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            mas_2[i] = 1;
            for (int j = 0; j < n; j++)
            {
                mas_2[i] *= mas_1[j, i];
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
a[0,0]= 1
a[0,1]= 2
a[0,2]= 3
a[1,0]= 4
a[1,1]= 5
a[1,2]= 6
a[2,0]= 7
a[2,1]= 8
a[2,2]= 9
Второй массив:
28 80 162
Минимальный элеменет во втором массиве: 28
*/
