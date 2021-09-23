using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ppm.model;
using ppm.model.common;

namespace ppm.domain
{
    public class Projectmanager
    {
        private static List<Project> _projectList = new List<Project>();
        
        public Result AddProject(Project pro)
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



        public DataResult<Project> GetProjectInfo()
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











