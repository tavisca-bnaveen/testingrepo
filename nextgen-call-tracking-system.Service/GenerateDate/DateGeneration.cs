using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.GenerateDate
{
    public class DateGeneration : IDateGeneration
    {

        public async Task<string> GenerateStartTime(int month, int year)
        {
            //2019-1-1 2:13:00
            string StartTime = year.ToString() + "-" + month.ToString() + "-01";
            return StartTime+" 00:00:00" ;
        }

        public async Task<string> GenerateLastTime(int month, int year)
        {
            string EndTime = "30";
            if (month <= 7 && month != 2)
            {

                EndTime = month % 2 == 1 ? "31" : "30";

            }
            else if (month != 2 && month > 7)
            {
                EndTime = month % 2 == 0 ? "31" : "30";
            }
            else if (month == 2)
            {
                EndTime = (year % 4 == 0 && year % 100 != 0) ? "29" : "28";
            }
            EndTime = year.ToString() + "-" + month.ToString() + "-" + EndTime.ToString();
            return EndTime+" 23:59:59" ;
        }
    }
}
