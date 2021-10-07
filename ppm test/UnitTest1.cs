using Domain;
using NUnit.Framework;
using ppm.domain;
using ppm.model;
using System;

namespace ppm_test
{
    public class Tests
    {


        [Test]
        public void AddProjectTest()
        {
            Projectmanager project = new Projectmanager();
            Project pp = new Project();
            pp.id = 1;
            pp.Name = "Dileep";
            pp.StartDate = Convert.ToDateTime("01 - 01 - 2020");
            pp.EndDate = Convert.ToDateTime("01-01-2022");
            pp.Budget = 400000;
            var v1 = project.Add(pp);
            if (v1.isSucess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        public void AddEmployeeTest()
        {
            Employeemanager employee = new Employeemanager();
            Employee ee = new Employee();
            ee.Id = 1;
            ee.Fullname = "Dileep";
            ee.Contact = 123456;
            ee.RoleName = "Hr";
            var e1 = employee.Add(ee);
            if (e1.isSucess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void AddRoleTest()
        {
            Rolemanager role = new Rolemanager();
            Role r = new Role();
            r.RoleId = 12;
            r.RoleName = "Manager";
            var r1 = role.Add(r);
            if (r1.isSucess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
       [Test]
       public void AddEmployeeToProject()
        {
            Employee emp = new ();
            Employeemanager ee = new();
            int id = 1;
            emp.Fullname = "dileep";
            var v1 = ee.IsValidEmp(emp);
            if (!v1.isSucess)
            {
                Projectmanager projectmanager = new Projectmanager();
                var r1 = projectmanager.AddEmpToProject(emp, id);
                if (!r1.isSucess) 
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
               
            }

        }
        [Test]
        public void RemoveEmployeeFromProject()
        {
            Employee emp = new Employee();
            Employeemanager ee = new Employeemanager();
            int id = 1;
            emp.Fullname = "dileep";
            var e1 = ee.IsValidEmp(emp);
            if (e1.isSucess)
            {
                Projectmanager projectmanager = new Projectmanager();
                var r1 = projectmanager.DeleteEmpFromProject(id , emp);
                if (!r1.isSucess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }

            }

        }
    }
}