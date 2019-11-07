using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.DAL.Translators.ReportTranslators
{
    public interface IReportTranslator
    {
        Task<List<Report>> ConvertDataToReport(List<DataReport> dataReports);
    }
}
