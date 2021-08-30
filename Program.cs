using System;
using System.Collections.Generic;
using System.Threading;
using GradeBook.Classes;
using GradeBook.Enums;

namespace GradeBook {
    class Program {
        private static List<User> students = new();

        private static void GenerateStudents() {
            var r = new Random();

            for (var i = 0; i < r.Next(0, 30); i++) {
                students.Add(new User());
            }
        }

        private static void DisplayStudentList() {
            Console.WriteLine("NUMBER OF ENROLLED STUDENTS: " + students.Count);
            if (students.Count != 0) {
                foreach (var student in students) {
                    Console.WriteLine("______________________________STUDENT INFORMATION_____________________________");
                    Console.WriteLine(student.FullName + " | " + student.Grade);
                    Console.WriteLine(student.School.InstitutionName + " | " + student.School.District);
                    Console.WriteLine("Number of courses enrolled in: " + student.Classes.Count);
                    Console.WriteLine("______________________________________________________________________________");
                    Console.WriteLine("==============COURSE LIST================");
                    foreach (var studentClass in student.Classes) {
                        Console.WriteLine(studentClass.Code.ToString() 
                                          + " | "          
                                          + studentClass.CourseName 
                                          + ", " 
                                          + studentClass.InstructorName);
                        foreach (var classGrade in student.ClassGrades) {
                            if (studentClass.Code == classGrade.CourseCode) {
                                Console.WriteLine(classGrade.StudentPercentageGrade 
                                                  + "% | " 
                                                  + classGrade.StudentLetterGrade);
                            }
                        }
                        Console.WriteLine("______________________________________________________________________________");
                    }
                }
            }
        }

        // MAIN
        private static void Main(string[] args) {
            GenerateStudents();

            DisplayStudentList();
            Console.ReadLine();
        }
    }
}