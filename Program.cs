using System;
using StudentNamespace;
using StudentManagerNamespace;

class Program { 
    static void Main(string[] args)
    {
        StudentManager studentMangager = new StudentManager();
        Student student1 = new Student(1, "John Doe", 20, "A");
        Student student2 = new Student(2, "Jane Smith", 22, "B");

        studentMangager.AddStudent(student1);
        studentMangager.AddStudent(student2);
        studentMangager.PrintAllStudents();

        Console.WriteLine("\nUpdating student\n");

        student1.Name = "John Doe Updated";
        studentMangager.UpdateStudent(1,student1);
        studentMangager.RemoveStudent(2);
        studentMangager.PrintAllStudents();
    }
}