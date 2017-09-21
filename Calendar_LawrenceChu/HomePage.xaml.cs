using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Calendar_LawrenceChu.Models;
using System.Security;

namespace Calendar_LawrenceChu
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            myList();
        }

		public async void myList()
		{

			List<UserData> list = await Calendar_LawrenceChu.Models.DataBase.Instance.GetItemsAsync();

			if (list.Count != 0)
			{
				UserData userData = await Calendar_LawrenceChu.Models.DataBase.Instance.LoadUser();
				User user = new User(userData.Username, userData.Password);
				var isLoginSuccess = await user.Login();
				if (isLoginSuccess)
				{
					//var userData = new UserData();
					userData.Username = user.Username;
					userData.Password = user.Password;
					await DataBase.Instance.SaveItemAsync(userData);
					await Navigation.PushModalAsync(new NavigationPage(new YearPage()));
				}
			}
		}

        async void OnLoginClicked(object sender, System.EventArgs e)
        {
            User user = new User(Username.Text, Password.Text);

            var isLoginSuccess = await user.Login();
            if (isLoginSuccess)
            {
                var userData = new UserData();
                userData.Username = user.Username;
                userData.Password = user.Password;
                await DataBase.Instance.SaveItemAsync(userData);
                await Navigation.PushModalAsync(new NavigationPage(new YearPage()));
            }
            else
            {
                await DisplayAlert("Error", "Your password is not correct", "Ok");
            }
        }

        async void OnRegisterClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
        }

        async void OnSkipClicked(object sender, System.EventArgs e)
        {
            User user = new User();
            User.CurrentUser = user;
            await Navigation.PushAsync(new YearPage());
        }
    }
}
