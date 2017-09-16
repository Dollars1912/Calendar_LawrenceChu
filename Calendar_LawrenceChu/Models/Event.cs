using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using SQLite;

namespace Calendar_LawrenceChu.Models
{
    public class Event
    {
        private static List<Event> events;

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

        public static List<Event> Events 
        {
            get 
            {
                if (events == null) 
                {
                    events = new List<Event>();
                }
                return events;
            }
            set
            {
                events = value;
            }
        }

        public static void LoadAllEventsFromServer()
        {
            //TODO
        }

        public string StartTimeString { get; set; }
        public string EndTimeString { get; set; }

        public DateTime StartTime() 
        {
            return Convert.ToDateTime(StartTimeString);
        }

		public DateTime EndTime()
		{
			return Convert.ToDateTime(EndTimeString);
		}

		public string Title
		{
			get;
			set;
		}

		public string Location
		{
			get;
			set;
		}

		public string Detail
		{
			get;
			set;
		}

        public Event(string title, string location, string detail, string startTime, string endTime)
        {
            this.Title = title;
            this.Location = location;
            this.StartTimeString = startTime;
            this.EndTimeString = endTime;
            this.Detail = detail;
        }

        public Event()
        {
            //TODO set to default valye
        }
    }
}
