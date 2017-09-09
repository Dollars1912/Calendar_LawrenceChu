using System;
namespace Calendar_LawrenceChu
{
    public class Time
    {
        public static DateTime CurrentTime = new DateTime();

        public static void SetYear(int year) {
			string date = string.Format("{0}/{1}/{2}", year, CurrentTime.Month, CurrentTime.Day);
			DateTime dt = Convert.ToDateTime(date);
			CurrentTime = dt;
        }

		public static void SetMonth(int month)
		{
            string date = string.Format("{0}/{1}/{2}", CurrentTime.Year , month, CurrentTime.Day);
			DateTime dt = Convert.ToDateTime(date);
			Time.CurrentTime = dt;
		}

		public static void SetDay(int day)
		{
            string date = string.Format("{0}/{1}/{2}", CurrentTime.Year, CurrentTime.Month, day);
           	DateTime dt = Convert.ToDateTime(date);
			Time.CurrentTime = dt;
		}

		public static String FormattedMonth(int month)
		{
            switch (month)
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

	}
}
