using System;

class Program
{
    static int Func(int x)
    {
        if (x == 0)
            return 0;
        else
            return Func(x / 10) + 1;
    }
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Количество цифр: " + Func(n));
    }
}

/*
n = 123456789
Количество цифр: 9
*/
