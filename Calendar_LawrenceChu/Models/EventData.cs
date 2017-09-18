using System;

using Xamarin.Forms;
using SQLite;

namespace Calendar_LawrenceChu
{
	public class EventData
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		//public bool Read { get; set; }
	}
}

