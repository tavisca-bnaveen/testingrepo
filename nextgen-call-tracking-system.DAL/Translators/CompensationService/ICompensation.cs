using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.Translators.CompensationService
{
    public interface ICompensation
    {
        double GetCompensationForCallsAcknowledged(int callsAcknowledged);
        double GetCompensationForHoursOnSupport(double hoursOnSupport);
    }
}
