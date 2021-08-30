using GradeBook.Enums;

namespace GradeBook.Classes {
    public class StudentGrade {
        
        public CourseCode CourseCode { get; }
        public double StudentPercentageGrade { get; }
        public string StudentLetterGrade { get; }

        public StudentGrade(CourseCode _code, double _perc, string _let) {
            CourseCode = _code;
            StudentPercentageGrade = _perc;
            StudentLetterGrade = _let;
        }
    }
}