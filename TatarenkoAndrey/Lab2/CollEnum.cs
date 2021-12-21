using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    public class CollEnum : IEnumerator
    {
        public List<Student> _stud;

        int position = -1;
        public CollEnum(List<Student> stud)
        {
            _stud = stud;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _stud.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Student Current
        {
            get
            {
                try
                {
                    return _stud[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
