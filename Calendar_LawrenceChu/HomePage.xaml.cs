using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new YearPage());
        }

        async void OnSkipClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new YearPage());
        }
    }
}
