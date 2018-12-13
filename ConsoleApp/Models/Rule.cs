using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class Rule
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AppKey { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDisable { get; set; }
    }
}
