using System;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Первый массив:");
        int[][] mas = new int[n][];
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = new int[m];
            for (int j = 0; j < mas[i].Length; j++)
            {
                mas[i][j] = int.Parse(Console.ReadLine());
            }
        }
        int[] b = new int[n];
        for (int i = 0; i < n; i++)
        {
            b[i] = 1;
            for (int j = 0; j < m; j++)
            {
                b[i] *= mas[j][i];
            }
        }
        Console.WriteLine("Второй массив");
        foreach (int elem in b)
        {
            Console.Write(elem + " ");
        }

        int min = b[0]; //в качестве наименьшего значения полагаем нулевой элемент массива
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i] < min)
            {
                min = b[i];
            }
        }
        Console.WriteLine("Минимальный элеменет во втором массиве\n" + min);
    }
}
