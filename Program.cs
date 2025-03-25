using System;
using StudentNamespace;
using StudentManagerNamespace;

class Program
{
    static void Main(string[] args)
    {
        int flag = 1;
        StudentManager studentManager = new StudentManager();
        while (flag != 0)
        {
            Console.WriteLine("1：添加学生；2：更新学生信息；3：删除学生；4：打印所有学生；其他数字：退出");
            if (!int.TryParse(Console.ReadLine(), out flag))
            {
                Console.WriteLine("ERROR INPUT,EXIT");
                flag = 0;
            }

            switch (flag)
            {
                case 1:
                    Student addstudent = new Student();

                    Console.WriteLine("Please input new student ID:");
                    addstudent.ID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please input new  Name:");
                    addstudent.Name = Console.ReadLine();
                    Console.WriteLine("Please input new student Age:");
                    addstudent.Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please input new student Grade:");
                    addstudent.Grade = Console.ReadLine();

                    studentManager.AddStudent(addstudent);
                    break;
                case 2:
                    int updatestudentID;
                    Console.WriteLine("Please input update student ID:");
                    updatestudentID = int.Parse(Console.ReadLine());
                    Student curruntstudent = studentManager.Students.Find(s => s.ID == updatestudentID);
                    int flagforupdate = 1;

                    while (flagforupdate != 0)
                    {
                        Console.WriteLine("1：更新学生姓名；2：更新学生年龄；3：更新学生成绩；其他数字：退出");
                        if (!int.TryParse(Console.ReadLine(), out flagforupdate))
                        {
                            Console.WriteLine("ERROR INPUT,EXIT");
                            flagforupdate = 0;
                        }
                        switch (flagforupdate)
                        {
                            case 1:
                                Console.WriteLine("Please input update student Name:");
                                curruntstudent.Name = Console.ReadLine();
                                studentManager.UpdateStudent(updatestudentID, curruntstudent);
                                break;
                            case 2:
                                Console.WriteLine("Please input update student Age:");
                                curruntstudent.Age = int.Parse(Console.ReadLine());
                                studentManager.UpdateStudent(updatestudentID, curruntstudent);
                                break;
                            case 3:
                                Console.WriteLine("Please input update student Grade:");
                                curruntstudent.Grade = Console.ReadLine();
                                studentManager.UpdateStudent(updatestudentID, curruntstudent);
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
                    flag = 0;
                    break;
            }
        }
    }
}