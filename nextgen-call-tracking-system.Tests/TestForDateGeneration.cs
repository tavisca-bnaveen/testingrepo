using nextgen_call_tracking_system.Service.GenerateDate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nextgen_call_tracking_system.Tests
{
    public class TestForDateGeneration
    {
        [Fact]
        public async Task TestForStartTime()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string StartTime = await dateGeneration.GenerateStartTime(2, 2000);
            Assert.Equal("2000-2-01 00:00:00", StartTime);
        }
        [Fact]
        public async Task TestForEndTimeOfFebInLeapYear()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(2, 2004);
            Assert.Equal("2004-2-29 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTimeOfFebInDecabeNonLeapYear()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(2, 2000);
            Assert.Equal("2000-2-28 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTimeOfFebInNonLeapYear()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(2, 2005);
            Assert.Equal("2005-2-28 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTime()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(1, 2004);
            Assert.Equal("2004-1-31 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTimeOfAugust()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(8, 2004);
            Assert.Equal("2004-8-31 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTimeOfJune()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(6, 2004);
            Assert.Equal("2004-6-30 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForEndTimeOfNovember()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string EndTime = await dateGeneration.GenerateLastTime(11, 2004);
            Assert.Equal("2004-11-30 23:59:59", EndTime);
        }
        [Fact]
        public async Task TestForStartTimeOfDecember()
        {
            IDateGeneration dateGeneration = new DateGeneration();
            string StartTime = await dateGeneration.GenerateStartTime(12, 2004);
            Assert.Equal("2004-12-01 00:00:00", StartTime);
        }
    }
}
