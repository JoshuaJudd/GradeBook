using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class SchoolClass {
        #region PUBLIC

        public string CourseName { get; }
        public CourseCode Code { get; }
        public string InstructorName { get; }

        #endregion

        #region PRIVATE

        private readonly Dictionary<CourseCode, string> NameMap = new();
        private readonly Random Last_R = new();
        private readonly Random Course_R = new();

        #endregion
        public SchoolClass() {
            InitializeNameMap();
            var courseCode = GetRandomCourseCode();

            CourseName = NameMap[courseCode];
            Code = courseCode;
            InstructorName = GetRandomLastName().ToString();
        }

        #region RANDOM DATA FORM ENUMS

        private CourseCode GetRandomCourseCode() {
            var courses = Enum.GetValues(typeof(CourseCode));
            return (CourseCode) courses.GetValue(Course_R.Next((courses.Length)));
        }
        
        private RandoLastNames GetRandomLastName() {
            var names = Enum.GetValues(typeof(RandoLastNames));
            return (RandoLastNames) names.GetValue(Last_R.Next((names.Length)));
        }

        #endregion

        #region INITIALIZATION
        private void InitializeNameMap() {
            // THIS COULD BE A CALL TO A DATABASE INSTEAD OF HARDCODED DATA.

            NameMap.Add(CourseCode.ENG, "English Language");
            NameMap.Add(CourseCode.COMP, "Computer Science 101");
            NameMap.Add(CourseCode.MATH, "Math for the Real World");
            NameMap.Add(CourseCode.WRI, "Writing epic book series 101");
            NameMap.Add(CourseCode.GYM, "Building a Workout Routine");
            NameMap.Add(CourseCode.BIO, "Biology 101");
            NameMap.Add(CourseCode.PRO, "Prototyping Basics");
            NameMap.Add(CourseCode.BLM, "How to make the perfect Bacon, Lettuce, Mayo Sandwich");
            NameMap.Add(CourseCode.PPO, "Fishing");
            NameMap.Add(CourseCode.DLL, "Downloading Sketchy Files from the Internet");
            NameMap.Add(CourseCode.SHU, "How to Build Homemade Shoes");
            NameMap.Add(CourseCode.FUN, "Military Basic Training");
            NameMap.Add(CourseCode.HUH, "Psychology 401");
        }
        #endregion
    }
}