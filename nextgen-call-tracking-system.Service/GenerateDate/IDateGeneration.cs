using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.GenerateDate
{
    public interface IDateGeneration
    {
        Task<string> GenerateStartTime(int month, int year);
        Task<string> GenerateLastTime(int month, int year);
    }
}
