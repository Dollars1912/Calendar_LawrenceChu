﻿using System;
namespace Calendar_LawrenceChu
{
    public class Date
    {
        public static int Year
        {
            get;
            set;
        }

		public static int Month
		{
			get;
			set;
		}

		public static int Day
		{
			get;
			set;
		}

        public static String FormattedMonth() 
        {
            // TODO
            switch (Month) {
                case 1:
                    return "Jan";
				case 2:
					return "Feb";
				case 3:
					return "Mar";
				case 4:
					return "Apr";
				case 5:
					return "May";
				case 6:
					return "Jun";
				case 7:
					return "Jul";
				case 8:
					return "Aug";
				case 9:
					return "Sep";
				case 10:
					return "Oct";
				case 11:
					return "Nov";
				case 12:
					return "Dec";
            }
            return "";
        }

        public static String FormattedDay(int day)
        {
            switch (day) {
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

		public Date()
        {
        }
    }
}
