using StudentNamespace;
using System;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagerNamespace
{
    public class StudentManager {
        public List<Student> Students = new List<Student>();
        public StudentManager() { }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            Student student = Students.Find(s => s.ID == id);
            if (student != null)
            {
                Students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void UpdateStudent(int id, Student newStudent)
        {
            Student student = Students.Find(s => s.ID == id);
            if (student != null)
            {
                student.Name = newStudent.Name;
                student.Age = newStudent.Age;
                student.Grade = newStudent.Grade;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void PrintAllStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

    }
}