/*
Решить задачу, разработав собственную структуру для хранения информации
Замечания:
- Во всех задачах данного раздела подразумевается, что исходная информация хранится в 
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором 
объекте; результирующая информация должна быть записана в файл output.txt.
- Для хранения данных внутри программы организовать массив структур.
- Сортировку данных реализовать, реализуя метод CompareTo(T) стандартного интерфейса 
IComparable<in T>.
На основе данных входного файла составить список вкладчиков банка, включив 
следующие данные: ФИО, № счета, сумма, год открытия счета. Вывести в новый файл 
информацию о тех вкладчиках, которые открыли вклад в текущем году, отсортировав их 
по сумме вклада.
*/

using System;
using System.IO;
using System.Collections.Generic;

struct Bank : IComparable<Bank>
{
    public string surname;
    public string name;
    public string patronymicn;
    public int accountNumber;
    public double amount;
    public int yearOpened;

    public Bank(string surname, string name, string patronymicn, int accountNumber, double amount, int yearOpened)
    {
        this.surname = surname;
        this.name = name;
        this.patronymicn = patronymicn;
        this.accountNumber = accountNumber;
        this.amount = amount;
        this.yearOpened = yearOpened;
    }

    public int CompareTo(Bank other)
    {
        if (this.amount == other.amount) 
            return 0;  
        else if (this.amount > other.amount) 
            return 1;
        else 
            return -1;
    }
}

class Program
{
    static void Main()
    {
        StreamReader fileIn = new StreamReader("d:/Struct2/input.txt");
        List<Bank> accounts = new List<Bank>();

        while (!fileIn.EndOfStream)
        {
            string[] data = fileIn.ReadLine().Split(' ');
            Bank account = new Bank
            {
                surname = data[0],
                name = data[1],
                patronymicn = data[2],
                accountNumber = int.Parse(data[3]),
                amount = double.Parse(data[4]),
                yearOpened = int.Parse(data[5])
            };
            accounts.Add(account);
        }
        fileIn.Close();

        List<Bank> yearOpenedAccounts = new List<Bank>();
        for (int i = 0; i < accounts.Count; i++)
        {
            if (accounts[i].yearOpened == DateTime.Now.Year)
            {
                yearOpenedAccounts.Add(accounts[i]);
            }
        }

        yearOpenedAccounts.Sort();

        StreamWriter fileOut = new StreamWriter("d:/Struct2/output.txt");
        for (int i = 0; i < yearOpenedAccounts.Count; i++)
        {
            fileOut.WriteLine($"{yearOpenedAccounts[i].surname} " +
                $"{yearOpenedAccounts[i].name} " +
                $"{yearOpenedAccounts[i].patronymicn}; " +
                $"{yearOpenedAccounts[i].accountNumber}; " +
                $"{yearOpenedAccounts[i].amount}; " +
                $"{yearOpenedAccounts[i].yearOpened}");
        }
        fileOut.Close();
    }
}

/*
Иванов Михаил Павлович 463895 1000000 2014
Смирнова София Станиславовна 983647 55000 2023
Кузнецов Александр Алексеевич 345267 100000 2017
Попова Анна Дмитриевна 981348 320000 2023
Васильев Максим Валерьевич 294387 1400000 2019
Петрова Мария Михайловна 764902 200000 2023
Соколов Артем Андреевич 398754 98000 2020
Михайлова Ева Игоревна 098546 47000 2023

Михайлова Ева Игоревна; 98546; 47000; 2023
Смирнова София Станиславовна; 983647; 55000; 2023
Петрова Мария Михайловна; 764902; 200000; 2023
Попова Анна Дмитриевна; 981348; 320000; 2023
*/
