using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.DatabaseService
{
    public class SqlDbConfiguration : IDbConfiguration
    {
        IConfiguration _configuration;
        public SqlDbConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            return _configuration.GetSection("connection").Value;
        }
    }
}
