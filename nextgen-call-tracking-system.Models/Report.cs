using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public int CallsIntiated { get; set; }
        public int CallsAcknowledged { get; set; }
        public double HoursOnSupport { get; set; }
        public double CompensationForCallsAcknowledged { get; set; }
        public double CompensationForHoursOnSupport { get; set; }
        
    }
}
