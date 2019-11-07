using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.DatabaseService
{
    public interface IDbConfiguration
    {
        string GetConnection();
    }
}
