using System;
using System.Collections.Generic;
using ppm.model;
using ppm.model.common;

namespace Domain
{
    public class Rolemanager
    {
        private static List<Role> _roleList;
        static Rolemanager()
        {
            _roleList = new List<Role>();
        }
        public Result AddRole(Role role)
        {
            Result result = new Result() { isSucess = true };
            try

            {
                if (_roleList.Count > 0)
                {
                    if (_roleList.Exists(r => r.RoleId == role.RoleId))
                    {
                        result.isSucess = false;
                        result.status = "Role already exists" + role.RoleName;
                    }
                    else
                    {
                        _roleList.Add(role);
                        result.status = "Role Added";
                    }
                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.isSucess = false;
            }
            return result;
        }



        public DataResult<Role> GetRoleInfo()
        {
            DataResult<Role> data = new DataResult<Role> { isSucess = true };
            if (_roleList.Count > 0)
            {
                data.results = _roleList;
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
