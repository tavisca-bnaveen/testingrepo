using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.DatabaseModels
{
    public class DataReport
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int CallsAcknowledged { get; set; }
        public int CallsInitiated { get; set; }
        public double HoursOnSupport { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
