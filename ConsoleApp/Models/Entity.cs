using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class Entity
    {
        public Entity()
        {
            AlarmLog = new HashSet<AlarmLog>();
            AspNetUsers = new HashSet<AspNetUsers>();
            Device = new HashSet<Device>();
            RoleTemplet = new HashSet<RoleTemplet>();
        }

        public Guid Id { get; set; }
        public string SystemName { get; set; }
        public string Company { get; set; }
        public string AppId { get; set; }
        public string Secret { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }

        public virtual ICollection<AlarmLog> AlarmLog { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<RoleTemplet> RoleTemplet { get; set; }
    }
}
