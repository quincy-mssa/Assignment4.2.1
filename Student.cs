using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4._2._1
{
    public class Student
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double GPA { get; set; }

        public Student(int studentId, string studentName, double gpa)
        {
            StudentId = studentId;
            StudentName = studentName;
            GPA = gpa;
        }
    }
}
