using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace POC_Leave_Management.Models
{
    public partial class RequestLeave
    {
        public int ReqId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LeaveStart { get; set; }
        public DateTime LeaveEnd { get; set; }
        public string Reason { get; set; }
    }
}
