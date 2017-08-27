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
            //user.PushToServer();
            var isLoginSuccess = await user.Login();
            if (isLoginSuccess) {
                await Navigation.PushAsync(new YearPage());
            } else {
                Message.Text = "Wrong username or password";
            }

        }

        async void OnSkipClicked(object sender, System.EventArgs e)
        {
			User user = new User();
			await Navigation.PushAsync(new YearPage());
        }
    }
}
