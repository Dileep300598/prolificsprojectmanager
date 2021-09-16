using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ppm.model;
using ppm.model.common;

namespace ppm.domain
{
    public class Employeemanager
    {
        private static List<Employee> _EmployeeList;
        static Employeemanager()
        {
            _EmployeeList = new List<Employee>();
        }
        public Result AddEmployee(Employee emp)
        {
            Result result = new Result() { isSucess = true };
            try
            {
                _EmployeeList.Add(emp);
                result.status = "Employee added";
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.isSucess = false;
            }
            return result;
        }



        public DataResult<Employee> GetEmployeeInfo()
        {
            DataResult<Employee> data = new DataResult<Employee> { isSucess = true };
            if (_EmployeeList.Count > 0)
            {
                data.results = _EmployeeList;
            }
            else
            {
                data.isSucess = false;
                data.status = "List is Empty!";
            }
            return data;
        }
    }
}