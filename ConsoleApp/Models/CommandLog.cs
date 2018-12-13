using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class CommandLog
    {
        public string Id { get; set; }
        public Guid DeviceId { get; set; }
        public string AppId { get; set; }
        public string Command { get; set; }
        public string CallbackUrl { get; set; }
        public int? ExpireTime { get; set; }
        public string Status { get; set; }
        public int? MaxRetransmit { get; set; }
        public DateTime? DeliveredTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
    }
}
