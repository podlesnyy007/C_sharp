/*
Решитть задачу, используя запрос LINQ.
Использование структур данных. 
Замечания: 
1.Во всех задачах данного раздела подразумевается, что исходная информация хранится в текстовом файле input.txt, каждая строка которого содержит 
полную информацию о некотором объекте; результирующая информация должна быть записана в файл output.txt 
2.Для хранения данных внутри программы организовать одномерный массив структур или любую другую подходящую коллекцию структур. Выбор коллекции обосновать. 
На основе данных входного файла составить список студентов, включающий фамилию, факультет, курс, группу, результаты сдачи трех экзаменов. 
Вывести в новый файл информацию о тех студентах, которые имеют хотя бы одну двойку, сгруппировав выводимые данные по факультету.
*/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

struct Student
{
    public string surname;
    public string faculty;
    public int course;
    public int group;
    public int exam1, exam2, exam3;
}

class Program
{
    static void Main()
    {
        StreamReader fileIn = new StreamReader("d:/Linq2/input.txt");
        List<Student> students = new List<Student>();
        while (!fileIn.EndOfStream)
        {
            string[] data = fileIn.ReadLine().Split(' ');
            Student student = new Student
            {
                surname = data[0],
                faculty = data[1],
                course = int.Parse(data[2]),
                group = int.Parse(data[3]),
                exam1 = int.Parse(data[4]),
                exam2 = int.Parse(data[5]),
                exam3 = int.Parse(data[6]),
            };
            students.Add(student);
        }
        fileIn.Close();
        var result = from student in students
                     where student.exam1 == 2 || student.exam2 == 2 || student.exam3 == 2
                     group student by student.faculty into stud
                     select new { Faculty = stud.Key, Students = stud };
        StreamWriter fileOut = new StreamWriter("d:/Linq2/output.txt");
        foreach (var group in result)
        {
            fileOut.WriteLine(group.Faculty + ":");
            foreach (var student in group.Students)
            {
                fileOut.WriteLine($"  {student.surname}, курс {student.course}, группа {student.group}");
            }
        }
        fileOut.Close();
    }
}

/*
Иванов Юридический 1 151 5 5 5
Смирнова Экономический 1 181 2 2 2
Кузнецов Математический 1 141 3 4 2
Попова Экономический 2 281 4 3 2
Васильев Экономический 3 381 5 5 4
Петрова Математический 2 241 5 2 3
Соколов Юридический 2 251 3 2 4
Михайлова Математический 3 341 3 3 3
Новиков Юридический 3 351 4 3 4
Федорова Экономический 4 481 4 4 2

Экономический:
  Смирнова, курс 1, группа 181
  Попова, курс 2, группа 281
  Федорова, курс 4, группа 481
Математический:
  Кузнецов, курс 1, группа 141
  Петрова, курс 2, группа 241
Юридический:
  Соколов, курс 2, группа 251
*/
