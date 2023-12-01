using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile1 = "file1.txt";
        string inputFile2 = "file2.txt";
        string outputFile = "output.txt";

        using (FileStream fileIn1 = new FileStream(inputFile1, FileMode.Open))
        using (FileStream fileIn2 = new FileStream(inputFile2, FileMode.Open))
        using (StreamWriter fileOut = new StreamWriter(outputFile))
        {
            StreamReader reader1 = new StreamReader(fileIn1);
            StreamReader reader2 = new StreamReader(fileIn2);

            while (!reader1.EndOfStream && !reader2.EndOfStream)
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                string[] numbers1 = line1.Split(' ');
                string[] numbers2 = line2.Split(' ');

                for (int i = 0; i < numbers1.Length; i++)
                {
                    int num1 = int.Parse(numbers1[i]);
                    int num2 = int.Parse(numbers2[i]);

                    if (num1 % num2 == 0)
                    {
                        fileOut.Write(num1 / num2 + " ");
                    }
                    if (num2 % num1 == 0)
                    {
                        fileOut.Write(num2 / num1 + " ");
                    }
                }
                fileOut.WriteLine(); // Добавление перехода на новую строку между записями
            }
        }
    }
}

/*
2 10 7 11 20 10
4 5 5 11 10 20
2 2 1 1 2 2
*/
