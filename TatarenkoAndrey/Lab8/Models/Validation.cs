

using System.Text.RegularExpressions;

namespace Lab8.Models
{
    public static class Validation
    {
        public static bool isCorrect(Student student)
        {
            Regex regex_string = new Regex(@"^[a-z]+$", RegexOptions.IgnoreCase);
            Regex regex_group = new Regex(@"^[A-Z]{1,3}-[0-9]{2,3}[a-z]{1,2}$", RegexOptions.IgnoreCase);

            if (student.FirstName == null || !regex_string.IsMatch(student.FirstName))
            {
                return false;
            }
            else if (student.SurName == null || !regex_string.IsMatch(student.SurName) )
            {
                return false;
            }
            else if (student.Group == null || !regex_group.IsMatch(student.Group))
            {
                return false;
            }
            else if (student.AcademicPerformance == 0 || student.AcademicPerformance > 100 || student.AcademicPerformance < 0 )
            {
                return false;
            }
            return true;
        }
    }
}
