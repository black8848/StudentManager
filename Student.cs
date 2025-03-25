using System;
using System.Security.Cryptography.X509Certificates;

namespace StudentNamespace
{
	public class Student
	{
		public int ID { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Grade { set; get; }

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