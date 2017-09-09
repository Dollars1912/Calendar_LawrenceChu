using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Calendar_LawrenceChu
{
    public class Event
    {
        private static List<Event> events;

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

        public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

        public Event(string title, string detail, DateTime startTime, DateTime endTime)
        {
            this.Title = title;
            this.Description = detail;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
