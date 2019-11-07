using nextgen_call_tracking_system.DAL.Translators.CompensationService;
using System;
using Xunit;

namespace nextgen_call_tracking_system.Tests
{
    public class TestForCompensation
    {
        private ICompensation _compensation;
        public TestForCompensation()
        {
            _compensation = new Compensation();
        }
        [Fact]
        public void TestForCalculatingCompensationForCallsAcknowledged()
        {
            int CallsAcknowledged = 24;
            double ExceptedValue = 1000;
            Assert.Equal(ExceptedValue, _compensation.GetCompensationForCallsAcknowledged(CallsAcknowledged));
        }
        [Fact]
        public void TestForRoundingCalculatingCompensationForCallsAcknowledged()
        {
            int CallsAcknowledged = 10;
            double ExceptedValue = 417;
            Assert.Equal(ExceptedValue, _compensation.GetCompensationForCallsAcknowledged(CallsAcknowledged));
        }
        [Fact]
        public void TestForCalculatingCompensationForHoursOnSupport()
        {
            double HoursOnSupport = 10;
            double ExceptedValue = 100;
            Assert.Equal(ExceptedValue, _compensation.GetCompensationForHoursOnSupport(HoursOnSupport));
        }
    }
}

