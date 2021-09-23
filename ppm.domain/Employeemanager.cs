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
        private static List<Employee> _EmployeeList = new List<Employee>();
        
        public Result AddEmployee(Employee emp)
        {
            Result result = new Result() { isSucess = true };

            try
            {
                if (_EmployeeList.Count > 0)
                {
                    if (_EmployeeList.Exists(em => em.Id == emp.Id))

                    {
                        result.isSucess = false;
                        result.status = "employee already exists" + emp.Fullname;
                    }
                }
                else
                {
                    _EmployeeList.Add(emp);
                    result.status = "Employee added";
                }
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
        public Result IsValidEmp(Employee emp1)

        {
            Result result = new Result() { isSucess = true };
            try
            {
                if (_EmployeeList.Exists(e => e.Id == emp1.Id))
                {
                    result.status = "Validation Successful!";
                }
                else
                {
                    result.isSucess = false;
                    result.status = "ID is not in the Employee List " + emp1.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                result.isSucess = false;
            }
            return result;
        }
        public DataResult<Employee> GetAllEmployee()
        {
            DataResult<Employee> data = new DataResult<Employee> { isSucess = true };
            return data;
        }
      
    }
}