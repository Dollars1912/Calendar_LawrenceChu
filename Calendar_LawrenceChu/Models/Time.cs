using System;
namespace Calendar_LawrenceChu
{
    public class Time
    {
        private static Time currentTime = new Time(0,0,0,0,0);

		public static Time CurrentTime
		{
			get { return currentTime; }
			set { currentTime = value; }
		}

        public int Year
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public int Day
        {
            get;
            set;
        }

		public int Hour
		{
			get;
			set;
		}

		public int Minute
		{
			get;
			set;
		}

        public String FormattedMonth()
        {
            switch (Month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
            }
            return "";
        }

        public static String FormattedDay(int day)
        {
            switch (day)
            {
                case 1:
                    return "Mon";
                case 2:
                    return "Tue";
                case 3:
                    return "Wed";
                case 4:
                    return "Thu";
                case 5:
                    return "Fri";
                case 6:
                    return "Sat";
                case 7:
                    return "Sun";
            }
            return "";
        }

        public Time(int minute, int hour, int day, int month, int year)
        {
            Minute = minute;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
