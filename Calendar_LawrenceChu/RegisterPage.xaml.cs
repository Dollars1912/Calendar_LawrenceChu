using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

			ToolbarItem toolbarItem = new ToolbarItem
			{
				Text = "Cancel"
			};

			toolbarItem.Clicked += Cancel;
            ToolbarItems.Add(toolbarItem);
        }

        async void Cancel(object sender, EventArgs e)
		{
            await Navigation.PopModalAsync();
		}
        //void CancelAgain()
        //{
        //    Navigation.PopModalAsync();
        //}

    


        async void OnRegisterClicked(object sender, System.EventArgs e)
        {
			User user = new User(Username.Text, Password.Text);
			user.PushToServer();
			var isLoginSuccess = await user.Login();
            if (isLoginSuccess)
            {
                await DisplayAlert("Success", "Welcome   " + Username.Text, "OK");
                //CancelAgain();
                await Navigation.PushAsync(new YearPage());
            }
            else
			{
                //Message.Text = "Wrong username or password";
                return;
			}
        }



    }


}
