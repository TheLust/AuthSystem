using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthSystem.Service
{
    public class RoleService
    {
        private AuthSystemEntities context; 

        public RoleService()
        {
            context = new AuthSystemEntities();
        }

        public List<Role> FindAll()
        {
            return context.Roles.ToList();
        }

        public Role FindByName(string name)
        {
            Role role = context.Roles.FirstOrDefault(r => r.Name.Equals(name));

            if (role == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Role", "name", AppConstant.NOT_FOUND));
            }

            return role;
        }

        public Role FindUserRole()
        {
            return FindByName("User");
        }
    }
}
