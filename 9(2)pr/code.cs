using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader fileIn1 = new StreamReader ("d:/Files9.3/text1.txt"))
        {
            using (StreamReader fileIn2 = new StreamReader ("d:/Files9.3/text2.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter ("d:/Files9.3/text3.txt"))
                {
                    string line1, line2;
                    while ((line1 = fileIn1.ReadLine()) != null && (line2 = fileIn2.ReadLine()) != null)
                    {
                        string[] numbers1 = line1.Split (" ");
                        string[] numbers2 = line2.Split (" ");
                        for (int i = 0;  i < numbers1.Length; i++)
                        {
                            int num1 = int.Parse(numbers1[i]);
                            int num2 = int.Parse(numbers2[i]);
                            if (num1 % num2 == 0)
                            {
                                fileOut.Write(num1 / num2 + " ");
                            }
                            else if (num2 % num1 == 0)
                            {
                                fileOut.Write(num2 / num1 + " ");
                            }
                        }
                        fileOut.WriteLine();
                    }
                }
            }
        }
    }
}

/*
2 10 7 11 20 10
2 10 7 11 20 10

4 5 5 11 10 20
4 5 5 11 10 20

2 2 1 2 2 
2 2 1 2 2
*/
