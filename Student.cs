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
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 150.");
                _age = value;
            }
        }

        public string Grade
        {
            get => _grade;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Grade cannot be empty.");
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