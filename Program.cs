using System;
using StudentNamespace;
using StudentManagerNamespace;

class Program
{
    static void Main(string[] args)
    {
        StudentManager studentManager = new StudentManager();
        studentManager.LoadFromJson(); //自动加载数据

        studentManager.StudentAdded += OnStudentAdded;  // 订阅 StudentAdded 事件

        studentManager.StudentChanged += studentManager.SaveToJson;

        while (true)
        {
            Console.WriteLine("1：添加学生;2：更新学生信息；3：删除学生；4：打印所有学生；0：退出");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 4)
            {
                Console.WriteLine("无效的输入，请输入数字0-4");
                continue;
            }

            if (choice == 0) break;

            switch (choice)
            {
                case 1:
                    Student newStudent = new Student();

                    Console.WriteLine("输入新学生的ID:");
                    if (!int.TryParse(Console.ReadLine(), out int newStudentID)) { Console.WriteLine("Invalid ID!"); continue; }
                    newStudent.ID = newStudentID;
                    Console.WriteLine("输入新学生的姓名:");
                    string? nameinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(nameinput)) { Console.WriteLine("Invalid Name!"); continue; }
                    newStudent.Name = nameinput;
                    Console.WriteLine("输入新学生的年龄:");
                    if (!int.TryParse(Console.ReadLine(), out int newStudentAge)) { Console.WriteLine("Invalid Age!"); continue; }
                    newStudent.Age = newStudentAge;
                    Console.WriteLine("输入新学生的成绩:");
                    string? gradeinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(gradeinput)) { Console.WriteLine("Invalid Grade!"); continue; }
                    newStudent.Grade = gradeinput;

                    studentManager.AddStudent(newStudent);
                    break;
                case 2:
                    Console.WriteLine("请输入学生ID:");
                    if (!int.TryParse(Console.ReadLine(), out int updateId)) { Console.WriteLine("无效的ID"); continue; }
                    Student student = studentManager.GetStudents().Find(s => s.ID == updateId);
                    if (student == null) { Console.WriteLine("没有找到学生"); continue; }
                    int flagforupdate = 1;

                    while (flagforupdate != 0)
                    {
                        Console.WriteLine("1：更新学生姓名；2：更新学生年龄；3：更新学生成绩；0：退出");
                        if (!int.TryParse(Console.ReadLine(), out flagforupdate) || flagforupdate < 0 || flagforupdate > 3)
                        {
                            Console.WriteLine("无效的输入，请输入数字0-3");
                            continue;
                        }
                        switch (flagforupdate)
                        {
                            case 1:
                                Console.WriteLine("输入修改后的学生姓名:");
                                student.Name = Console.ReadLine();
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            case 2:
                                Console.WriteLine("输入修改后的学生年龄:");
                                student.Age = int.Parse(Console.ReadLine());
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            case 3:
                                Console.WriteLine("输入修改后的学生成绩:");
                                student.Grade = Console.ReadLine();
                                studentManager.UpdateStudent(student.ID, student.Name, student.Age, student.Grade);
                                break;
                            default:
                                Console.WriteLine("更新系统已退出");
                                flagforupdate = 0;
                                break;
                        }
                    }
                    break;
                case 3:
                    int removestudentID;
                    Console.WriteLine("输入要移除的学生ID");
                    removestudentID = int.Parse(Console.ReadLine());
                    studentManager.RemoveStudent(removestudentID);
                    break;
                case 4:
                    studentManager.PrintAllStudents();
                    break;
                default:
                    Console.WriteLine("系统已退出");
                    choice = 0;
                    break;
            }
        }
    }

    //StudentAdded 事件只是打印了一条消息
    //但事件订阅真正的价值在于它能让外部代码“监听”特定操作的发生，并做出响应。
    //在数据持久化的场景下，事件可以触发自动保存功能，让系统变得更智能。
    static void OnStudentAdded(Student student) // 事件回调方法
    {
        Console.WriteLine($"(事件订阅)新学生已添加: {student.Name}, ID: {student.ID}");
    }

}