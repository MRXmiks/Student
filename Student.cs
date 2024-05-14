using System;
using System.Collections.Generic;
using System.Linq;

public static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Иванов Иван Иванович", "101", "Факультет информационных технологий", "Программная инженерия", 4.5),
            new Student("Петров Петр Петрович", "102", "Факультет информационных технологий", "Компьютерные науки", 3.8),
            new Student("Сидоров Сидор Сидорович", "103", "Факультет экономики", "Экономика", 4.0),
            new Student("Кузнецова Мария Сергеевна", "104", "Факультет информационных технологий", "Информационные системы", 4.2),
        };

        // Условие: учится на факультете "Факультет информационных технологий" и имеет средний балл более 4.0
        List<Student> filteredStudents = FilterStudents(students, student =>
            student.Faculty == "Факультет информационных технологий" && student.AverageGrade > 4.0);

        // Вывод отфильтрованных студентов
        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"{student.FullName}, {student.Faculty}, {student.Specialty}, {student.AverageGrade}");
        }
    }    
}
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



