/*
В массиве размером n×n, элементы которого – целые числа, произвести следующие действия:
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор обосновать.
Вставить новую строку после всех строк, в которых нет ни одного четного элемента.
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        int[][] array = new int[n + n][]; //выделяем память под массив с избытком
        for (int i = 0; i < n; i++)
        {
            array[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                Console.Write("array[{0},{1}] = ", i, j);
                array[i][j] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < n; i++)
        {
            bool flag = false; // флаг наличия четного элемента в строке
            for (int j = 0; j < m; j++)
            {
                if (array[i][j] % 2 == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int k = n; k > i; k--)
                {
                    array[k] = array[k - 1]; // сдвигаем все строки на одну позицию вниз, начиная с конца массива
                }
                ++n;
                array[i + 1] = new int[m]; // вставляем новую строку после текущей
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Элемент новой строки array[{0},{1}] = ", i + 1, j);
                    array[i + 1][j] = int.Parse(Console.ReadLine());
                }
            }
        }
        Console.WriteLine("Измененный массив:");
        for (int i = 0; i < n; i++, Console.WriteLine())
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(array[i][j] + " ");
            }
        }
    }
}

/*
n = 4
m = 4
array[0,0] = 1
array[0,1] = 3
array[0,2] = 5
array[0,3] = 7
array[1,0] = 2
array[1,1] = 4
array[1,2] = 6
array[1,3] = 8
array[2,0] = 1
array[2,1] = 2
array[2,2] = 3
array[2,3] = 4
array[3,0] = 9
array[3,1] = 7
array[3,2] = 5
array[3,3] = 3
Элемент новой строки array[1,0] = 0
Элемент новой строки array[1,1] = 0
Элемент новой строки array[1,2] = 0
Элемент новой строки array[1,3] = 0
Элемент новой строки array[5,0] = 0
Элемент новой строки array[5,1] = 0
Элемент новой строки array[5,2] = 0
Элемент новой строки array[5,3] = 0
Измененный массив:
1 3 5 7
0 0 0 0
2 4 6 8
1 2 3 4
9 7 5 3
0 0 0 0
*/
