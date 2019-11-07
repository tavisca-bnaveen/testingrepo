using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.DAL.DatabaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.UserCredentialsService
{
    public class UserCredentialsService : IUserCredentialsService
    {
        IStore _dbService;
        MailSendingService.IMailService _mailService;

        public UserCredentialsService(IStore dbService, MailSendingService.IMailService mailService)
        {
            _dbService = dbService;
            _mailService = mailService;
        }
        public string GenerateRandomPassword()
        {
            var response = "";
            var availableAlphabetsForPasswordGeneration = "1234567890qwertyuiopasdfghjklzxcvbnm@!#$";
            var random = new Random();
            for (var i = 0; i < 5; i++)
            {
                response += availableAlphabetsForPasswordGeneration[random.
                                                          Next(availableAlphabetsForPasswordGeneration.
                                                                Length)];
            }
            return response;
        }

        public async Task<string> ChangePassword(string userId)
        {
            var check = await IsUserIdValid(userId);
            if (check != "User Exists")
                return check;
            var user = new UserCredentials
            {
                Password = GenerateRandomPassword(),
                UserId = userId
            };

            var response = await _dbService.
                            UpdatePasswordInDatabase(user);
            var mailStatus = await _mailService.SendPassword(user.UserId, user.Password);
            return mailStatus == "Mail sent" ? response : "Password updated but " + mailStatus;
        }
        public async Task<string> IsUserIdValid(string userId)
        {
            var response = "";
            response = await _dbService.
                            CheckUserWithAUserIdExists(userId);
            return response;
        }
        public async Task<string> VerifyUser(UserCredentials userCredentials)
        {
            var response = "";
            response = await _dbService.
                        CheckAuthenticatedUser(userCredentials);

            return response;
        }

    }
}
