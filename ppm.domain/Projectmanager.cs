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
        private static List<Project> _projectList;
        static Projectmanager()
        {
            _projectList = new List<Project>();
        }
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
        public Result AddEmpToProject(string empname,int id)
        {
            Result result = new Result() { isSucess = true };
            return result;
        }
        public Result RemoveEmpFromProject(string empname,int id)
        {
            Result result = new Result() { isSucess = true };
            return result;
        }

    }
}




