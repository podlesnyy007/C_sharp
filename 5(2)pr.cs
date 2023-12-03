/*
Использование базовых алгоритмов при разработке методов
Разработать метод, который для заданного натурального числа N возвращает сумму его нечетных цифр. С помощью данного метода:
a) для каждого целого числа на отрезке [a, b] вывести на экран сумму его нечетных цифр;
b) вывести на экран только те целые числа отрезка [a, b], у которых сумма нечетных цифр числа равна заданному значению С;
c) вывести на экран только те целые числа отрезка [a, b], у которых сумма нечетных цифр является простым числом,
d) для заданного числа А вывести на экран ближайшее следующее по отношению к нему число, сумма нечетных цифр которого равна сумме нечетных цифр числа А.
*/

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
        for (int i = a; i <= b; i++)
        {
            int k = Func(i);
            if (k != 1)
            {
                byte prostNum = 0;
                for (int j = 2; j <= Math.Sqrt(k); j++)
                    if (k % j == 0)
                    {
                        prostNum++;
                        break;
                    }
                if (prostNum == 0)
                    Console.WriteLine(i);
                prostNum = 0;
            }
        }
        Console.Write("Задача под буквой d:\nA = ");
        int A = int.Parse(Console.ReadLine());
        int x = A + 1;
        while (Func(A) != Func(x))
            x++;
        Console.WriteLine(x);
    }
}

/*
a = 100
b = 125
Задача под буквой а:
100 -> 1
101 -> 2
102 -> 1
103 -> 4
104 -> 1
105 -> 6
106 -> 1
107 -> 8
108 -> 1
109 -> 10
110 -> 2
111 -> 3
112 -> 2
113 -> 5
114 -> 2
115 -> 7
116 -> 2
117 -> 9
118 -> 2
119 -> 11
120 -> 1
121 -> 2
122 -> 1
123 -> 4
124 -> 1
125 -> 6
Задача под буквой b:
c = 4
103
123
Задача под буквой c:
101
110
111
112
113
114
115
116
118
119
121
Задача под буквой d:
A = 103
123
*/
