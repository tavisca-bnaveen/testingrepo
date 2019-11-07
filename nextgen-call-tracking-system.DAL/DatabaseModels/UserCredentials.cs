using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.DatabaseModels
{
    public class UserCredentials
    {
        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
