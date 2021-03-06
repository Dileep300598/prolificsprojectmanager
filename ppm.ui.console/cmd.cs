using System;
using Domain;
using ppm.domain;
using ppm.model;
namespace ppm.ui.cli
{
    public class Cmd
    {
        public void startprogram()

        {

            Console.WriteLine("following operation");
            Console.WriteLine("1.Project Module");
            Console.WriteLine("2.Employee Module");
            Console.WriteLine("3.Role Module");
            Console.WriteLine("4.Save");
            Console.WriteLine("5.Quit");
            while (true)
            {
                try
                {
                    Console.WriteLine("choose the given option: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            ProjectModule();
                            break;
                        case 2:
                            EmployeeModule();
                            break;
                        case 3:
                            RoleModule();
                            break;
                        case 4:
                            Save d1 = new Save();
                            d1.save();
                            break;

                        default:
                            Console.WriteLine("Option is not in the list!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("oops! Error Occured! Try Again");
                    startprogram();

                }

            }
        }

        public void ProjectModule()
        {
            Console.WriteLine("Choose the option you want to select:");
            Console.WriteLine("Press 1: Add Project");
            Console.WriteLine("Press 2: List Project");
            Console.WriteLine("Press 3: List Project by Id");
            Console.WriteLine("Press 4: Delete Project");
            Console.WriteLine("Press 5: Add employee to Project");
            Console.WriteLine("Press 6: Go to main Menu");
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose Your Option from 1 to 6: ");
                   int j = Convert.ToInt32(Console.ReadLine());
                    Projectmanager v2 = new Projectmanager();
                    switch (j)
                    {
                        case 1:
                            v2.AddProject();
                            break;
                        case 2:
                            Console.WriteLine("Project Details: ");
                            var ResPro = v2.ListAll();
                            if (ResPro.isSucess)
                            {
                                foreach (Project result1 in ResPro.results)
                                {
                                    Console.WriteLine("Project id: " + result1.id + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.StartDate + "\nEnd Date:" + result1.EndDate + "\nBudget :" + result1.Budget);
                                }

                            }
                            else
                            {
                                Console.WriteLine(ResPro.status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter project id which u want to display");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Project Details:");
                            var ResPro1 = v2.ListAll();
                            if (ResPro1.isSucess)
                            {
                                foreach (Project result1 in ResPro1.results)
                                {
                                    if (result1.id == n1)
                                    {
                                        Console.WriteLine("Project id: " + result1.id + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.StartDate + "\nEnd Date:" + result1.EndDate + "\nBudget :" + result1.Budget);

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(ResPro1.status);
                            }
                            break;
                        case 4:
                            v2.DeleteProjectById();
                            break;
                        case 5:
                            v2.AddEmployeeToProject();
                            break;
                        case 6:
                            startprogram();
                            break;
                        default:
                            Console.WriteLine("OOPS!Error occured! Try Again");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("OOPS!Error Ocurred! try again");
                    startprogram();
                }
            }
        }

        public void EmployeeModule()
        {
            Console.WriteLine("Choose the Option you want to select:");
            Console.WriteLine("Press 1: Add Employee");
            Console.WriteLine("Press 2: List All Employee");
            Console.WriteLine("Press 3: List Employee by Id");
            Console.WriteLine("Press 4: Delete Employee");
            Console.WriteLine("Press 5: Return to main Menu");
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose Your option from 1 to 5: ");
                   int j = Convert.ToInt32(Console.ReadLine());
                    Employeemanager e1 = new Employeemanager();
                    switch (j)
                    {
                        case 1:
                            e1.AddEmployee();
                            break;
                        case 2:
                            Console.WriteLine("Employee Details: ");
                            var ResEmp = e1.ListAll();
                            if (ResEmp.isSucess)
                            {
                                foreach (Employee e2 in ResEmp.results)
                                {
                                    Console.WriteLine("Employee id: " + e2.Id + "\nEmployee_Name Name: " + e2.Fullname + "\nContact: " + e2.Contact + "\nRoleName :" + e2.RoleName);

                                }

                            }
                            else
                            {
                                Console.WriteLine(ResEmp.status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Employee id which u want to display");
                            int E1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Employee Details: ");
                            var ResEmp1 = e1.ListAll();
                            if (ResEmp1.isSucess)
                            {
                                foreach (Employee e2 in ResEmp1.results)
                                {
                                    if (e2.Id == E1)
                                    {
                                        Console.WriteLine("Employee id: " + e2.Id + "\nEmployee_Name Name: " + e2.Fullname + "\nContact: " + e2.Contact + "\nRoleName :" + e2.RoleName);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(ResEmp1.status);
                            }
                            break;
                        case 4:
                            e1.DeleteEmployeeById();
                            break;
                        case 5:
                            startprogram();
                            break;
                        default:
                            Console.WriteLine("OOPS ! Error Occoured! Try Again");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("OOPS Error occured! try Again");
                }
            }
        }
        public void RoleModule()
        {
            Console.WriteLine("Choose the Option you want to select:");
            Console.WriteLine("Press 1: Add Role");
            Console.WriteLine("Press 2: List All Role");
            Console.WriteLine("Press 3: List Role by Id");
            Console.WriteLine("Press 4: Delete Role");
            Console.WriteLine("Press 5: GO to main Menu");
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose your options: ");
                   int j = Convert.ToInt32(Console.ReadLine());
                    Rolemanager m3 = new Rolemanager();
                    switch (j)
                    {
                        case 1:
                            m3.AddRole();
                            break;
                        case 2:
                            Console.WriteLine("Role Details: ");
                            var Resrole = m3.ListAll();
                            if (Resrole.isSucess)
                            {
                                foreach (Role e2 in Resrole.results)
                                {
                                    Console.WriteLine("Role Id: " + e2.RoleId + "\nRole Name: " + e2.RoleName);

                                }

                            }
                            else
                            {
                                Console.WriteLine(Resrole.status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter project id which u want to display");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Project Details:");
                            var Resrole1 = m3.ListAll();
                            if (Resrole1.isSucess)
                            {
                                foreach (Role e2 in Resrole1.results)
                                {
                                    if (e2.RoleId == n1)
                                    {
                                        Console.WriteLine("Role Id: " + e2.RoleId + "\nRole Name: " + e2.RoleName);

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(Resrole1.status);
                            }
                            break;
                        case 4:
                            m3.DeleteRoleById();
                            break;
                        case 5:
                            startprogram();
                            break;
                        default:
                            Console.WriteLine("optipon is in the list!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("oops! Error occured! Try Again");
                }

            }
        }
    }
}