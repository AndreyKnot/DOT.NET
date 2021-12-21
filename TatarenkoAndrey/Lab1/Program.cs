using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1
{
    public interface IPrinter
    {
        void Print(string str);
    }
    public class ConsolePrinter : IPrinter
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Student
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string GroupIndex { get; set; }
        public string Faculty { get; set; }
        public int Specialization { get; set; }
        public int AcademicPerformance { get; set; }
        public DateTime DateOFBirth { get; set; }
        public DateTime DateOfEnter { get; set; }
        public IPrinter Printer;

        public override string ToString()
        {
            return "Fristname:            " + Firstname + 
                 "\nSurname:              " + Surname +
                 "\nDate of birth:        " + DateOFBirth.Day + "." + DateOFBirth.Month + "." + DateOFBirth.Year +
                 "\nDate of enter:        " + DateOfEnter.Day + "." + DateOfEnter.Month + "." + DateOfEnter.Year +
                 "\nIndex of group:       " + GroupIndex + 
                 "\nFaculty:              " + Faculty +
                 "\nSpecialization:       " + Specialization + 
                 "\nAcademic Performance: " + AcademicPerformance + "\n";
        }

        public void Print()
        {
            Printer.Print(ToString());
        }

        public Student() : this("empty", "empty", "e", "empty", 0, 0, new DateTime(1000, 1, 1), new DateTime(1000, 1, 1))
        {

        }

        public Student(string firstname, string surname, string groupIndex, string faculty,
            int specialization, int academicPerformance, DateTime dateOfBirth, DateTime dateOfEnter)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.GroupIndex = groupIndex;
            this.Faculty = faculty;
            this.Specialization = specialization;
            this.AcademicPerformance = academicPerformance;
            this.DateOFBirth = dateOfBirth;
            this.DateOfEnter = dateOfEnter;
            this.Printer = new ConsolePrinter();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            students.Add(new Student());
            int option;
            bool Menu = true;
            while (Menu)
            {
                Console.WriteLine("Choose options:");
                Console.WriteLine("1. Add stud");
                Console.WriteLine("2. Remove stud");
                Console.WriteLine("3. Output all students");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your option: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("\nError! Invalid datatype.\n");
                    option = -1;
                }

                switch (option)
                {
                    case 1:
                        Regex regex_string = new Regex(@"^[a-z]+$", RegexOptions.IgnoreCase);

                        string firstname;
                        string surname;
                        string groupIndex;
                        string faculty;
                        int specialization;
                        int academicPerformance;
                        DateTime dateOfBirth;
                        DateTime dateOfEnter;

                        Console.Write("Enter firstname of student: ");
                        firstname = Console.ReadLine();
                        if (!regex_string.IsMatch(firstname))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter surname of student: ");
                        surname = Console.ReadLine();
                        if (!regex_string.IsMatch(surname))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter index of group: ");
                        groupIndex = Console.ReadLine();
                        if (!regex_string.IsMatch(groupIndex))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter faculty of student: ");
                        faculty = Console.ReadLine();
                        if (!regex_string.IsMatch(faculty))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter specialization of student: ");
                        if (!int.TryParse(Console.ReadLine(), out specialization))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter academic performance of student: ");
                        if (!int.TryParse(Console.ReadLine(), out academicPerformance))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        if (academicPerformance > 100 || academicPerformance < 0)
                        {
                            Console.WriteLine("\nError! Invalid value\n");
                            break;
                        }

                        Console.Write("Enter date of birth of student (1.1.1000): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Console.Write("Enter date of enter to university (1.1.1000): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out dateOfEnter))
                        {
                            Console.WriteLine("\nError! Invalid datatype.\n");
                            break;
                        }

                        Student s = new Student(firstname, surname, groupIndex, faculty, specialization, academicPerformance, dateOfBirth, dateOfEnter);
                        students.Add(s);
                        break;
                    case 2:
                        int id;
                        Console.Write("\nEnter student id: ");
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.Write("\nError! Invalid datatype. \n");
                            break;
                        }

                        bool result = id <= students.Count - 1;
                        if (result && id >= 0)
                        {
                            students.RemoveAt(id);
                            Console.Write("\nStudent was deleted succsessfully.\n");
                        }
                        else
                        {
                            Console.Write("\nError! Invalid student id. \n");
                        }
                        break;
                    case 3:
                        if (students.Count > 0)
                        {
                            int i = 0;
                            foreach (Student stud in students)
                            {
                                Console.WriteLine("\nStudent ID:           " + i);
                                stud.Print();
                                i++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nList is empty!\n");
                        }
                        break;
                    case 0:
                        Menu = false;
                        break;
                    default:
                        if (option == -1)
                        {
                            break;
                        }
                        Console.WriteLine("\nIncorrect option. Try again.\n");
                        break;
                }
            }
        }
    }
}
