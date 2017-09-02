using System;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public class DayPage : ContentPage
    {
        public DayPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

