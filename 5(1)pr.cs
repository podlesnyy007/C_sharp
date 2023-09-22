using System;

class Program
{
    static int Func(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            if (n % 10 % 2 == 1)
                sum += n % 10;
            n /= 10;
        }
        return sum;
    }
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Задача под буквой а:");
        for (int i = a; i <= b; i++)
            Console.WriteLine(i + " -> " + Func(i));
        Console.Write("Задача под буквой b:\nc = ");
        int c = int.Parse(Console.ReadLine());
        for (int i = a; i <= b; i++)
            if (c == Func(i))
                Console.WriteLine(i);
        Console.WriteLine("Задача под буквой c:");
        int prostNum = 0;
        for (int i = a; i <= b; i++)
        {
            for (int j = 2; j < i; j++)
                if (Func(i) % j == 0)
                    prostNum++;
            if (prostNum == 0)
                Console.WriteLine(i);
            prostNum = 0;
        }
        Console.Write("Задача под буквой d:\nA = ");
        int A = int.Parse(Console.ReadLine());
        int x = A + 1;
        while (Func(A) != Func(x))
            x++;
        Console.WriteLine(x);
    }
}
