using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class Device
    {
        public Guid Id { get; set; }
        public string NodeId { get; set; }
        public string EndUserId { get; set; }
        public string Psk { get; set; }
        public int Timeout { get; set; }
        public bool IsSecure { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string DevGroupId { get; set; }
        public string DevGroup { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
        public Guid? DeviceModelId { get; set; }
        public Guid? EntityId { get; set; }

        public virtual DeviceModel DeviceModel { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
