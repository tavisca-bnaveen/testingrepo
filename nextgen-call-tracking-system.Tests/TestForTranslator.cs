using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.DAL.Translators.ReportTranslators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nextgen_call_tracking_system.Tests
{
    public class TestForTranslator
    {
        private IReportTranslator _reportTranslator;
        public TestForTranslator()
        {
            _reportTranslator = new ReportTranslator();
        }
        [Fact]
        public async Task ConvertDataModelToReportTest()
        {
            var dataReportList = new List<DataReport>
            {
                new DataReport {Id=1,EmployeeId="111",CallsAcknowledged=10,CallsInitiated=10,FirstName="Naveen",LastName="Bora",HoursOnSupport=10}
            };
            var reportList = await _reportTranslator.ConvertDataToReport(dataReportList);
            Assert.Equal(417, reportList[0].CompensationForCallsAcknowledged);
        }
        [Fact]
        public async Task ConvertDataModelToReportAndCheckFullName()
        {
            var dataReportList = new List<DataReport>
            {
                new DataReport {Id=1,EmployeeId="111",CallsAcknowledged=10,CallsInitiated=10,FirstName="Naveen",LastName="Bora",HoursOnSupport=10}
            };
            var reportList = await _reportTranslator.ConvertDataToReport(dataReportList);


            Assert.Equal("Naveen Bora", reportList[0].FullName);
        }
        [Fact]
        public async Task ConvertDataModelToReportAndCheckCompensation()
        {
            var dataReportList = new List<DataReport>
            {
                new DataReport {Id=1,EmployeeId="111",CallsAcknowledged=10,CallsInitiated=10,FirstName="Naveen",LastName="Bora",HoursOnSupport=10}
            };
            var reportList = await _reportTranslator.ConvertDataToReport(dataReportList);
            Assert.Equal(100, reportList[0].CompensationForHoursOnSupport);

        }

    }
}
