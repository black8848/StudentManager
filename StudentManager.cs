using StudentNamespace;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Newtonsoft.Json;

namespace StudentManagerNamespace
{
    public class StudentManager
    {
        private const string FilePath = "students.json";
        private List<Student> Students = new List<Student>();
        public delegate void StudentChangedHandler();  //定义学生改变委托
        public delegate void StudentAddedHandler(Student student); //定义学生添加委托
        public event StudentChangedHandler StudentChanged; //事件在学生数据变化时触发
        public event StudentAddedHandler StudentAdded;  //事件在添加学生时触发


        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("无效的学生索引");
                return Students[index];
            }
            set
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("无效的学生索引");
                Students[index] = value;
            }
        }

        public StudentManager() { }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            StudentAdded?.Invoke(student);  //触发事件（通知所有订阅者）
            StudentChanged?.Invoke(); //触发事件（通知所有订阅者）
        }

        public void RemoveStudent(int id)
        {
            Student student = Students.Find(s => s.ID == id);
            if (student != null)
            {
                Students.Remove(student);
                Console.WriteLine($"Student {id} 已被移除");
                StudentChanged?.Invoke();//触发事件（通知所有订阅者）
            }
            else
            {
                Console.WriteLine("学生不存在");
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
                Console.WriteLine("学生信息更新成功");
                StudentChanged?.Invoke();//触发事件（通知所有订阅者）
            }
            else
            {
                Console.WriteLine("学生不存在");
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
                Console.WriteLine("学生不存在");
                return;
            }
            foreach (Student student in Students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(Students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, json);
            Console.WriteLine("(事件订阅)数据已自动保存到 JSON 文件！");
        }

        public void LoadFromJson()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                Students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }
        }

    }
}