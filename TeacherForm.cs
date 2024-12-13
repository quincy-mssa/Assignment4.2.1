using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment4._2._1
{
    public partial class TeacherForm : Form
    {
        private List<Student> students = new List<Student>();

        public TeacherForm()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = int.Parse(txtStudentId.Text);
                string studentName = txtStudentName.Text;
                double gpa = double.Parse(txtGPA.Text);

                Student student = new Student(studentId, studentName, gpa);
                students.Add(student);

                MessageBox.Show("Student Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                UpdateStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveHighestGPA_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student highestGPAStudent = students.OrderByDescending(s => s.GPA).FirstOrDefault();

            if (highestGPAStudent != null)
            {
                string filePath = "HighestGPAStudent.txt";
                File.WriteAllText(filePath, $"Student ID: {highestGPAStudent.StudentId}\nName: {highestGPAStudent.StudentName}\nGPA: {highestGPAStudent.GPA}");
                MessageBox.Show("Student with highest GPA saved to file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int studentIdToDelete = int.Parse(txtStudentId.Text);

                Student studentToRemove = students.FirstOrDefault(s => s.StudentId == studentIdToDelete);

                if (studentToRemove != null)
                {
                    students.Remove(studentToRemove);
                    MessageBox.Show("Student Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    UpdateStudentList();
                }
                else
                {
                    MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtStudentId.Text = "";
            txtStudentName.Text = "";
            txtGPA.Text = "";
        }

        private void UpdateStudentList()
        {
            lstStudents.Items.Clear();
            foreach (var student in students)
            {
                lstStudents.Items.Add($"ID: {student.StudentId}, Name: {student.StudentName}, GPA: {student.GPA}");
            }
        }
    }
}