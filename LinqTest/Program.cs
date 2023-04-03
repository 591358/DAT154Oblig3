
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Oblig3.Class1;

namespace Oblig3
{
    internal class Class1
    {

        public static void Main(string[] args)
        {
            List<Course> courses = new()
            {
                new Course{coursename = "DAT110", coursecode = "110"},
                new Course{coursename = "DAT154", coursecode = "154" }

            };

            List<Student> students = new()
            {
                new Student { name = "per", age = 12 , grade ="F", coursecode="110"},
                new Student { name = "atle", age = 12 , grade ="F", coursecode="110"},
                new Student { name = "johannes", age = 12 , grade ="F", coursecode="154"},
                new Student{name = "knut", age =23, grade ="B", coursecode="154"},
                new Student{name= "micro", age=30, grade="C", coursecode="110"},
                new Student{name="perkeles", age=69,grade="B",  coursecode="110"}
            };


            List<Grade> grades = new()
            {
                  new Grade{grades = "F", coursename = "DAT110"},
                  new Grade{grades = "B", coursename = "DAT154"},
                  new Grade{grades = "C", coursename = "DAT110"},
                  new Grade{grades = "A", coursename = "DAT109"},
                  new Grade{grades = "D", coursename = "DAT107"},
                  new Grade{grades = "F", coursename = "DAT108"}

            };

            string dat110 = "DAT110";
            /* Console.WriteLine("Search for name: ");
             string substring = Console.ReadLine();*/

            /* var listOfStudentsMatchingSubstring = students.Where(a => a.name.Contains(substring));*/
            var listOfStudentsAndGradesMatchingCourse = courses.Where(x => x.coursename.Equals("DAT154")).Join(students, sc => sc.coursecode, cc => cc.coursecode, (cc, sc) => new { cc.coursename, sc.name, sc.grade });



            //var listOfgradesEqualOrBetter = grades.Where(grade => grade.grades.CompareTo("D") < 0);

            /* foreach (var grde in listOfgradesEqualOrBetter)
             {
                 Console.WriteLine($"{grde.grades}");
             }*/

            /*foreach (var s in listOfStudentsMatchingSubstring)
            {
                Console.WriteLine(s.name);
            }*/

            /*  foreach (var t in listOfStudentsAndGradesMatchingCourse)
              {
                  Console.WriteLine($"Coursecode: {t.coursename} - name: {t.name} - grade: {t.grade}");
              }*/



        }
        public class Student
        {
            public string name { get; set; }
            public int age { get; set; }

            public string grade { get; set; }

            public string coursecode { get; set; }

        }
        public class Course
        {
            public string coursename { get; set; }
            public string coursecode { get; set; }

        }

        public class Grade
        {
            public string grades { get; set; }

            public string coursename { get; set; }



        }
    }
}
