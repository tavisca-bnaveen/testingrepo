using Moq;
using nextgen_call_tracking_system.DAL.DatabaseService;
using nextgen_call_tracking_system.DAL.Translators.ReportTranslators;
using nextgen_call_tracking_system.Models;
using nextgen_call_tracking_system.Service.FinalReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nextgen_call_tracking_system.Tests
{
   public class TestForReportGeneration
    {
        private IReportTranslator _reportTranslator;
        public TestForReportGeneration()
        {
            _reportTranslator = new ReportTranslator();
        }
        [Fact]
        public async Task ReportGenerationByStartToEnd()
        {
            var MockInfo = new Mock<IStore>();
            var reports = Task.Run(() => GetList());
            MockInfo.Setup(fun => fun.GenerateReports("2000-1-01 00:00:00", "2000-1-31 23:59:59")).Returns(reports);
            IFinalReport finalReport = new FinalReport(MockInfo.Object);


            var reportsList = await finalReport.GenerateReport("2000-1-01", "2000-1-31");
            Assert.Equal("naveen bora", reportsList[0].FullName);
        }
        [Fact]
        public async Task ReportGenerationByMonth()
        {
            var MockInfo = new Mock<IStore>();
            var reports = Task.Run(() => GetList());
            MockInfo.Setup(fun => fun.GenerateReports("2000-1-01 00:00:00", "2000-1-31 23:59:59")).Returns(reports);
            IFinalReport finalReport = new FinalReport(MockInfo.Object);
            var reportsList = await finalReport.GenerateReportByMonthAndYear("january", 2000);
            Assert.Equal("111", reportsList[0].EmployeeId);
        }
        private List<Report> GetList()
        {
            var reports = new List<Report>
            {
                new Report { Id = 0, CallsAcknowledged = 1, HoursOnSupport = 1, EmployeeId = "111", FullName="naveen bora",CompensationForHoursOnSupport=10,CompensationForCallsAcknowledged=10,CallsIntiated=10}
            };
            return reports;
        }
    }
}
