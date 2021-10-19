using Domain;
using ppm.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ppm.domain
{
   public class Save
    {
        public void save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter Filestream = new StreamWriter(@"D:\\dileep project\\prolificsprojectmanager\\employees.xml");
            xmlSerializer.Serialize(Filestream, Employeemanager._EmployeeList);

            Filestream.Close();

            XmlSerializer ProjectxmlSerializer = new XmlSerializer(typeof(List<Project>));
            TextWriter ProjectFilestream = new StreamWriter(@"D:\\dileep project\\prolificsprojectmanager\\projects.xml");
            ProjectxmlSerializer.Serialize(ProjectFilestream, Projectmanager._projectList);

            ProjectFilestream.Close();

            XmlSerializer RolexmlSerializer = new XmlSerializer(typeof(List<Role>));
            TextWriter RoleFilestream = new StreamWriter(@"D:\\dileep project\\prolificsprojectmanager\\Roles.xml");
            RolexmlSerializer.Serialize(RoleFilestream, Rolemanager._roleList);

            RoleFilestream.Close();
        }
    }
}

