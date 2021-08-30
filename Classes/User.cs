using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class User {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Institution School { get; set; }
        public SchoolGrade Grade { get; set; }
        public readonly List<SchoolClass> Classes = new List<SchoolClass>();
        public readonly List<StudentGrade> ClassGrades = new List<StudentGrade>();
    }
}