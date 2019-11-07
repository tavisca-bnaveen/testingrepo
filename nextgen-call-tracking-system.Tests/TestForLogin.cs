using Moq;
using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.DAL.DatabaseService;
using nextgen_call_tracking_system.Service.MailSendingService;
using nextgen_call_tracking_system.Service.UserCredentialsService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace nextgen_call_tracking_system.Tests
{
    public class TestForLogin
    {

        [Fact]
        public async void Shows_LoginSuccessfull_For_Verified_User()
        {
            Mock<IMailService> mockMail = new Mock<IMailService>();

            Mock<IStore> mockData = new Mock<IStore>();
            var obj = new UserCredentials
            {
                UserId = "1",
                Password = "Skh@10",
                Role = "Product Manager"
            };
            mockMail.Setup(x => x.SendPassword(obj.UserId, obj.Password)).ReturnsAsync("Mail sent");
            mockData.Setup(x => x.CheckAuthenticatedUser(obj)).ReturnsAsync("Login successfull");
            var ucs = new UserCredentialsService(mockData.Object, mockMail.Object);
            var output = await ucs.VerifyUser(obj);
            Assert.Equal("Login successfull", output);

        }

        [Fact]
        public async void Show_InvalidUserIdOrPassword_For_Unauthorized_User()
        {
            Mock<IStore> mockData = new Mock<IStore>();
            Mock<IMailService> mockMail = new Mock<IMailService>();
            var obj = new UserCredentials
            {
                UserId = "1",
                Password = "Skh@10",
                Role = "Product Manager"
            };
            mockMail.Setup(x => x.SendPassword(obj.UserId, obj.Password)).ReturnsAsync("Mail sent");
            mockData.Setup(x => x.CheckAuthenticatedUser(obj)).ReturnsAsync("Invalid UserId or Password");
            var ucs = new UserCredentialsService(mockData.Object, mockMail.Object);
            var output = await ucs.VerifyUser(obj);
            Assert.Equal("Invalid UserId or Password", output);
        }


        [Fact]
        public async void Show_UserExists_For_An_Existing_UserId()
        {
            Mock<IStore> mockData = new Mock<IStore>();
            Mock<IMailService> mockMail = new Mock<IMailService>();
            var obj = "1";

            mockData.Setup(x => x.CheckUserWithAUserIdExists(obj)).ReturnsAsync("User Exists");
            var ucs = new UserCredentialsService(mockData.Object, mockMail.Object);
            var output = await ucs.IsUserIdValid(obj);
            Assert.Equal("User Exists", output);
        }

        [Fact]
        public async void Show_UserDoesNotExists_For_A_Non_Existing_UserId()
        {
            Mock<IStore> mockData = new Mock<IStore>();
            Mock<IMailService> mockMail = new Mock<IMailService>();
            var obj = "10";

            mockData.Setup(x => x.CheckUserWithAUserIdExists(obj)).ReturnsAsync("User Does Not Exists");
            var ucs = new UserCredentialsService(mockData.Object, mockMail.Object);
            var output = await ucs.IsUserIdValid(obj);
            Assert.Equal("User Does Not Exists", output);
        }

    }
}
