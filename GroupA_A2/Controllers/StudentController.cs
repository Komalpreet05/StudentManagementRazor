using GroupA_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupA_A2.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> allStudentsData = new List<Student> {
            new Student("gagandeep.jpg",2305, "Gagan", "Singh", "41 Eastway Street", "Brampton", "Ontario", "L6S6L9", "6475812305", "gagan2305@gmail.com", new Program(1, "Computer Programming", "CPCM20", "Web development and programming", ComputerProgrammingCourses())),
            new Student("jason.jpg",2309, "Jason", "Holder", "24 Bayhampton Drive", "Mississauga", "Ontario", "K9N6L4", "9592642545", "jason29@gmail.com", new Program(2, "Business Management", "BNIM20", "Development in business", BusinessManagementCourses())),
            new Student("shikhar.jpg",2307, "Shikhar", "Dhawan", "130 Lake Louise Drive", "Brampton", "Ontario", "N7H5O9", "4233243232", "shikhar001@yahoo.com", new Program(3, "Project Management", "PMIL20", "Managing real time projects", ProjectManagementCourses())),
            new Student("sam.jpg",2345, "Sam", "Curran", "29 fake Drive", "Brampton", "Ontario", "N9K8U6", "9878656232", "curran01@outlook.com", new Program(3, "Project Management", "PMIL20", "Managing real time projects", ProjectManagementCourses())),
            new Student("steve.jpg",2331, "Steve", "Smith", "24 drew hill", "Mississauga", "Ontario", "D4R5T4", "9877666232", "steve31@gmail.com", new Program(1, "Computer Programming", "CPCM20", "Web development and programming", ComputerProgrammingCourses())),
            new Student("shubman.jpg",2376, "Shubman", "Gill", "45 Kruby Rd", "Toronto", "Ontario", "U7O9K7", "8769056456", "shubman12@gmail.com", new Program(2, "Business Management", "BNIM20", "Development in business", BusinessManagementCourses()))
        };
        
        public static List<Course> ComputerProgrammingCourses()
        {
            List<Course> ComputerProgramming = new List<Course>();
            ComputerProgramming.Add(new Course(3354, "Web Applications", "CSD3354", "Working with mvc and database", 1));
            ComputerProgramming.Add(new Course(2343, "Database Programming", "CSD2343", "Working on different queries to fetch particular data", 1));
            ComputerProgramming.Add(new Course(2154, "Enterprise Technologies", "CSD2154", "Python, nodejs and mongodb", 1));
            ComputerProgramming.Add(new Course(5434, "General Mathematics", "CSD5434", "Indexes, proportions and statistics", 1));
            ComputerProgramming.Add(new Course(4333, "Web Technology", "CSD4333", "Html, CSS and JavaScript", 1));
            ComputerProgramming.Add(new Course(2334, "Programming java", "CSD2334", "Objects, classes and constructor", 1));
            return ComputerProgramming;
        }

        public static List<Course> BusinessManagementCourses()
        {
            List<Course> BusinessManagement = new List<Course>();
            BusinessManagement.Add(new Course(2276, "Introduction to Social Media", "BIM2276", "Introducing social strategies", 2));
            BusinessManagement.Add(new Course(3322, "Business Administration ", "BIM3322", "Handling new businesss", 2));
            BusinessManagement.Add(new Course(2443, "Business Accounting", "BIM2443", "Managing finances", 2));
            BusinessManagement.Add(new Course(4432, "Communication Skills", "BIM4432", "Learning professional communication skills", 2));
            BusinessManagement.Add(new Course(5436, "Human Interaction", "BIM5436", "Presentations among public", 2));
            BusinessManagement.Add(new Course(3444, "Business Development", "BIM3444", "Growth of business", 2));
            return BusinessManagement;
        }

        public static List<Course> ProjectManagementCourses()
        {
            List<Course> ProjectManagement = new List<Course>();
            ProjectManagement.Add(new Course(4354, "Time Management", "PIM4354", "Learning how to manage time", 3));
            ProjectManagement.Add(new Course(4353, "Communication Management", "PIM4353", "Developing professional communication skills", 3));
            ProjectManagement.Add(new Course(3355, "Human Resource Management", "PIM3355", "Managing resources relted to project", 3));
            ProjectManagement.Add(new Course(4224, "Scope Management", "PIM4224", "Developing scope management skills", 3));
            ProjectManagement.Add(new Course(3456, "Quality Management", "PIM3456", "Quality of deliverables", 3));
            ProjectManagement.Add(new Course(2252, "Risk Management", "PIM2252", "Handling upcoming risks related to project", 3));

            return ProjectManagement;
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllStudents()
        {
            return View(allStudentsData.OrderBy(k=>k.StudentID).ToList());
        }

        public ActionResult AllStudentsTable()
        {
            return View(allStudentsData.OrderBy(k => k.StudentID).ToList());
        }

       

        public ActionResult EditStudent(int id)
        {
            var SelectedStudent = allStudentsData.Where(s => s.StudentID == id).FirstOrDefault();
            return View(SelectedStudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student s1)
        {
            var student = allStudentsData.Where(s => s.StudentID == s1.StudentID).FirstOrDefault();
            allStudentsData.Remove(student);
            allStudentsData.Add(s1);
            //return RedirectToAction("AllStudents");

            if (ModelState.IsValid)
            {
                return RedirectToAction("AllStudents", "Student");
            }
            else
            {
                return View();
            }
        }

        
        public ActionResult ViewStudent(int id)
        {
            var SelectedStudent = allStudentsData.Where(s => s.StudentID == id).FirstOrDefault();
            return View(SelectedStudent);
        }

        
    }
}