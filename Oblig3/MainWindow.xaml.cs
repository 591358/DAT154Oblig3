using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Oblig3.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls.Primitives;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Oblig3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dat154Context dx = new();


        public MainWindow()
        {
            InitializeComponent();

            Bindcombo();
            DisplayFailures.MouseDown += new MouseButtonEventHandler(ButtonClick);

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {


            DbSet<Student> students = dx.Students;
            students.Load();


            TestListView.DataContext =
                students.OrderBy(s => s.Studentname).ToList();
        }

        private void OnTextBoxChanged(object sender, TextChangedEventArgs e)
        {

            String substring = StudNameTextBox.Text;
            DbSet<Student> students = dx.Students;
            students.Load();


            TestListView.DataContext =
                students.Where(a => a.Studentname.Contains(substring)).ToList();
        }




        private void Bindcombo()

        {
            DbSet<Course> courselists = dx.Courses;
            DbSet<Grade> gradelist = dx.Grades;
            DbSet<Student> students = dx.Students;
            students.Load();
            courselists.Load();
            gradelist.Load();
            var uniqueGrades = gradelist.GroupBy(a => a.Grade1).Select(y => y.First()).Distinct().ToList();
            var x = courselists.Distinct().ToList();

            CourseAlternatives.DataContext = x;
            SelectName.DataContext = students.ToList();
            SelectGrades.DataContext = uniqueGrades;
            SelectCourse.DataContext = x;


        }

        private void CourseAlternatives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String coursenameString = CourseAlternatives.SelectedValue.ToString();
            Console.WriteLine(coursenameString);
            DbSet<Course> courses = dx.Courses;
            DbSet<Student> students = dx.Students;
            DbSet<Grade> grades = dx.Grades;
            students.Load();
            courses.Load();
            grades.Load();
            var studentAndGrades = courses.Where(x => x.Coursename.Equals(coursenameString)).Join(grades, cc => cc.Coursecode, gc => gc.Coursecode, (cc, gc) => new { cc.Coursename, gc.Student.Studentname, gc.Grade1 }).ToList();
            TestListView.DataContext = studentAndGrades;

        }

        private void SelectGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedGrade = SelectGrades.SelectedValue.ToString();
            Console.WriteLine(selectedGrade);
            DbSet<Course> courses = dx.Courses;
            DbSet<Student> students = dx.Students;
            DbSet<Grade> grades = dx.Grades;
            students.Load();
            courses.Load();
            grades.Load();
            var studentAndGrades = grades.Where(x => x.Grade1.CompareTo(selectedGrade) < 0).Join(courses, cc => cc.Coursecode, gc => gc.Coursecode, (sc, cc) => new { sc.Student.Studentname, cc.Coursename, sc.Grade1 }).ToList();
            TestListView.DataContext = studentAndGrades;
        }

        private void DisplayFailures_Click(object sender, RoutedEventArgs e)
        {
            DbSet<Course> courses = dx.Courses;
            DbSet<Student> students = dx.Students;
            DbSet<Grade> grades = dx.Grades;
            students.Load();
            courses.Load();
            grades.Load();
            var studentAndGrades = grades.Where(x => x.Grade1.CompareTo("F") == 0).Join(courses, cc => cc.Coursecode, gc => gc.Coursecode, (sc, cc) => new { sc.Student.Studentname, cc.Coursename, sc.Grade1 }).ToList();
            TestListView.DataContext = studentAndGrades;
        }

        private void SelectStudent(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            SelectCourse.Visibility = System.Windows.Visibility.Visible;
        }

        private void SelectCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedName = SelectName.SelectedValue.ToString();
            String courseName = SelectCourse.SelectedValue.ToString();

            DbSet<Course> courses = dx.Courses;
            DbSet<Student> students = dx.Students;
            DbSet<Grade> grades = dx.Grades;
            students.Load();
            courses.Load();
            grades.Load();
            var attendee = courses.Where(a => a.Coursename.Equals(courseName)).Join(grades, cr => cr.Coursecode, gr => gr.Coursecode, (cr, gr) => new { gr.Student.Studentname, cr.Coursename, gr.Grade1 }).Where(n => n.Studentname.Equals(selectedName));

            if (attendee.IsNullOrEmpty())
            {
                Course course = courses.Where(a => a.Coursename.Equals(courseName)).First();
                Student updatedStudent = students.Where(a => a.Studentname.Equals(selectedName)).First();
                Grade grade = new Grade();

                grade.Student = updatedStudent;
                grade.Studentid = updatedStudent.Id;
                grade.CoursecodeNavigation = course;
                grade.Coursecode = course.Coursecode;
                grade.Grade1 = "";

                grades.Add(grade);
                dx.Grades.Add(grade);
                dx.SaveChanges();

                attendee = courses.Where(a => a.Coursename.Equals(courseName)).Join(grades, cr => cr.Coursecode, gr => gr.Coursecode, (cr, gr) => new { gr.Student.Studentname, cr.Coursename, gr.Grade1 }).Where(n => n.Studentname.Equals(selectedName));
                TestListView.DataContext = attendee.ToList();
            }
            else
            {
                TestListView.DataContext = attendee.ToList();
            }

        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Grade { get; set; }
    }
}
