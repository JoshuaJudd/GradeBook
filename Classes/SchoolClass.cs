using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class SchoolClass {
        public string CourseName { get; }
        public CourseCode Code { get; }
        public string InstructorName { get; }


        private readonly Dictionary<CourseCode, string> NameMap = new();
        public SchoolClass(CourseCode _code, string _courseName,  string _instructor) {
            InitializeNameMap();

            CourseName = NameMap[_code];
            Code = _code;
            InstructorName = _instructor;
        }

        private void InitializeNameMap() {
            NameMap.Add(CourseCode.ENG, "English Language");
            NameMap.Add(CourseCode.COMP, "Computer Science 101");
            NameMap.Add(CourseCode.MATH, "Math for the Real World");
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
    }
}