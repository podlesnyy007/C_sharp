using System;

class Program
{
    static void Func(int x)
    {
        if (x == 0)
        {
            Console.WriteLine("И больше лунатиков не стало на луне");
            return;
        }
        else
        {
            Console.WriteLine($"{x} лунатиков жили на луне");
            Console.WriteLine($"{x} лунатиков ворочались во сне");
            Console.WriteLine("Один из лунатиков упал с луны во сне");
            Console.WriteLine($"{x - 1} лунатиков осталось на луне");
            Console.WriteLine();
            Func(x - 1);
        } 
    }
    static void Main()
    {
        Func(10);
    }
}
