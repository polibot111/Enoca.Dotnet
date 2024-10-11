using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.CronExpressions
{
    public static class CronExpression
    {
        // * * * * * *
        // - - - - - -
        // | | | | | |
        // | | | | | +--- day of week(0 - 6) (Sunday=0)
        // | | | | +----- month(1 - 12)
        // | | | +------- day of month(1 - 31)
        // | | +--------- hour(0 - 23)
        // | +----------- min(0 - 59)
        // +------------- sec(0 - 59)

        // check your cron value on:"https://bradymholt.github.io/cron-expression-descriptor/"
        public static string EverySecond()
        {
            return "* * * ? * *";
        }
        public static string EveryMinute()
        {
            return "0 * * ? * *";
        }
        public static string EveryMinutesOf(int value)
        {
            //*/15 * * * *
            var result = "*/" + value.ToString() + " * * * *";
            return result;
        }

        public static string EveryQuarterOfAnHour()
        {
            return "0 15,30,45 * ? * *";
        }
        public static string EveryHour()
        {
            return "0 0 * ? * *";
        }
        public static string EveryTwoHours()
        {
            return "0 0 0/2 ? * *";
        }
        public static string EveryHoursOf(int value)
        {
            var result = "0 0 */" + value.ToString() + " ? * *";
            return result;
        }
        public static string EverdayAt12am()
        {
            return "0 0 0 * * ?";

        }
        public static string EverdayAt12pm()
        {
            return "0 0 12 * * ?";
        }

    }
}
