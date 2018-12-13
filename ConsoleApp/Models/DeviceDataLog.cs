using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class DeviceDataLog
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public string Data { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
    }
}
