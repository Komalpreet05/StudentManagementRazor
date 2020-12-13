using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupA_A2.Models
{
    public class Student
    {
        public string Image { get; set; }

        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter student's first name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter student's last name")]
        public String LastName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Province { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Enter Valid Postal Code")]
        [RegularExpression(@"^[a-zA-Z]{1}[0-9]{1}[a-zA-Z]{1}[- ]{0,1}[0-9]{1}[a-zA-Z]{1}[0-9]{1}", ErrorMessage = "Postal Code is not in the correct format")]
        [StringLength(7)]
        public String PostalCode { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter student's phone number")]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "Please enter a valid phone number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter student's email address")]
        [EmailAddress(ErrorMessage = "E-mail address format is not correct")]
        public String EmailAddress { get; set; }


        public Program allPrograms { get; set; }

        public Student()
        {
            StudentID = 0;
        }

        public Student(string img, int studentID, string firstName, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string emailAddress, Program programs)
        {
            Image = img;
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            Province = province;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            this.allPrograms = programs;
        }
    }

    public class Program
    {
        public int ProgramID { get; set; }

        [Display(Name = "Program Name")]
        public String ProgramName { get; set; }
        public String ProgramCode { get; set; }
        public String Desc { get; set; }
        public List<Course> Courses { get; set; }

        public Program()
        {
            ProgramID = 0;
        }

        public Program(int programID, string programName, string programCode, string desc, List<Course> courses)
        {
            ProgramID = programID;
            ProgramName = programName;
            ProgramCode = programCode;
            Desc = desc;
            Courses = courses;
        }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public String CourseName { get; set; }
        public String CourseCode { get; set; }
        public String Desc { get; set; }

        public int ProgramID { get; set; }
        public Course()
        {
            CourseID = 0;

        }

        public Course(int courseId,String courseName, String courseCode, String description, int programId)
        {
            CourseID = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            Desc = description;
            ProgramID = programId;
        }
    }
}