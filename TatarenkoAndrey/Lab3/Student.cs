using System;
using System.Runtime.Serialization;

namespace Lab3
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string GroupIndex { get; set; }
        [DataMember]
        public string Faculty { get; set; }
        [DataMember]
        public int Specialization { get; set; }
        [DataMember]
        public int AcademicPerformance { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public DateTime DateOfEnter { get; set; }
        [IgnoreDataMember]
        public IPrinter Printer { get; set; }
        public Student() : this("empty", "empty", "e", "empty", 0, 0, new DateTime(1000, 1, 1), new DateTime(1000, 1, 1))
        {

        }
        public Student(string FirstName, string SurName, string GroupIndex, string Faculty,
            int Specialization, int AcademicPerformance, DateTime DateOfBirth, DateTime DateOfEnter)
        {
            this.FirstName = FirstName;
            this.SurName = SurName;
            this.GroupIndex = GroupIndex;
            this.Faculty = Faculty;
            this.Specialization = Specialization;
            this.AcademicPerformance = AcademicPerformance;
            this.DateOfBirth = DateOfBirth;
            this.DateOfEnter = DateOfEnter;
            this.Printer = new ConsolePrinter();
        }
        public void Print()
        {
            Printer.Print(ToString());
        }
        public override string ToString()
        {
            return "Fristname:             " + FirstName +
                  "\nSurname:              " + SurName +
                  "\nDate of birth:        " + DateOfBirth.Day + "." + DateOfBirth.Month + "." + DateOfBirth.Year +
                  "\nDate of enter:        " + DateOfEnter.Day + "." + DateOfEnter.Month + "." + DateOfEnter.Year +
                  "\nIndex of group:       " + GroupIndex +
                  "\nFaculty:              " + Faculty +
                  "\nSpecialization:       " + Specialization +
                  "\nAcademic Performance: " + AcademicPerformance + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Student s = obj as Student;
            if (s == null)
            {
                return false;
            }
            return s.FirstName == this.FirstName &&
                    s.SurName == this.SurName &&
                    s.GroupIndex == this.GroupIndex &&
                    s.Faculty == this.Faculty &&
                    s.Specialization == this.Specialization &&
                    s.AcademicPerformance == this.AcademicPerformance &&
                    s.DateOfBirth == this.DateOfBirth &&
                    s.DateOfEnter == this.DateOfEnter;
        }
    }
}
