using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class ApplicationRoleRoleTemplets
    {
        public string ApplicationRoleId { get; set; }
        public Guid RoleTempletId { get; set; }

        public virtual AspNetRoles ApplicationRole { get; set; }
        public virtual RoleTemplet RoleTemplet { get; set; }
    }
}
