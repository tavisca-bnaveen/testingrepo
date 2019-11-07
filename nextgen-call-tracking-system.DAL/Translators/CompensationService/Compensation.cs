using System;
using System.Collections.Generic;
using System.Text;

namespace nextgen_call_tracking_system.DAL.Translators.CompensationService
{
    public class Compensation : ICompensation
    {
        public double GetCompensationForCallsAcknowledged(int callsAcknowledged)
        {

            double response = (double)(1000 * (callsAcknowledged)) / 24;
            response = Math.Ceiling(response);
            return Convert.ToDouble(response.ToString());
        }

        public double GetCompensationForHoursOnSupport(double hoursOnSupport)
        {
            return hoursOnSupport * 10;
        }
    }
}
