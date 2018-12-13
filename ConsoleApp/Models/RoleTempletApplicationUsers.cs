using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class RoleTempletApplicationUsers
    {
        public Guid RoleTempletId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual RoleTemplet RoleTemplet { get; set; }
    }
}
