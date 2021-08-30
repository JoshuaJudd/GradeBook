using System;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class StudentGrade {
        #region PUBLIC
        public CourseCode CourseCode { get; }
        public double StudentPercentageGrade { get; }
        public string StudentLetterGrade { get; }
        #endregion
        
        public StudentGrade(CourseCode _code, double _percentage, string _let) {
            CourseCode = _code;
            StudentPercentageGrade = _percentage;
            StudentLetterGrade = _let;
        }
        
    }
}