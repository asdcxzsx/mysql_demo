using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class DeviceModel
    {
        public DeviceModel()
        {
            Device = new HashSet<Device>();
        }

        public Guid Id { get; set; }
        public string AppId { get; set; }
        public string DeviceType { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerId { get; set; }
        public string Model { get; set; }
        public string ProtocolType { get; set; }
        public string Photo { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
