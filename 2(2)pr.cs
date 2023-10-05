using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите сторону a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите сторону b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Введите сторону c = ");
        double c = double.Parse(Console.ReadLine());
        string x = Math.Pow(c, 2) == Math.Pow(a, 2) + Math.Pow(b, 2) ? "Треугольник прямоугольный" :
            Math.Pow(b, 2) == Math.Pow(a, 2) + Math.Pow(c, 2) ? "Треугольник прямоугольный" :
            Math.Pow(a, 2) == Math.Pow(b, 2) + Math.Pow(c, 2) ? "Треугольник прямоугольный" : "Треугольник не прямоугольный";
        Console.WriteLine(x);
    }
}

/*
Введите сторону a = 3
Введите сторону b = 4
Введите сторону c = 5
Треугольник прямоугольный

Введите сторону a = 5
Введите сторону b = 5
Введите сторону c = 5
Треугольник не прямоугольный

Введите сторону a = 13
Введите сторону b = 13
Введите сторону c = 10
Треугольник не прямоугольный
*/
