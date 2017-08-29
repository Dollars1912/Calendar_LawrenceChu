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

		public User Creater
		{
			get;
			set;
		}

		public Time StartTime
		{
			get;
			set;
		}

		public Time EndTime
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

        public Event(User creater, string title, string detail, Time startTime, Time endTime)
        {
            this.Creater = creater;
            this.Title = title;
            this.Description = detail;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public async void PushToServer()
        {
            var createdAt = DateTime.Now.ToString("yyyyMMddHHmmss");
            var data = JsonConvert.SerializeObject(this);
            var json = "{\"event" + createdAt + "\":" + data + "}";
            var uriString = string.Format("http://introtoapps.com/datastore.php?action=append&appid=215194361&objectid={0}_event", Creater.Username.ToLower());
            var uri = new Uri(uriString);
            var client = new HttpClient();
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("data", json)
            };
            var content = new FormUrlEncodedContent(pairs);
            var response = await client.PostAsync(uri, content);
        }
    }
}
