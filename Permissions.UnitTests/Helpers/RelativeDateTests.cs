

namespace Permissions.UnitTests.Helpers
{
    public class RelativeDateTests
    {

        [Fact]
        public void GetRelativeDate_OneMinute()
        {
            string aboutAMinute = "about a minute from now";
            var currentYear = DateTime.Now.AddMinutes(1);

            var currentYearRelative = currentYear.ToRelativeDate();

            Assert.True(currentYearRelative == aboutAMinute);
        }

        [Fact]
        public void GetRelativeDate_TenMinute()
        {
            string aboutA10Minute = string.Format("{0} minutes from now", 10);
            var currentYear = DateTime.Now.AddMinutes(10);

            var currentYearRelative = currentYear.ToRelativeDate();

            Assert.True(currentYearRelative == aboutA10Minute);
        }

        [Fact]
        public void GetRelativeDate_OneHour()
        {
            string aboutOneHour = "about an hour from now";
            var currentYear = DateTime.Now.AddHours(1);

            var currentYearRelative = currentYear.ToRelativeDate();

            Assert.True(currentYearRelative == aboutOneHour);
        }

        [Fact]
        public void GetRelativeDate_OneYear() 
        {
            string aboutAYear = "about a year from now";
            var currentYear = DateTime.Now.AddYears(1);

            var currentYearRelative = currentYear.ToRelativeDate();
            
            Assert.True(currentYearRelative == aboutAYear);
        }
    }
}
