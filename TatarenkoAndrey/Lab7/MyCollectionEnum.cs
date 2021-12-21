using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab7
{
    public class MyCollectionEnum : IEnumerator
    {
        public List<Student> _stud;

        int position = -1;
        public MyCollectionEnum(List<Student> stud)
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
