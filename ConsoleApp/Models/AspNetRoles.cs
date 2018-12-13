using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            ApplicationRoleRoleTemplets = new HashSet<ApplicationRoleRoleTemplets>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Remark { get; set; }
        public string Discriminator { get; set; }

        public virtual ICollection<ApplicationRoleRoleTemplets> ApplicationRoleRoleTemplets { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
