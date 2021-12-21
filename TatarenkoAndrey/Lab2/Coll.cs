using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    public class Coll : IEnumerable
    {
        private List<Student> _studentsArray = new List<Student>();

        public void Add(Student student)
        {
            if(student is null)
            {
                student = new Student();
            }
            _studentsArray.Add(student);
        }

        public Student GetStudent(Student student)
        {
            foreach (var stud in _studentsArray)
            {
                if (stud.Equals(student))
                {
                    return student;
                }
            }
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CollEnum GetEnumerator()
        {
            return new CollEnum(_studentsArray);
        }
    }
}
