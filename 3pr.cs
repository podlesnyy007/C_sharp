using System;

class Program
{
    static void Main()
    {
        for (int i = 100; i <= 999; i++)
        {
            int a = i / 100;
            int b = i / 10 % 10;
            int c = i % 10;
            if (a == b || a == c || b == c || a == b && a == c)
                Console.WriteLine(i);
        }
    }
}
