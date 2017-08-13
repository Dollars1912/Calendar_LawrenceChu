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
            User user = new User(Username.Text, Password.Text);
            //await user.RefreshDataAsync();
            await Navigation.PushAsync(new YearPage());
        }

        async void OnSkipClicked(object sender, System.EventArgs e)
        {
			User user = new User();
			await Navigation.PushAsync(new YearPage());
        }
    }
}
