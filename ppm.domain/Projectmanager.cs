using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ppm.model;
using ppm.model.common;

namespace ppm.domain
{
    public class Projectmanager : IOperation<Project>
    {
        private static List<Project> _projectList = new List<Project>();
        public void AddProject()
        {
            Project project = new Project();
            try
            {


                Console.WriteLine("Enter project Id");
                project.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter project Name");
                project.Name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter project StartDate");
                project.StartDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter project EndDate");
                project.EndDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter project Budget");
                project.Budget = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());

            }

            var resultEmp = Add(project);
            if (!resultEmp.isSucess)
            {
                Console.WriteLine("Project failed to Add");
                Console.WriteLine(resultEmp.status);
            }
            else
            {
                Console.WriteLine(resultEmp.status);
            }
        }

        public Result Add(Project pro)
        {
            Result result = new Result() { isSucess = true };
            try
            {
                if (_projectList.Count > 0)
                {
                    if (_projectList.Exists(pr => pr.id == pro.id))

                    {
                        result.isSucess = false;
                        result.status = "project already exists" + pro.Name;
                    }
                }
                else
                {
                    _projectList.Add(pro);
                    result.status = "Project added";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.isSucess = false;
            }
            return result;
        }
        //Add Result Add(T t)
        //ListAll DataResult<T> ListAll()
        //ListById
        //Delete Result Remove(int id)
        public DataResult<Project> ListAll()
        {
            DataResult<Project> data = new DataResult<Project> { isSucess = true };
            if (_projectList.Count > 0)
            {
                data.results = _projectList;
            }
            else
            {
                data.isSucess = false;
                data.status = "List is Empty!";
            }
            return data;
        }
        public Project GetProjectByID(int id)
        {
            Project project = new Project();
            project.Emplist = _projectList.Single(p => p.id == id).Emplist;
            return project;
        }
        public void DeleteProjectById()
        {
            Console.WriteLine("Choose Project From Below Project List: Project ID:Project Name");
            var resPro = ListAll();
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
            Console.Write("Enter The project Id wchich u want delete ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = Remove(id);
            if (!result.isSucess)

            {
                Console.WriteLine("project not deleted");
                Console.WriteLine(result.status);
            }
            else
            {
                Console.WriteLine(result.status);
            }
        }
        public void AddEmployeeToProject()
        {
            Employeemanager m1 = new Employeemanager();
            Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List: Project ID:Project Name");
            var resPro = ListAll();
            if (resPro.isSucess)
            {
                foreach (Project result in resPro.results)
                {
                    Console.WriteLine(result.id + " : " + result.Name);
                }
            }
            else
            {
                Console.WriteLine(resPro.status);
            }
            Console.Write("Provide the project Id: ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Below is the Employee ID and respective Name to choose:");
            var res = m1.ListAll();
            if (res.isSucess)
            {
                foreach (Employee e in res.results)
                {
                    Console.WriteLine(e.Id + " : " + e.Fullname);
                }
            }
            else
            {
                Console.WriteLine(res.status);
            }
            Console.Write("Enter the Id of the employee: ");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            var valid = m1.IsValidEmp(employee);
            if (valid.isSucess)
            {


                var obj = m1.GetEmployeetoRole(employee);
                employee.RoleName = obj.RoleName;
                employee.Fullname = obj.Fullname;
                var result = AddEmpToProject(employee, projectId);


                if (!result.isSucess)
                {
                    Console.WriteLine("Failed to Add Employee into project");
                    Console.WriteLine(result.status);
                }
                else
                {
                    Console.WriteLine(result.status);
                }
            }
            else
            {
                Console.WriteLine(valid.status);
            }
        }
        public Result isEmployeePresentinProject(int Id)
        {
            Result result = new Result() { isSucess = true };
            uint count = 0;
            if (_projectList.Count > 0)
            {
                foreach (Project Pro in _projectList)
                {
                    if (Pro.Emplist.Exists(p => p.Id == Id))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    result.status = "Employee is present!";
                }
                else
                {
                    result.isSucess = false;
                    result.status = "Employee is not present in any project!";
                }
            }
            else
            {
                result.isSucess = false;
            }
            return result;



        }
        public  Result Remove(int id)
        {
            Project project = new Project();
            Result result = new Result() { isSucess = true };
            try
            {
                if (_projectList.Exists(p => p.id == id))
                {
                    var itemToRemove = _projectList.Single(s => s.id == id);
                    _projectList.Remove(itemToRemove);
                    result.status = "Project is Deleted Successfully " + project.id;
                }
                else
                {
                    result.isSucess = false;
                    result.status = "Project Id is not in the List!" + id;
                }
            }
            catch (Exception e)
            {
                result.isSucess = false;
                result.status = "Exception Occured : " + e.ToString();
            }
            return result;
        }

        public Result AddEmpToProject(Employee empname, int id)
        {
            Result result = new Result() { isSucess = true };

            try
            {
                if (_projectList.Count > 0)
                {
                    if (_projectList.Exists(p => p.id == id))
                    {
                        if (_projectList.Single(p => p.id == id).Emplist == null)
                        {
                            _projectList.Single(p => p.id == id).Emplist = new List<Employee>();
                        }

                        if (_projectList.Single(p => p.id == id).Emplist.Exists(e => e.Id == id))
                        {
                            result.status = $"Employee Id : {id} already exists in this project: {id}";
                        }
                        else
                        {
                            _projectList.Single(p => p.id == id).Emplist.Add(empname);
                            result.status = "Employee is Added to project";

                        }

                    }
                    else
                    {
                        result.isSucess = false;
                        result.status = "Project Id not found!" + id;
                    }
                }
                else
                {
                    result.isSucess = false;
                    result.status = "Project list is Empty!";
                }

            }
            catch (Exception e)
            {
                result.isSucess = false;
                result.status = "Exception Occured : " + e.ToString();
            }
            return result;
        }

        public Result DeleteEmpFromProject(int id, Employee employee)
        {
            Result action = new Result() { isSucess = true };
            try
            {
                if (_projectList.Exists(p => p.id == id))
                {
                    if (_projectList.Single(s => s.id == id).Emplist.Exists(n => n.Id == employee.Id))
                    {
                        var itemToRemove = _projectList.Single(s => s.id == id).Emplist.Single(e => e.Id == employee.Id);
                        _projectList.Single(s => s.id == id).Emplist.Remove(itemToRemove);
                        action.status = "Employee is Deleted Successfully " + employee.Id;
                    }
                    else
                    {
                        action.isSucess = false;
                        action.status = "Given Employee ID is not Present in the particular Project " + employee.Id;
                    }
                }
                else
                {
                    action.isSucess = false;
                    action.status = "Project Id is not in the List!" + id;
                }
            }
            catch (Exception e)
            {
                action.isSucess = false;
                action.status = "Exception Occured : " + e.ToString();
            }
            return action;
        }

    }
}











