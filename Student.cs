using System;
using System.Security.Cryptography.X509Certificates;

namespace StudentNamespace
{
	public class Student
	{
        private int _age;
        private string _name;
        private string _grade;

        public int ID { set; get; } 

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("姓名不能为空");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentOutOfRangeException("年龄必须在 0 到 150 之间");
                _age = value;
            }
        }

        public string Grade
        {
            get => _grade;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("成绩不能为空");
                _grade = value;
            }
        }

        public Student() { }

        public Student(int id, string name, int age, string grade)
        {
            ID = id;
            Name = name;
            Age = age;
            Grade = grade;
        }

    }
}