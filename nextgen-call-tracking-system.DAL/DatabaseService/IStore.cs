using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.DAL.DatabaseService
{
    public interface IStore
    {
        Task<List<Report>> GenerateReports(string StartTime, string EndTime);
        Task<string> UpdatePasswordInDatabase(UserCredentials credentials);
        Task<string> CheckAuthenticatedUser(UserCredentials credentials);
        Task<string> CheckUserWithAUserIdExists(string userId);


    }
}
