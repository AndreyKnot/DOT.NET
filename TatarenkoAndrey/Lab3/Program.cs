using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Xml;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyCollection = new Coll();
            MyCollection.Add(new Student());

            int option;
            bool inMenu = true;
            string path = "lab03.json";
            var serializer = new DataContractJsonSerializer(typeof(List<Student>));
            while (inMenu)
            {
                Console.WriteLine("Choose options:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Output all students");
                Console.WriteLine("4. Serialization");
                Console.WriteLine("5. Deserialization");
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

                        Student s = new Student(firstname, surname, groupIndex, faculty, specialization,
                            academicPerformance, dateOfBirth, dateOfEnter);
                        MyCollection.Add(s);
                        break;
                    case 2:
                        int id;
                        Console.Write("\nEnter student id: ");
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.Write("\nError! Invalid datatype. \n");
                            break;
                        }

                        bool result = MyCollection.Remove(id);

                        if (result)
                        {
                            Console.Write("\nStudent was deleted succsessfully.\n");
                        }
                        else
                        {
                            Console.Write("\nError! Invalid student id. \n");
                        }
                        break;
                    case 3:
                        int i = 0;
                        foreach (var stud in MyCollection)
                        {
                            Console.WriteLine("\nStudent ID:           " + i);
                            stud.Print();
                            i++;
                        }
                        break;
                    case 4:
                        using (var file = new FileStream(path, FileMode.Create))
                        {
                            using (var jsonw = JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.GetEncoding("utf-8")))
                            {
                                serializer.WriteObject(jsonw, MyCollection.GetStudents());
                                jsonw.Flush();
                            }
                        }
                        break;
                    case 5:
                        List<Student> obj = Activator.CreateInstance<List<Student>>();
                        using (FileStream file = new FileStream(path, FileMode.Open))
                        {
                            using (XmlDictionaryReader jsonr = JsonReaderWriterFactory.CreateJsonReader(file,
                                    Encoding.GetEncoding("utf-8"), XmlDictionaryReaderQuotas.Max, null))
                            {
                                obj = serializer.ReadObject(jsonr) as List<Student>;
                            }
                        }
                        MyCollection.Clear();
                        foreach (var stud in obj)
                        {
                            stud.Printer = new ConsolePrinter();
                            MyCollection.Add(stud);
                        }
                        break;
                    case 0:
                        inMenu = false;
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
