/*
Для заданного натурального числа N:
определить, у какого числа больше делителей
*/

using System;

class Program
{
    /*
     *Почти все делители образуют пару и если мы нашли один делитель, то можем определить и парный ему.
     *Исключение составляют только такие делители, квадраты которых равны самому числу.
     *Для таких делителей выполняется свойство i = sqrt(N), поэтому для поиска делителей числа N
     *можно перебирать все натуральные числа из диапазона от 1 до sqrt(N)
    */
    static int Func(int n)
    {
        int del = 0;
        for (uint i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) //если i делитель n
            {
                if (i * i == n) //и i нет парного делителя
                    del++;
                else
                    del += 2; // иначе считаем i и его парный делитель
            }
        }
        return del;
    }
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        int delA = Func(a);
        int delB = Func(b);
        Console.WriteLine("Число делителей у числа " + a + ": " + delA);
        Console.WriteLine("Число делителей у числа " + b + ": " + delB);
        if (delA > delB)
            Console.WriteLine("У числа " + a + " больше делителей");
        else
        {
            if (delA < delB)
                Console.WriteLine("У числа " + b + " больше делителей");
            else
                Console.WriteLine("У обоих чисел одинаковое число делителей");
        }
    }
}

/*
a = 88
b = 84
Число делителей у числа 88: 8
Число делителей у числа 84: 12
У числа 84 больше делителей
*/
