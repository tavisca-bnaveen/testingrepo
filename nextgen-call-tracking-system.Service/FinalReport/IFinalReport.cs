using nextgen_call_tracking_system.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.FinalReport
{
    public interface IFinalReport
    {
        Task<List<Report>> GenerateReport(string StartDate, string EndDate);
        Task<List<Report>> GenerateReportByMonthAndYear(string month, int Year);
    }
}
