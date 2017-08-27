using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class DayPage : ContentPage
    {
        public DayPage()
        {
            InitializeComponent();
        }

        void OnSaveClicked(object sender, System.EventArgs e)
        {
            var title = Title.Text;
            var starTime = new Time(Int32.Parse(StartMinute.Text),
                Int32.Parse(StartHour.Text),
                Int32.Parse(StartDay.Text),
                Int32.Parse(StartMonth.Text),
                Int32.Parse(StartYear.Text));

            var endTime = new Time(Int32.Parse(EndMinute.Text), 
				Int32.Parse(EndHour.Text),
				Int32.Parse(EndDay.Text),
				Int32.Parse(EndMonth.Text),
				Int32.Parse(EndYear.Text));
            
            var newEvent = new Event(User.CurrentUser, title, starTime, endTime);
            newEvent.PushToServer();
            MainLabel.Text = "Well Done!";
        }
    }
}
