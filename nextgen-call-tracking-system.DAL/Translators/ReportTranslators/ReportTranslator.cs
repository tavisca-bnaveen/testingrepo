using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.DAL.Translators.CompensationService;
using nextgen_call_tracking_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.DAL.Translators.ReportTranslators
{
    public class ReportTranslator : IReportTranslator
    {
        private ICompensation _compensation;
        public ReportTranslator()
        {
            _compensation = new Compensation();
        }
        public async Task<List<Report>> ConvertDataToReport(List<DataReport> dataReports)
        {
            var reports = new List<Task<Report>>();
            foreach (var report in dataReports)
            {
                reports.Add(Task.Run(() => new Report
                {
                    Id = report.Id,
                    FullName = report.FirstName + " " + report.LastName,
                    CallsAcknowledged = report.CallsAcknowledged,
                    CallsIntiated = report.CallsInitiated,
                    EmployeeId = report.EmployeeId,
                    HoursOnSupport = report.HoursOnSupport,
                    CompensationForCallsAcknowledged = _compensation.GetCompensationForCallsAcknowledged(report.CallsAcknowledged),
                    CompensationForHoursOnSupport = _compensation.GetCompensationForHoursOnSupport(report.HoursOnSupport)

                }));
            }
            var results = await Task.WhenAll(reports);
            return results.ToList<Report>();
        }
    }
}
