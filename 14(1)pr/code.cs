/*
Решить задачу, используя структуру SPoint для хранения координат точки:
Замечание. В задачах с нечетными номерами множество точек задано на плоскости, в задачах с 
четными номерами множество точек задано в пространстве. (четное - в пространстве)
Найти три различные точки из заданного множества точек, образующих треугольник наибольшего периметра.
*/

using System;
using System.IO;

struct SPoint
{
    public int x, y, z;
    public SPoint(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

class Program
{
    static double Distance(SPoint point1, SPoint point2)
    {
        double dx = point1.x - point2.x;
        double dy = point1.y - point2.y;
        double dz = point1.z - point2.z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    static void Main()
    {
        using (StreamReader fileIn = new StreamReader("d:/Struct1/input.txt"))
        {
            int n = int.Parse(fileIn.ReadLine());
            SPoint[] mas = new SPoint[n];
            for (int i = 0; i < n; i++)
            {
                string[] str = fileIn.ReadLine().Split(' ');
                mas[i] = new SPoint(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2])); //вызов конструктора структуры
            }
            double maxPerimeter = 0;
            SPoint point1 = new SPoint();
            SPoint point2 = new SPoint();
            SPoint point3 = new SPoint();
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        double side1 = Distance(mas[i], mas[j]);
                        double side2 = Distance(mas[j], mas[k]);
                        double side3 = Distance(mas[k], mas[i]);
                        double perimeter = side1 + side2 + side3;
                        if (perimeter > maxPerimeter)
                        {
                            maxPerimeter = perimeter;
                            point1 = mas[i];
                            point2 = mas[j];
                            point3 = mas[k];
                        }
                    }
                }
            }
            Console.WriteLine("Точки, образующие треугольник наибольшего периметра:");
            Console.WriteLine("Точка 1: ({0}, {1}, {2})", point1.x, point1.y, point1.z);
            Console.WriteLine("Точка 2: ({0}, {1}, {2})", point2.x, point2.y, point2.z);
            Console.WriteLine("Точка 3: ({0}, {1}, {2})", point3.x, point3.y, point3.z);
            Console.WriteLine("Наибольший периметр: {0}", maxPerimeter);
        }
    }
}

/*
6
1 0 0
0 1 0
0 0 1
3 0 0
0 3 0
0 0 3

Точки, образующие треугольник наибольшего периметра:
Точка 1: (3, 0, 0)
Точка 2: (0, 3, 0)
Точка 3: (0, 0, 3)
Наибольший периметр: 12,727922061357855
*/
