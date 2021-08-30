using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class User {
        #region PUBLIC
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Institution School { get; set; }
        public SchoolGrade Grade { get; set; }
        public List<SchoolClass> Classes = new();
        public readonly List<StudentGrade> ClassGrades = new();

        #endregion

        #region PRIVATE

        private readonly Random First_R = new();
        private readonly Random Last_R = new();
        private readonly Random Grade_R = new();
        private readonly Random CourseNum_R = new();

        #endregion

        public User() {
            CreateStudent();
        }

        #region CREATE A RANDOM USER AND POPULATE WITH DATA
        #region CREATE METHOD
        // CREATE A STUDENT TO WORK WITH
        private void CreateStudent() {
            // create a student
            PopulateStudent();

            // Populate the student's classes
            PopulateClasses();

            // populate the student's classes grades
            PopulateStudentGrades();
        }
        #endregion

        #region POPULATE STUDENT DATA

        // POPULATE THE STUDENT"S INFORMATION FIELDS
        private void PopulateStudent() {
            FirstName = GetRandomFirstName().ToString();
            LastName = GetRandomLastName().ToString();
            FullName = FirstName + ' ' + LastName;
            Grade = GetRandomSchoolGrade();
            School = new Institution();
        }

        // POPULATE THE STUDENT'S CLASSES
        private void PopulateClasses() {
            var r = new Random();
            var tempList = new List<SchoolClass>();

            for (var i = 0; i < r.Next(1, 6); i++) {
                tempList.Add(new SchoolClass());
            }

            Classes = tempList.Distinct().ToList();
        }

        // POPULATE THE STUDENT'S CLASSES GRADES
        private void PopulateStudentGrades() {
            if (Classes.Count == 0) {
                return;
            }

            var r = new Random();

            foreach (var sClass in Classes) {
                var tempGrade = r.Next(50, 100);
                var lg = tempGrade switch {
                    >= 90 => LetterGrade.A,
                    < 90 and >= 80 => LetterGrade.B,
                    < 80 and >= 70 => LetterGrade.C,
                    < 70 and >= 60 => LetterGrade.D,
                    _ => LetterGrade.F
                };

                ClassGrades.Add(new StudentGrade(
                    (CourseCode) sClass.Code,
                    tempGrade,
                    lg.ToString()));
            }
        }

        #endregion

        #region GETTING THE RANDOM DATA FROM THE ENUMS

        private RandoFirstNames GetRandomFirstName() {
            var names = Enum.GetValues(typeof(RandoFirstNames));
            return (RandoFirstNames) names.GetValue(First_R.Next((names.Length)));
        }

        private RandoLastNames GetRandomLastName() {
            var names = Enum.GetValues(typeof(RandoLastNames));
            return (RandoLastNames) names.GetValue(Last_R.Next((names.Length)));
        }

        private SchoolGrade GetRandomSchoolGrade() {
            var grades = Enum.GetValues(typeof(SchoolGrade));
            return (SchoolGrade) grades.GetValue(Grade_R.Next((grades.Length)));
        }


        #endregion
        #endregion
    }
}