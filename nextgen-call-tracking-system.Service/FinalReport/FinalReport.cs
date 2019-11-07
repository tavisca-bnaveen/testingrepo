using nextgen_call_tracking_system.DAL.DatabaseService;
using nextgen_call_tracking_system.DAL.Translators.ReportTranslators;
using nextgen_call_tracking_system.Models;
using nextgen_call_tracking_system.Service.GenerateDate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.FinalReport
{
    public class FinalReport : IFinalReport
    {
        private IStore _database;
        private IDateGeneration _dateGeneration;
        private IReportTranslator _reportTranslator;
        public FinalReport(IStore Database)
        {
            _database = Database;
            _dateGeneration = new DateGeneration();
            _reportTranslator = new ReportTranslator();
        }
        public async Task<List<Report>> GenerateReport(string StartDate, string EndDate)
        {
            List<Report> reports = new List<Report>();
            string StartTime =StartDate+ " 00:00:00";
            string EndTime =EndDate+ " 23:59:59";
            reports = await _database.GenerateReports(StartTime, EndTime);
            return reports;

        }
        public async Task<List<Report>> GenerateReportByMonthAndYear(string month, int Year)
        {
            List<Report> reports = new List<Report>();
            int _month = (int)(Month)Enum.Parse(typeof(Month), month.ToLower());
            var StartTime = _dateGeneration.GenerateStartTime(_month, Year);
            var EndTime = _dateGeneration.GenerateLastTime(_month, Year);
            Task.WaitAll(new Task[] { StartTime, EndTime });
            reports = await _database.GenerateReports(await StartTime, await EndTime);
            return reports;
        }
    }
}
