using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
        }

        void OnSaveClicked(object sender, System.EventArgs e)
        {
            var title = Title.Text;
            var detail = Detail.Text;
            var pickedStartTime = StartTimePicker.Time;
			var pickedEndTime = EndTimePicker.Time;

            string dateTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Day, Time.CurrentTime.Month, Time.CurrentTime.Year,
                                            pickedStartTime.Hours, pickedStartTime.Minutes);
			DateTime startTime = Convert.ToDateTime(dateTime);

			dateTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Day, Time.CurrentTime.Month, Time.CurrentTime.Year,
											pickedEndTime.Hours, pickedEndTime.Minutes);
			DateTime endTime = Convert.ToDateTime(dateTime);

			var newEvent = new Event(User.CurrentUser, title, detail, startTime, endTime);
            User.CurrentUser.Events.Add(newEvent);

            //newEvent.PushToServer();
            MainLabel.Text = "Well Done!";
            Navigation.PushAsync(new DayPage());
        }
    }
}
