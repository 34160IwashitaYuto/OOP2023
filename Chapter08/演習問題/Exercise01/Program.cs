using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = new DateTime(2023, 6, 30, 11, 36, 47);
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);

        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //var str = string.Format("{0}/{1,2}/{2,2} {3}:{4}", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute);
            var s1 = dateTime.ToString("yyyy/MM/dd　hh:mm");
            Console.WriteLine(s1);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //var str = string.Format("{0}年{1,2}月{2,2}日 {3}時{4}分{5}秒", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute,dateTime.Second);
            var s2 = dateTime.ToString("yyyy年MM月dd日　HH時mm分ss秒");
            Console.WriteLine(s2);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(dateTime);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            var str = string.Format("{0}年{1,2}月{2,2}日({3})", eraName,dateTime.Month, dateTime.Day, dayOfWeek);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dateStr = dateTime.ToString("ggyy年MM月dd日（dddd）",culture);
        }
    }
}
