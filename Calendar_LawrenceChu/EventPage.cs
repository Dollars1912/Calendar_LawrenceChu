using System;
using System.Collections.Generic;
using Calendar_LawrenceChu.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Calendar_LawrenceChu
{
    public partial class EventPage : ContentPage
    {
        public EventPage(Event e)
        {
            InitializeComponent();
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(-37.846740, 145.115113), Distance.FromMiles(1))
            );
            if (e == null)
                return;

            //TODO
            //Show event pull from server
            Title.Text = e.Title;
            Location.Text = e.Location;
            Detail.Text = e.Detail;
            //StartTimePicker.Time = e.StartTime;
            //EndTimePicker.Time = e.EndTime;
        }

        void OnSaveClicked(object sender, System.EventArgs e)
        {
            var title = Title.Text;
            var location = Location.Text;
            var detail = Detail.Text;
            var pickedStartTime = StartTimePicker.Time;
            var pickedEndTime = EndTimePicker.Time;

            string startTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Year, Time.CurrentTime.Month, Time.CurrentTime.Day,
                                            pickedStartTime.Hours, pickedStartTime.Minutes);
            string endTime = string.Format("{0}/{1}/{2} {3}:{4}", Time.CurrentTime.Year, Time.CurrentTime.Month, Time.CurrentTime.Day,
                                            pickedEndTime.Hours, pickedEndTime.Minutes);

            var newEvent = new Event(title, location, detail, startTime, endTime);
            User.CurrentUser.Events.Add(newEvent);

            User.CurrentUser.PushToServer();
            //Navigation.PopAsync();
            Navigation.PushAsync(new DayPage());
        }
    }
}
