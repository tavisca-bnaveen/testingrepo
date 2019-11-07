using nextgen_call_tracking_system.DAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.UserCredentialsService
{
    public interface IUserCredentialsService
    {
        Task<string> VerifyUser(UserCredentials userCredentials);
        Task<string> ChangePassword(string userId);
        Task<string> IsUserIdValid(string userId);

    }
}
