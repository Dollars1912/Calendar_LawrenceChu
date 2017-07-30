using System;
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
					return "Jan";
				case 4:
					return "Jan";
				case 5:
					return "Jan";
				case 6:
					return "Jan";
				case 7:
					return "Jan";
				case 8:
					return "Jan";
				case 9:
					return "Jan";
				case 10:
					return "Jan";
				case 11:
					return "Jan";
				case 12:
					return "Jan";
            }
            return "";
        }

		public Date()
        {
        }
    }
}
