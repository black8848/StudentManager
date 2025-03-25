using StudentNamespace;
using System;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagerNamespace
{
    public class StudentManager {
        private List<Student> Students = new List<Student>();
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
                Console.WriteLine($"Student {id} removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void UpdateStudent(int id, string name, int age, string grade)
        {
            Student student = Students.Find(s => s.ID == id);
            if (student != null)
            {
                student.Name = name;
                student.Age = age;
                student.Grade = grade;
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public void PrintAllStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }
            foreach (Student student in Students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

    }
}