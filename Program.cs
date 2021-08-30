using System;
using System.Collections.Generic;
using GradeBook.Classes;
using GradeBook.Enums;

namespace GradeBook {
    class Program {
        public static User Student;

        #region RANDOM VARIABLES
        private static readonly Random First_R = new Random();
        private static readonly Random Last_R = new Random();
        private static readonly Random Grade_R = new Random();
        private static Random Course_R = new Random();
        private static Random CourseNum_R = new Random();
        private static Random Institution_R = new Random();
        #endregion

        #region RANDOMIZED GETTERS

        static RandoFirstNames GetRandomFirstName() {
            var names = Enum.GetValues(typeof(RandoFirstNames));
            return (RandoFirstNames) names.GetValue(First_R.Next((names.Length)));
        }

        static RandoLastNames GetRandomLastName() {
            var names = Enum.GetValues(typeof(RandoLastNames));
            return (RandoLastNames) names.GetValue(Last_R.Next((names.Length)));
        }

        static SchoolGrade GetRandomSchoolGrade() {
            var grades = Enum.GetValues(typeof(SchoolGrade));
            return (SchoolGrade) grades.GetValue(Grade_R.Next((grades.Length)));
        }

        static CourseCode GetRandomCourseCode() {
            var courses = Enum.GetValues(typeof(CourseCode));
            return (CourseCode) courses.GetValue(Grade_R.Next((courses.Length)));
        }

        static LetterGrade GetRandomLetterGrade() {
            var letter = Enum.GetValues(typeof(LetterGrade));
            return (LetterGrade) letter.GetValue(Grade_R.Next((letter.Length)));
        }

        static InstitutionCode GetRandomInstitution() {
            var institution = Enum.GetValues(typeof(InstitutionCode));
            return (InstitutionCode) institution.GetValue(Grade_R.Next((institution.Length)));
        }
        
        static DistrictCode GetRandomDistrict() {
            var district = Enum.GetValues(typeof(DistrictCode));
            return (DistrictCode) district.GetValue(Grade_R.Next((district.Length)));
        }

        #endregion

        #region POPULATE STUDENT DATA

        private static Institution GenerateInstitution() {
            return new Institution(GetRandomInstitution(), GetRandomDistrict());
        }
        
        
        // POPULATE THE STUDENT'S FIELDS
        static void PopulateStudent() {
            Student.FirstName = GetRandomFirstName().ToString();
            Student.LastName = GetRandomLastName().ToString();
            Student.FullName = Student.FirstName + ' ' + Student.LastName;
            Student.Grade = GetRandomSchoolGrade();
            Student.School = GenerateInstitution();
        }

        // POPULATE THE STUDENT'S CLASSES
        static void PopulateClasses() {
            Random r = new Random();

            for (int i = 0; i < r.Next(1, 6); i++) {
                var classCode = GetRandomCourseCode();
                Student.Classes.Add(new SchoolClass(
                    classCode,
                    classCode + "101",
                    GetRandomLastName().ToString()));
            }
        }

        // POPULATE THE STUDENT'S CLASSES GRADES
        static void PopulateStudentGrades() {
            if (Student.Classes.Count == 0) {
                return;
            }

            Random r = new Random();

            foreach (var sClass in Student.Classes) {
                var tempGrade = r.Next(50, 100);
                var lg = tempGrade switch {
                    >= 90 => LetterGrade.A,
                    < 90 and >= 80 => LetterGrade.B,
                    < 80 and >= 70 => LetterGrade.C,
                    < 70 and >= 60 => LetterGrade.D,
                    _ => LetterGrade.F
                };

                Student.ClassGrades.Add(new StudentGrade(
                    (CourseCode) sClass.Code,
                    tempGrade,
                    lg.ToString()));
            }
        }

        #endregion

        #region DISPLAY METHODS

        static void DisplayStudentInfo() {
            Console.WriteLine("_______________STUDENT INFORMATION_______________");
            Console.WriteLine(Student.FullName);
            Console.WriteLine("Student's School Year: " + Student.Grade);
            Console.WriteLine("Number of Courses: " + Student.Classes.Count);
            Console.WriteLine("_______________INSTITUTION INFORMATION_______________");
            Console.WriteLine("SCHOOL NAME: " + Student.School.InstitutionName);
            Console.WriteLine("SCHOOL DISTRICT: " + Student.School.District);
        }

        static void DisplayStudentCoursesAndGrades() {
            foreach (var course in Student.Classes) {
                Console.WriteLine("______________________________");
                Console.WriteLine(course.CourseName + ": " +
                                  course.Code + ", " +
                                  course.InstructorName);
                foreach (var sGrade in Student.ClassGrades) {
                    if (course.Code == sGrade.CourseCode) {
                        Console.WriteLine("Student's Course Grade: " +
                                          sGrade.StudentLetterGrade + " / " +
                                          sGrade.StudentPercentageGrade);
                    }
                }
            }
        }

        #endregion
        
        // CREATE A STUDENT TO WORK WITH
        private static void CreateStudent() {
            Student = new User();
            // create a student
            PopulateStudent();

            // Populate the student's classes
            PopulateClasses();

            // populate the student's classes grades
            PopulateStudentGrades();
        }

        // DISPLAY THE STUDENT'S INFORMATION
        private static void DisplayStudent() {
            DisplayStudentInfo();
            DisplayStudentCoursesAndGrades();
        }

        // MAIN
        private static void Main(string[] args) {
            CreateStudent();
            DisplayStudent();
        }
    }
}