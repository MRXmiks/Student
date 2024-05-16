using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FullName { get; set; }
    public string GroupNumber { get; set; }
    public string Faculty { get; set; }
    public string Specialty { get; set; }
    public double AverageGrade { get; set; }

    public Student(string fullName, string groupNumber, string faculty, string specialty, double averageGrade)
    {
        FullName = fullName;
        GroupNumber = groupNumber;
        Faculty = faculty;
        Specialty = specialty;
        AverageGrade = averageGrade;
    }
}

public class Program
{
    public static List<Student> FilterStudents(Student[] students, Func<Student, bool> criteria)
    {
        List<Student> result = new List<Student>();
        foreach (var student in students)
        {
            if (criteria(student))
            {
                result.Add(student);
            }
        }
        return result;
    }

    public static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Иванов Иван Иванович", "101", "Факультет информационных технологий", "Программная инженерия", 4.5),
            new Student("Петров Петр Петрович", "102", "Факультет информационных технологий", "Компьютерные науки", 3.8),
            new Student("Сидоров Сидор Сидорович", "103", "Факультет экономикиin", "Экономика", 4.0),
            new Student("Кузнецова Мария Сергеевна", "104", "Факультет информационных технологий", "Информационные системы", 4.2),
        };

        // Список допустимых факультетов
        var validFaculties = students.Select(s => s.Faculty).Distinct().ToList();

        // Ввод данных от пользователя
        Console.Write("Введите название факультета: ");   // Не хватает примера для ввода
        string inputFaculty = Console.ReadLine();

        // Проверка корректности ввода факультета
        if (!validFaculties.Contains(inputFaculty))
        {
            Console.WriteLine("Некорректный факультет. Завершение программы.");   // Не операции для повторного ввода данных и программа закрывается 
            Console.WriteLine("Press any key to exit...");      
            Console.ReadKey();
            return;
        }

        Console.Write("Введите минимальный средний балл: ");
        string inputGrade = Console.ReadLine();
        if (!double.TryParse(inputGrade, out double inputAverageGrade))
        {
            Console.WriteLine("Некорректный ввод среднего балла. Завершение программы.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        // Фильтрация студентов по заданным условиям
        List<Student> filteredStudents = FilterStudents(students, student =>
            student.Faculty == inputFaculty && student.AverageGrade >= inputAverageGrade);

        // Вывод отфильтрованных студентов
        if (filteredStudents.Count > 0)
        {
            Console.WriteLine("Отфильтрованные студенты:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.FullName}, {student.Faculty}, {student.Specialty}, {student.AverageGrade}");
            }
        }
        else
        {
            Console.WriteLine("Нет студентов, удовлетворяющих заданным условиям.");
        }

        // Ожидание нажатия любой клавиши перед закрытием консоли
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}