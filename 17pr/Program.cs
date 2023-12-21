/*
Создать класс Triangle, содержащий следующие члены класса:
1. Поля: 
• int a, b, c;
2. Конструктор, позволяющий создать экземпляр класса с заданными длинами сторон. 
3. Методы, позволяющие:
• вывести длины сторон треугольника на экран; 
• расчитать периметр треугольника;
• расчитать площадь треугольника.
4.Свойство:
• позволяющее получить-установить длины сторон треугольника (доступное для чтения и записи);
• позволяющее установить, существует ли треугольник с данными длинами сторон (доступное только для чтения).
5. Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 – к полю b, по индексу 2 – к полю c, при других значениях индекса выдается сообщение об ошибке.
6. Перегрузку: 
• операции ++ (--): одновременно увеличивает (уменьшает) значение полей a, b и c на 1; 
• констант true и false: обращение к экземпляру класса дает значение true, если 
треугольник с заданными длинами сторон существует, иначе false;
• операции *: одновременно домножает поля a, b и c на скаляр.  
Продемонстрировать работу класса.
*/

using System;
using ZadachiC_;
using System.Collections.Generic;
using System.IO;

namespace ZadachiC_
{
    class Program
    {
        static void Main()
        {
            {
                StreamReader fileIn = new StreamReader("d:/Class/input.txt");
                List<int> sides = new List<int>();
                while (!fileIn.EndOfStream)
                {
                    string[] line = fileIn.ReadLine().Split(" ");
                    foreach (string side in line)
                    {
                        sides.Add(int.Parse(side));
                    }
                }

                Triangle triangle = new Triangle(sides[0], sides[1], sides[2]);

                // Вывод сторон треугольника на экран
                triangle.PrintSides();

                // Вывод сторон треугольника через идексатор
                Console.WriteLine("Значение по индексу 0: {0} \nЗначение по индексу 1: {1} \nЗначение по индексу 2: {2}",
                        triangle[0], triangle[1], triangle[2]);

                // Проверка существования треугольника
                if (triangle)
                {
                    Console.WriteLine("Треугольник существует");
                }
                else
                {
                    Console.WriteLine("Треугольник не существует");
                }

                // Вывод периметра треугольника
                int perimeter = triangle.Perimeter();
                Console.WriteLine("Периметр: {0}", perimeter);

                // Вывод площади треугольника
                double area = triangle.Area();
                Console.WriteLine("Площадь: {0}", area);

                // Использование операции ++
                triangle++;
                triangle.PrintSides();

                // Использование операции --
                triangle.A = sides[0];
                triangle.B = sides[1];
                triangle.C = sides[2];
                triangle--;
                triangle.PrintSides();

                // Использование операции *
                triangle.A = sides[0];
                triangle.B = sides[1];
                triangle.C = sides[2];
                triangle *= 2;
                triangle.PrintSides();
            }
        }
    }
}

/*
3 4 5

Сторона A: 3, Сторона B: 4, Сторона C: 5
Значение по индексу 0: 3
Значение по индексу 1: 4
Значение по индексу 2: 5
Треугольник существует
Периметр: 12
Площадь: 6
Сторона A: 4, Сторона B: 5, Сторона C: 6
Сторона A: 2, Сторона B: 3, Сторона C: 4
Сторона A: 6, Сторона B: 8, Сторона C: 10
*/
