using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Date
    {

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public int MonthsBetween(Date date)
        {
            int nextdate_year = date.Year;
            int nextdate_month = date.Month;
            int months = abs((Year - nextdate_year) * 12 + Month - nextdate_month);
            return months;
        }

        private int abs(int a)
        {
            if (a < 0)
            {
                return -a;
            }
            return a;
        }

        public int DifferenceInDays(Date date)
        {
            int days1 = GetTotalDays();
            int days2 = date.GetTotalDays();

            return abs(days1 - days2);
        }

        public int GetTotalDays()
        {
            int totalDays = 0;
            for (int y = 1; y < Year; y++)
            {
                totalDays += IsLeapYear(y) ? 366 : 365;
            }

            for (int m = 1; m < Month; m++)
            {
                totalDays += GetDaysInMonth(m, Year);
            }

            totalDays += Day;
            return totalDays;
        }

        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public int GetDaysInMonth(int month, int year)
        {
            if (month == 2)
            {
                return IsLeapYear(year) ? 29 : 28;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else
            {
                return 31;
            }
        }

        public static Date Now
        {
            get
            {
                DateTime currentTime = DateTime.Now;
                return new Date(currentTime.Year, currentTime.Month, currentTime.Day);
            }
        }


        public void printDate()
        {
            Console.WriteLine("(yyyy-mm-dd): "+Year+"-"+Month+"-"+Day);
        }
        

    }
}
