/*
Решить задачу, используя структуру SPoint для хранения координат точки:
Замечание. В задачах с нечетными номерами множество точек задано на плоскости, в задачах с 
четными номерами множество точек задано в пространстве. (четное - в пространстве)
Найти три различные точки из заданного множества точек, образующих треугольник наибольшего периметра.
*/

using System;
using System.IO;
using System.Collections.Generic;

struct SPoint
{
    public int x, y, z;
    public SPoint(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static double Distance(SPoint point1, SPoint point2)
    {
        double dx = point1.x - point2.x;
        double dy = point1.y - point2.y;
        double dz = point1.z - point2.z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}

class Program
{
    static void Main()
    {
        using (StreamReader fileIn = new StreamReader("d:/Struct1/input.txt"))
        {
            int n = int.Parse(fileIn.ReadLine());
            SPoint[] mas = new SPoint[n];
            List<Tuple<SPoint, SPoint, SPoint>> maxPerPoint = new List<Tuple<SPoint, SPoint, SPoint>>();
            for (int i = 0; i < n; i++)
            {
                string[] str = fileIn.ReadLine().Split(' ');
                mas[i] = new SPoint(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]));
            }
            double maxPerimeter = 0;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        double side1 = SPoint.Distance(mas[i], mas[j]);
                        double side2 = SPoint.Distance(mas[j], mas[k]);
                        double side3 = SPoint.Distance(mas[k], mas[i]);
                        if (side2 + side3 > side1 && side1 + side3 > side2 && side1 + side2 > side3)
                        {
                            double perimeter = side1 + side2 + side3;
                            if (perimeter >= maxPerimeter)
                            {
                                if (perimeter > maxPerimeter)
                                {
                                    maxPerPoint.Clear();
                                    maxPerimeter = perimeter;
                                }
                                maxPerPoint.Add(new Tuple<SPoint, SPoint, SPoint>(mas[i], mas[j], mas[k]));
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Наибольший периметр: {0}", maxPerimeter);
            foreach (var triangle in maxPerPoint)
            {
                Console.WriteLine("Точки треугольника с маскимальным периметром:");
                Console.WriteLine("Точка 1: ({0}, {1}, {2})", triangle.Item1.x, triangle.Item1.y, triangle.Item1.z);
                Console.WriteLine("Точка 2: ({0}, {1}, {2})", triangle.Item2.x, triangle.Item2.y, triangle.Item2.z);
                Console.WriteLine("Точка 3: ({0}, {1}, {2})", triangle.Item3.x, triangle.Item3.y, triangle.Item3.z);
            }
        }
    }
}

/*
5
0 0 0
4 0 0
4 4 0
0 4 0
2 2 0

Наибольший периметр: 13,65685424949238
Точки треугольника с маскимальным периметром:
Точка 1: (0, 0, 0)
Точка 2: (4, 0, 0)
Точка 3: (4, 4, 0)
Точки треугольника с маскимальным периметром:
Точка 1: (0, 0, 0)
Точка 2: (4, 0, 0)
Точка 3: (0, 4, 0)
Точки треугольника с маскимальным периметром:
Точка 1: (0, 0, 0)
Точка 2: (4, 4, 0)
Точка 3: (0, 4, 0)
Точки треугольника с маскимальным периметром:
Точка 1: (4, 0, 0)
Точка 2: (4, 4, 0)
Точка 3: (0, 4, 0)
*/
