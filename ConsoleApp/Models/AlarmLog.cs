using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class AlarmLog
    {
        public Guid Id { get; set; }
        public int Severity { get; set; }
        public int AlarmStatus { get; set; }
        public string RuleId { get; set; }
        public string Reasons { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public DateTime? RecoveryTime { get; set; }
        public int RecoveryReason { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
        public Guid? EntityId { get; set; }
        public string RecoveryAction { get; set; }
        public string Conditions { get; set; }

        public virtual Entity Entity { get; set; }
    }
}
