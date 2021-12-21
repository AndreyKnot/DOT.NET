using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    public static class Calcualtion
    {
        public static void AvgAge(MyCollection students)
        {
            List<Student> studentList = new List<Student>();
            foreach (var item in students)
            {
                studentList.Add(item);
            }
            var avg = studentList.Average(student => FindAge(student.CountAge().ToString()));
            Console.WriteLine("\nAvarange age: " + avg.ToString());
        }
        public static int FindAge(string str)
        {
            int age = 0;
            int start = str.IndexOf(": ");
            if (int.TryParse(str.Substring(start + 2, 2), out age))
            {
                return age;
            }
            return 0;
        }
        public static void AvgPerformance(MyCollection students)
        {
            List<Student> studentList = new List<Student>();
            foreach (var item in students)
            {
                studentList.Add(item);
            }
            var avg = studentList.Average(student => student.AcademicPerformance);
            Console.WriteLine("Avarange performance: " + avg.ToString() + "\n");
        }
    }
}
