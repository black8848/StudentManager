using System;
using StudentNamespace;
using StudentManagerNamespace;

class Program
{
    static void Main(string[] args)
    {
        StudentManager studentManager = new StudentManager();

        studentManager.StudentAdded += OnStudentAdded;  // 订阅 StudentAdded 事件

        while (true)
        {
            Console.WriteLine("1：添加学生;2：更新学生信息；3：删除学生；4：打印所有学生；0：退出");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                continue;
            }

            if (choice == 0) break;

            switch (choice)
            {
                case 1:
                    Student newStudent = new Student();

                    Console.WriteLine("Please input new student ID:");
                    if (!int.TryParse(Console.ReadLine(), out int newStudentID)) { Console.WriteLine("Invalid ID!"); continue; }
                    newStudent.ID = newStudentID;
                    Console.WriteLine("Please input new  Name:");
                    string? nameinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(nameinput)) { Console.WriteLine("Invalid Name!"); continue; }
                    newStudent.Name = nameinput;
                    Console.WriteLine("Please input new student Age:");
                    if (!int.TryParse(Console.ReadLine(), out int newStudentAge)) { Console.WriteLine("Invalid Age!"); continue; }
                    newStudent.Age = newStudentAge;
                    Console.WriteLine("Please input new student Grade:");
                    string? gradeinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(gradeinput)) { Console.WriteLine("Invalid Grade!"); continue; }
                    newStudent.Grade = gradeinput;

                    studentManager.AddStudent(newStudent);
                    break;
                case 2:
                    Console.WriteLine("Please input update student ID:");
                    if (!int.TryParse(Console.ReadLine(), out int updateId)) { Console.WriteLine("Invalid ID!"); continue; }
                    Student student = studentManager.GetStudents().Find(s => s.ID == updateId);
                    if (student == null) { Console.WriteLine("Student not found!"); continue; }
                    int flagforupdate = 1;

                    while (flagforupdate != 0)
                    {
                        Console.WriteLine("1：更新学生姓名；2：更新学生年龄；3：更新学生成绩；0：退出");
                        if (!int.TryParse(Console.ReadLine(), out flagforupdate) || flagforupdate < 0 || flagforupdate > 3)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 0 and 3.");
                            continue;
                        }
                        switch (flagforupdate)
                        {
                            case 1:
                                Console.WriteLine("Please input update student Name:");
                                student.Name = Console.ReadLine();
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            case 2:
                                Console.WriteLine("Please input update student Age:");
                                student.Age = int.Parse(Console.ReadLine());
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            case 3:
                                Console.WriteLine("Please input update student Grade:");
                                student.Grade = Console.ReadLine();
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            default:
                                Console.WriteLine("OVER,EXIT");
                                flagforupdate = 0;
                                break;
                        }
                    }
                    break;
                case 3:
                    int removestudentID;
                    Console.WriteLine("Please input remove student ID:");
                    removestudentID = int.Parse(Console.ReadLine());
                    studentManager.RemoveStudent(removestudentID);
                    break;
                case 4:
                    studentManager.PrintAllStudents();
                    break;
                default:
                    Console.WriteLine("OVER,EXIT");
                    choice = 0;
                    break;
            }
        }
    }

    static void OnStudentAdded(Student student) // 事件回调方法
    {
        Console.WriteLine($"新学生已添加: {student.Name}, ID: {student.ID}");
    }

}