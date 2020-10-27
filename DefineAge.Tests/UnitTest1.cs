using System;
using Xunit;

namespace DefineAge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int yesterday, nextDay, correctMonth, nextMonth;
            bool moreDays;

            if ((month < 8 && month % 2 != 0) || (month >= 8 && month % 2 == 0))
                moreDays = true;
            else if (month == 2)
                if (DateTime.IsLeapYear(year))
                    moreDays = false; // 29
                else
                    moreDays = false; //28
            else
                moreDays = true;

            if (moreDays)
            {
                yesterday = day == 1 ? 31 : day - 1;
                nextDay = day == 31 ? 1 : day + 1;
                correctMonth = yesterday == 31 ? month - 1 : month;
            }
            else
            {
                yesterday = day == 1 ? 30 : day - 1;
                nextDay = day == 30 ? 1 : day + 1;
                correctMonth = yesterday == 30 ? month - 1 : month;
            }
            nextMonth = nextDay == 1 ? month + 1 : month;


            var Date1 = new DefineAge(new DateTime(year, correctMonth, yesterday));
            var Date2 = new DefineAge(new DateTime(year-1, correctMonth, yesterday));
            var Date3 = new DefineAge(new DateTime(year-20, correctMonth, yesterday));
            var Date4 = new DefineAge(new DateTime(year, month, day));
            var Date5 = new DefineAge(new DateTime(year-1, month, day));
            var Date6 = new DefineAge(new DateTime(year-20, month, day));
            var Date7 = new DefineAge(new DateTime(year+1, month, day));
            var Date8 = new DefineAge(new DateTime(year, nextMonth, nextDay));
            var Date9 = new DefineAge(new DateTime(year-1, nextMonth, nextDay));
            var Date10 = new DefineAge(new DateTime(year-20, nextMonth, nextDay));


            Assert.Equal(0, Date1.getAge());
            Assert.Equal(1, Date2.getAge());
            Assert.Equal(20, Date3.getAge());
            Assert.Equal(0, Date4.getAge());
            Assert.Equal(1, Date5.getAge());
            Assert.Equal(20, Date6.getAge());
            Assert.Equal(0, Date7.getAge());
            Assert.Equal(0, Date8.getAge());
            Assert.Equal(0, Date9.getAge());
            Assert.Equal(19, Date10.getAge());
        }
    }
}
