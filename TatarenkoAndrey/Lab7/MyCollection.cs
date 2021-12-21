using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Lab7
{
    public class MyCollection : IEnumerable
    {

        private List<Student> _studentsArray = new List<Student>();

        public void Add(Student student)
        {
            if (student is null)
            {
                student = new Student();
            }
            _studentsArray.Add(student);
        }
        public bool RemoveById(int id)
        {
            if (id >= _studentsArray.Count || 0 > id)
            {
                return false;
            }
            _studentsArray.RemoveAt(id);
            return true;
        }
        public bool RemoveByFaculty(string faculty)
        {
            bool flag = false;
            var query = from studens in _studentsArray
                        where studens.Faculty == faculty
                        select studens;

            foreach (var item in query.ToArray())
            {
                flag = _studentsArray.Remove(item);
            }
            return flag;
        }
        public bool RemoveBySpecialization(int specialization)
        {
            bool flag = false;
            var query = (from studens in _studentsArray
                        where studens.Specialization == specialization
                        select studens).ToArray();
            foreach (var item in query)
            {
                flag = _studentsArray.Remove(item);
            }
            return flag;
        }
        public bool RemoveByGroup(string group)
        {
            bool flag = false;
            var query = _studentsArray.Where(_studentsArray => _studentsArray.GetGroup().ToString() == group)
                                      .Select(_studentsArray => _studentsArray);
            //var guery = from studens in _studentsArray
            //            where studens.GetGroup().ToString() == group
            //            select studens;
            foreach (var item in query.ToArray())
            {
                flag = _studentsArray.Remove(item);
            }
            return flag;
        }
        public void Clear()
        {
            _studentsArray.Clear();
        }
        public Student GetStudentById(int id)
        {
            int i = 0;
            if (id >= _studentsArray.Count || 0 > id)
            {
                return null;
            }
            foreach (var stud in _studentsArray)
            {
                if (id == i)
                {
                    return stud;
                }
                i++;
            }
            return null;
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
        public List<Student> GetStudents()
        {
            return _studentsArray;
        }
        public int Count()
        {
            return _studentsArray.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MyCollectionEnum GetEnumerator()
        {
            return new MyCollectionEnum(_studentsArray);
        }
    }
}
