using System;
using Domain;
using ppm.domain;
using ppm.model;

namespace ppm.ui.cli
{
    public class cmd
    {
        public void startprogram()
        {
            Projectmanager m1 = new Projectmanager();
            Console.WriteLine("following operation");
            Console.WriteLine("1.Add project");
            Console.WriteLine("2.View project");
            Console.WriteLine("3.Add Employee");
            Console.WriteLine("4.View Employee");
            Console.WriteLine("5.Add Role");
            Console.WriteLine("6.View Role");
            Console.WriteLine("7.Add Employee To Project");
            Console.WriteLine("8.Delete Employee From Project");
            Console.WriteLine("9.View project detail");
            Console.WriteLine("10.Exit");

            bool i = true;
            while (i)
            {
                Console.Write("select an option: ");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {

                    case 1:
                        AddProject();

                        break;
                    case 2:
                        Projectmanager pro = new Projectmanager();
                        var pres = pro.GetProjectInfo();

                        int c = 0;
                        if (pres.isSucess)
                        {
                            foreach (Project item in pres.results)
                            {
                                Console.WriteLine("Project: " + c);
                                Console.WriteLine("projectId:" + item.id);
                                Console.WriteLine("projectName:" + item.Name);
                                Console.WriteLine("projectStartDate:" + item.StartDate);
                                Console.WriteLine("projectEndDate:" + item.EndDate);
                                Console.WriteLine("projectBudget:" + item.Budget);
                                c++;
                            }
                        }
                        else
                        {
                            Console.WriteLine(pres.status);
                        }
                        break;
                    case 3:
                        AddEmployee();
                        break;
                    case 4:
                        Employeemanager employeemanager = new Employeemanager();
                        var employee = employeemanager.GetEmployeeInfo();
                        int C = 0;
                        if (employee.isSucess)
                        {
                            foreach (Employee emp in employee.results)
                            {

                                Console.WriteLine("Employee no: " + i);
                                Console.WriteLine("Employee id:" + emp.Id);
                                Console.WriteLine("Employee Name:" + emp.Fullname);
                                Console.WriteLine("Employee Contact:" + emp.Contact);
                                Console.WriteLine("Employee RoleName:" + emp.RoleName);
                                C++;
                            }
                        }
                        else
                        {
                            Console.WriteLine(employee.status);
                        }
                        break;

                    case 5:
                        AddRole();
                        break;
                    case 6:
                        Rolemanager rolemgr = new Rolemanager();
                        var roleInfoResult = rolemgr.GetRoleInfo();
                        int count = 0;
                        if (roleInfoResult.isSucess)
                        {
                            foreach (Role item in roleInfoResult.results)
                            {
                                Console.WriteLine("Role no: " + count);
                                Console.WriteLine("Role id:" + item.RoleId);
                                Console.WriteLine("Role Name:" + item.RoleName);

                                count++;
                            }
                        }
                        else
                        {
                            Console.WriteLine(roleInfoResult.status);
                        }
                        break;
                    case 7:

                        Console.WriteLine("Add Employee To Project");

                        AddEmployeetoProject();

                        break;
                    case 8:
                        Console.WriteLine("Remove Employee From Project");
                        RemoveEmployeefromProject();
                        break;
                    case 9:
                        Console.WriteLine("Project Details with Employee Assigned");
                        var resultPro = m1.GetProjectInfo();
                        if (resultPro.isSucess)
                        {
                            foreach (Project result in resultPro.results)
                            {
                                Console.WriteLine("Project ID: " + result.id + "\nProject Name: " + result.Name + "\nStarting Date: " + result.StartDate + "\nBudget: " + result.Budget);
                                Console.WriteLine("Employee Assigned: ");
                                if (result.Emplist != null)
                                {
                                    foreach (Employee e in result.Emplist)
                                    {
                                        Console.WriteLine("Employee Id: " + e.Id + " " + "Employee FullName: " + e.Fullname);
                                    }
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine(resultPro.status);
                        }
                        break;

                    case 10:
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }



        }

        private bool AddProject()
        {
            Project project = new Project();
            Console.WriteLine("Enter Project Id");
            project.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter project name");
            project.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter project startdate");
            project.StartDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter project Enddate");
            project.EndDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter project Budget");
            project.Budget = Convert.ToDecimal(Console.ReadLine());

            Projectmanager p = new Projectmanager();
            var result = p.AddProject(project);

            if (!result.isSucess)
            {
                Console.WriteLine("project already exists");
                Console.WriteLine(result.status);
            }
            else
            {

                Console.WriteLine(result.status);

            }
            return result.isSucess;
        }
        private bool AddEmployee()
        {

            Employee emp = new Employee();

            Console.WriteLine("Enter Employee Id");
            emp.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Fullname");
            emp.Fullname = Console.ReadLine();
            Console.WriteLine("Enter Employee Contact");
            emp.Contact = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Employee RoleName");
            emp.RoleName = Console.ReadLine();
            Employeemanager e = new Employeemanager();
            var result = e.AddEmployee(emp);
            if (!result.isSucess)
            {
                Console.WriteLine("Employee already exists");
            }
            else
            {
                Console.WriteLine(result.status);
            }
            return result.isSucess;
        }

        private bool AddRole()
        {
            Role rol = new Role();

            Console.WriteLine("Enter Role Id");
            rol.RoleId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RoleName");
            rol.RoleName = Console.ReadLine();
            Rolemanager r = new Rolemanager();
            var result = r.AddRole(rol);
            if (!result.isSucess)
            {
                Console.WriteLine("Role already exists");
            }
            else
            {

            }
            return result.isSucess;
        }
        private static bool AddEmployeetoProject()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter project id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name of the Employee :");
            string empname = Console.ReadLine();
            Employeemanager employeemanager = new Employeemanager();
            var valid = employeemanager.IsValidEmp(empname);
            if (!valid.isSucess)
            {
                Projectmanager projectmanager = new Projectmanager();
                var result = projectmanager.AddEmpToProject(emp, id);
                if (!result.isSucess)
                {
                    Console.WriteLine("Employee failed to add into project");
                    Console.WriteLine(result.status);
                }
                else
                {
                    Console.WriteLine(result.status);
                }
                return result.isSucess;
            }
            else
            {
                Console.WriteLine(valid.status);
            }
            return valid.isSucess;

        }



        private static bool RemoveEmployeefromProject()
        {
            Projectmanager projectManager = new Projectmanager();
            Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List:");
            Console.WriteLine("Project ID: Project Name");
            var resPro = projectManager.GetProjectInfo();
            if (resPro.isSucess)
            {
                foreach (Project res in resPro.results)
                {
                    Console.WriteLine(res.id + " : " + res.Name);
                }
            }
            else
            {
                Console.WriteLine(resPro.status);
            }

            Console.Write("Enter The project Id From Employee Should Be removed: ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Choose The Employee Id in Selected Project Id: {projectId} From the Following List: Employee ID : Employee Name");
            var empList = projectManager.GetProjectByID(projectId);
            foreach (Employee res in empList.Emplist)
            {
                Console.WriteLine(res.Id + " : " + res.Fullname);
            }
            Console.Write("Enter the ID of the Employee to remove: ");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            var result = projectManager.DeleteEmpFromProject(projectId, employee);
            if (!result.isSucess)
            {
                Console.WriteLine(result.status);
            }
            else
            {
                Console.WriteLine(result.status);
            }
            return result.isSucess;
        }
    }
}

