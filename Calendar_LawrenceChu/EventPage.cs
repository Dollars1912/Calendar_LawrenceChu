using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class EventPage : ContentPage
    {
        public EventPage(Event e)
        {
            InitializeComponent();
            if (e == null)
                return;
            //TODO
            Title.Text = e.Title;
            Location.Text = e. Location;
        }

        void OnSaveClicked(object sender, System.EventArgs e)
        {
            var title = Title.Text;
            var detail = Detail.Text;
            var pickedStartTime = StartTimePicker.Time;
			var pickedEndTime = EndTimePicker.Time;

            string dateTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Year, Time.CurrentTime.Month, Time.CurrentTime.Day,
                                            pickedStartTime.Hours, pickedStartTime.Minutes);
			DateTime startTime = Convert.ToDateTime(dateTime);

			dateTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Year, Time.CurrentTime.Month, Time.CurrentTime.Day,
											pickedEndTime.Hours, pickedEndTime.Minutes);
			DateTime endTime = Convert.ToDateTime(dateTime);

			var newEvent = new Event(title, detail, startTime, endTime);
            User.CurrentUser.Events.Add(newEvent);

            User.CurrentUser.PushToServer();
            MainLabel.Text = "Well Done!";
            Navigation.PushAsync(new DayPage());
        }
    }
}
