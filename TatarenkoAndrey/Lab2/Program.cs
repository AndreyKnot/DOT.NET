using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentArray = new Student[2];
            Student stud = null;

            for (int i = 0; studentArray.Length > i; i++)
            {
                stud = new Student();
                studentArray[i] = stud;
            }
            stud = new Student("Julia", "Krakova", "g", "GIT", 123, 99, new DateTime(2001, 10, 20), new DateTime(2021, 10, 20));

            var MyCollection = new Coll();

            foreach (var s in studentArray)
            {
                MyCollection.Add(s);
            }

            Console.WriteLine("Students list:");
            int id = 0;
            foreach (var s in MyCollection)
            {
                Console.WriteLine("Student ID:           " + id++);
                s.Print();
            }
            Console.WriteLine("----------------");

            MyCollection.Add(stud);

            Console.WriteLine("Students list:");
            id = 0;
            foreach (var s in MyCollection)
            {
                Console.WriteLine("Student ID:           " + id++);
                s.Print();
            }
            Console.WriteLine("----------------");

            Student result = MyCollection.GetStudent(stud);
            if (result == null)
            {
                Console.WriteLine("Student has not been found.");
            }
            else
            {
                Console.WriteLine("Student has been found.\n");
                result.Print();
            }
            Console.WriteLine("----------------");
            Console.ReadKey();
        }
    }
}
