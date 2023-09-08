using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите сумму вклада = ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Введите процент по вкладу = ");
        double y = double.Parse(Console.ReadLine());
        Console.WriteLine("Через год начислят {0:f2}р.", x * (y / 100));
    }
}
