using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class RoleTemplet
    {
        public RoleTemplet()
        {
            ApplicationRoleRoleTemplets = new HashSet<ApplicationRoleRoleTemplets>();
            RoleTempletApplicationUsers = new HashSet<RoleTempletApplicationUsers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
        public Guid? EntityId { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual ICollection<ApplicationRoleRoleTemplets> ApplicationRoleRoleTemplets { get; set; }
        public virtual ICollection<RoleTempletApplicationUsers> RoleTempletApplicationUsers { get; set; }
    }
}
