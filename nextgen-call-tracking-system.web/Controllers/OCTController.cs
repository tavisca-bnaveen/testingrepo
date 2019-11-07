using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nextgen_call_tracking_system.DAL.DatabaseService;
using nextgen_call_tracking_system.Models;
using nextgen_call_tracking_system.Service.FinalReport;

namespace nextgen_call_tracking_system.web.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OCTController : ControllerBase
    {

        private readonly IStore _database;
        private readonly IFinalReport _finalReport;

        public OCTController(IStore _database, IFinalReport _finalReport)
        {

            this._database = _database;
            this._finalReport = _finalReport;

        }
        [HttpGet("GetResponseByMonth")]
        public async Task<ActionResult> GetResponseByMonth([FromQuery]string month, [FromQuery] string year)
        {
            var values = new List<Report>();
            var reports = await _finalReport.GenerateReportByMonthAndYear(month, int.Parse(year));
            values = reports;
            return Ok(new Output { Values = values });
        }

        [HttpGet("GetResponseByStartToEnd")]
        public async Task<ActionResult> GetResponseByStartToEnd([FromQuery]string StartDate, [FromQuery] string EndDate)
        {
            var values = new List<Report>();
            var reports = await _finalReport.GenerateReport(StartDate, EndDate);
            values=reports;
            return Ok(new Output { Values = values });
        }
    }

}
