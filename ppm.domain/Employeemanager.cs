using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ppm.model;
using ppm.model.common;

namespace ppm.domain
{
    public class Employeemanager: IOperation<Employee>
    {
        public static List<Employee> _EmployeeList = new List<Employee>();
        public void AddEmployee()
        {
            Employee employee = new Employee();
            try
            {
                Console.Write("Enter Employee Id:");
                employee.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee FullName: ");
                employee.Fullname = Console.ReadLine();
                Console.Write("Enter Employee Contact: ");
                employee.Contact = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Employee Role Name: ");
                employee.RoleName = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occoured!" + e.ToString());

            }
            var resultEmployee = Add(employee);
            if (!resultEmployee.isSucess)
            {
                Console.WriteLine("Employee failed to Add");
                Console.WriteLine(resultEmployee.status);
            }
            else
            {
                Console.WriteLine(resultEmployee.status);
            }



        }
        public Result Add(Employee employee)
        {
           Result result = new Result() { isSucess = true };
            try
            {
                if (_EmployeeList.Count > 0)
                {
                    if (_EmployeeList.Exists(em => em.Id == employee.Id))
                    {
                        result.isSucess = false;
                        result.status = "ID Already Exists" + employee.Id;
                    }
                    else
                    {
                        _EmployeeList.Add(employee);
                        result.status = "Employee Added";
                    }
                }
                else
                {
                    _EmployeeList.Add(employee);
                    result.status = "New Employee Added";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.isSucess = false;
            }
            return result;



        }
        public DataResult<Employee> ListAll()
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
        public void DeleteEmployeeById()
        {
            Console.WriteLine("Choose Employee From Below Employee List: Employee ID:Employee First Name");
            var resPro = ListAll();
            if (resPro.isSucess)
            {
                foreach (Employee res in resPro.results)
                {
                    Console.WriteLine(res.Id + " : " + res.Fullname);
                }
            }
            else
            {
                Console.WriteLine(resPro.status);
            }
            Console.Write("Enter The Employee Id wchich u want delete ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Projectmanager m1 = new Projectmanager();
            var result1 = m1.isEmployeePresentinProject(n2);
            if (!result1.isSucess)
            {
                var result = Remove(n2);
                if (!result.isSucess)
                {
                    Console.WriteLine("Employee is not deleted");
                    Console.WriteLine(result.status);
                }
                else
                {
                    Console.WriteLine(result.status);
                }
            }
            else
            {
                Console.WriteLine(result1.status);
            }
        }
        public Result Remove(int id)
        {
            Employee Emp = new Employee();
            Result result = new Result() { isSucess = true };
            try
            {
                if (_EmployeeList.Exists(Emp => Emp.Id == id))
                {
                    var itemToRemove = _EmployeeList.Single(s => s.Id == id);
                    _EmployeeList.Remove(itemToRemove);
                    result.status = "Employee is Deleted Successfully " + Emp.Id;
                }
                else
                {
                    result.isSucess = false;
                    result.status = "Employee Id is not in the List!" + id;
                }
            }
            catch (Exception e)
            {
                result.isSucess = false;
                result.status = "Exception Occured : " + e.ToString();
            }
            return result;
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
        public Employee GetEmployeetoRole(Employee employeeId)
        {
            Employee emp = new Employee();
            emp.RoleName = _EmployeeList.Single(e => e.Id == employeeId.Id).RoleName;
            emp.Fullname = _EmployeeList.Single(e => e.Id == employeeId.Id).Fullname;
            return emp;
        }

    }
}