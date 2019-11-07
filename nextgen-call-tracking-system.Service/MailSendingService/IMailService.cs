using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.MailSendingService
{
    public interface IMailService
    {
        Task<string> SendPassword(string userId, string Password);
    }
}
