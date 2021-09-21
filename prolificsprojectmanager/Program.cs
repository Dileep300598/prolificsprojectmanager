using System;
using System.Collections.Generic;
using ppm.model;
using ppm.ui.cli;

namespace ppm 
{
    class program
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            cmd co = new cmd();
            co.startprogram();

        }
    }
}


//public static List<Project> AddEmpToProject()
        //{

        //    Project project = new()
        //    {
        //        EmpName = new List<string>()
        //    };
        //    Console.WriteLine("Provide the project Id: ");
        //    int Id = Convert.ToInt32(Console.ReadLine());//1
        //    //Console.Write("How many Employees you want to add in the project: ");
        //    //int i = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Enter the name of the employee: ");
        //    string empname = Console.ReadLine();
        //    List<string> employeeList = new();
        //    employeeList.Add(empname);
        //    employeeList.Add(Convert.ToString(Id));
        //    project.EmpName = employeeList;
        //    //project.EmpName.Add(empname);
        //    /*var linq = (from Project in pro
        //                where project.ProjectId == Id
        //                select new
        //                {
        //                    Project.EmpName.Add(empname)
        //                }).ToList();*/
        //    if (pro.Exists(pr => pr.ProjectId == Id))
        //    {
        //        //pro.Where(p => p.ProjectId==Id).Append(project);
        //        //pro.Where(p => p.ProjectId == Id).ToList().Add(project);
        //        pro.Add(project);
        //        Console.WriteLine("Employees added to the project");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Project Id doesn't Exist!");
        //    }
        //    return pro;
        //}
    
