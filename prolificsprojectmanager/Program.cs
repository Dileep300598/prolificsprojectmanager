using System;

namespace prolificsprojectmanager
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Select Number For Operation");
            Console.WriteLine("1.Add project");
            Console.WriteLine("2.View project");
            Console.WriteLine("3.Add Employee");
            Console.WriteLine("4.View Employee");
            Console.WriteLine("5.Add Role");
            Console.WriteLine("6.View Role");
            Console.WriteLine("7.Exit");

            string[] Project = new string[4];
            string[] Employee = new string[5];
            string[] Role = new string[2];
            bool j = true;
            while (j)
            {
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {


                    case 1:
                        string name;
                        string Start_Date;
                        string End_Date;
                        string Budget;
                        Console.WriteLine("Enter Project Name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Project Start Date");
                        Start_Date = Console.ReadLine();
                        Console.WriteLine("Enter Project End Date");
                        End_Date = Console.ReadLine();
                        Console.WriteLine("Enter Project Budget");
                        Budget = Console.ReadLine();

                        Project[0] = "Name" + name;
                        Project[1] = "Start_Date" + Start_Date;
                        Project[2] = "End_Date" + End_Date;
                        Project[3] = "Budget" + Budget;
                        break;
                    case 2:
                        foreach (var item in Project)
                        {
                            Console.WriteLine("");
                        }
                        break;
                    case 3:
                        string Id;
                        string Fullname;
                        string Contact;
                        string Roleid;
                        Console.WriteLine("Enter Employee Id");
                        Id = Console.ReadLine();
                        Console.WriteLine("Enter Employee Fullname");
                        Fullname = Console.ReadLine();
                        Console.WriteLine("Enter Employee Contact");
                        Contact = Console.ReadLine();
                        Console.WriteLine("Enter Employee Roleid");
                        Roleid = Console.ReadLine();
                        break;
                    case 4:
                        foreach (var item in Employee)
                        {
                            Console.WriteLine("item");
                        }
                        break;
                    case 5:
                        string RoleId;
                        string Rolename;
                        Console.WriteLine("Enter Role Id");
                        RoleId = Console.ReadLine();
                        Console.WriteLine("Enter RoleName");
                        Rolename = Console.ReadLine();
                        Role[0] = "Roleid" + RoleId;
                        Role[1] = "Rolename" + Rolename;
                        break;
                    case 6:
                        foreach (var item in Role)
                        {
                            Console.WriteLine("item");
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }













        }
    }
}
