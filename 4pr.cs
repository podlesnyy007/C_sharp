using System;

class Program
{
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        int delA = 0, delB = 0;
        for (int i = 1; i <= a; i++)
            if(a % i == 0)
                delA++;
        for (int i = 1; i <= b; i++)
            if (b % i == 0)
                delB++;
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
