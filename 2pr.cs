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
