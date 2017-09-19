﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Calendar_LawrenceChu.Models;

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

            List<EventData> list = await Calendar_LawrenceChu.Models.DataBase.Instance.GetItemsAsync();

            if (list.Count != 0)
            {
                await Navigation.PushAsync(new YearPage());
            }
            else
            {

            }


        }



        async void OnLoginClicked(object sender, System.EventArgs e)
        {
            User user = new User(Username.Text, Password.Text);
            //user.PushToServer();
            var isLoginSuccess = await user.Login();
            if (isLoginSuccess)
            {
                //await DataBase.Instance.SaveItemAsync(user);

                //todo most finished
                var events = (EventData)BindingContext;
                await DataBase.Instance.SaveItemAsync(events);

                await Navigation.PushAsync(new YearPage());
            }
            else
            {
                //Message.Text = "Wrong username or password";
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
