using StudentNamespace;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace StudentManagerNamespace
{
    public class StudentManager
    {
        private const string FilePath = "students.json";
        private List<Student> Students = new List<Student>();
        public delegate void StudentAddedHandler(Student student); //定义委托
        public event StudentAddedHandler StudentAdded;  //定义事件

        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("Invalid student index.");
                return Students[index];
            }
            set
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("Invalid student index.");
                Students[index] = value;
            }
        }

        public StudentManager()
        {
            Students = LoadStudents();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            SaveStudents();
            StudentAdded?.Invoke(student);  //触发事件（通知所有订阅者）
        }

        public void RemoveStudent(int id)
        {
            Student student = Students.Find(s => s.ID == id);
            if (student != null)
            {
                Students.Remove(student);
                SaveStudents();
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
                SaveStudents();
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

        private void SaveStudents()
        {
            string json = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        private List<Student> LoadStudents()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
            return new List<Student>();
        }

    }
}