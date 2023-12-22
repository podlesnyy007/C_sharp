using System;

namespace ZadachiC_
{
    class Triangle
    {
        // Поля класса
        private int a;
        private int b;
        private int c;

        // Конструктор, позволяющий создать экземпляр класса с заданными длинами сторон
        public Triangle(int sideA, int sideB, int sideC)
        {
            a = sideA;
            b = sideB;
            c = sideC;
        }

        // Метод, позволяющий вывести длины сторон треугольника на экран 
        public void PrintSides()
        {
            Console.WriteLine($"Сторона A: {a}, Сторона B: {b}, Сторона C: {c}");
        }

        // Метод, позволяющий расчитать периметр треугольника
        public int Perimeter()
        {
            return a + b + c;
        }

        // Метод, позволяющий расчитать площадь треугольника.
        public double Area()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        // Свойство, позволяющее получить-установить длины сторон треугольника (доступное для чтения и записи)
        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int C
        {
            get { return c; }
            set { c = value; }
        }

        // Свойство, позволяющее установить, существует ли треугольник с данными длинами сторон (доступное только для чтения)
        public bool Exist
        {
            get { return a + b > c && a + c > b && b + c > a; }
        }

        // Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 – к полю b, 
        // по индексу 2 – к полю c, при других значениях индекса выдается сообщение об ошибке
        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return a;
                else if (index == 1)
                    return b;
                else if (index == 2)
                    return c;
                else
                {
                    Console.WriteLine("Недопустимый индекс");
                    return 0;
                }
            }
            set
            {
                if (index == 0)
                    a = value;
                else if (index == 1)
                    b = value;
                else if (index == 2)
                    c = value;
                else
                    Console.WriteLine("Недопустимый индекс");
            }
        }

        // Перегрузка операции ++ (--): одновременно увеличивает (уменьшает) значение полей a, b и c на 1 
        public static Triangle operator ++(Triangle triangle)
        {
            Triangle temp = new Triangle(triangle.A, triangle.B, triangle.C);
            temp.a++;
            temp.b++;
            temp.c++;
            return temp;
        }

        public static Triangle operator --(Triangle triangle)
        {
            if (triangle.a > 0 && triangle.b > 0 && triangle.c > 0)
            {
                Triangle temp = new Triangle(triangle.A, triangle.B, triangle.C);
                temp.a--;
                temp.b--;
                temp.c--;
                return temp;
            }
            return triangle;
        }

        // Перегрузка констант true и false: обращение к экземпляру класса дает значение true, если
        // треугольник с заданными длинами сторон существует, иначе false;
        public static bool operator true(Triangle triangle)
        {
            return triangle.Exist;
        }

        public static bool operator false(Triangle triangle)
        {
            return !triangle.Exist;
        }

        // Перегрузка операции *: одновременно домножает поля a, b и c на скаляр. 
        public static Triangle operator *(Triangle triangle, int scalar)
        {
            Triangle temp = new Triangle(triangle.A, triangle.B, triangle.C);
            temp.a *= scalar;
            temp.b *= scalar;
            temp.c *= scalar;
            return temp;
        }

        public static Triangle operator *(int scalar, Triangle triangle)
        {
            return triangle * scalar;
        }
    }
}
