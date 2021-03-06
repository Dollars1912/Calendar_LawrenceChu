﻿using Xamarin.Forms;
using System;
using Calendar_LawrenceChu.Models;
using System.Collections.Generic;

namespace Calendar_LawrenceChu
{
    public partial class MonthPage : ContentPage
    {
        public MonthPage()
        {
            InitializeComponent();

            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text ="Logout"
            };
            ToolbarItems.Add(toolbarItem);
            toolbarItem.Clicked += (object sender, EventArgs e) => {
                
                DataBase.Instance.DeleteAccount();
                Navigation.PushModalAsync(new NavigationPage(new HomePage()));

            };

            var layout = new AbsoluteLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;

            // add title
            var title = new Label { FontSize = 20 };
            title.FontAttributes = FontAttributes.Bold;
            title.FontSize = 40;
            title.TranslationX = 19;
            title.TranslationY = 40;
            title.Text = Time.FormattedMonth(Time.CurrentTime.Month);
            title.TextColor = Color.White;
            layout.Children.Add(title);

            // add date
            Point startPoint = new Point(20, 100);
            float offsetX = 50;
            float offsetY = 55;
            int[] days = { 7, 1, 2, 3, 4, 5, 6 };
            int dayCount = 0;
            foreach (var day in days)
            {
                var label = new Label { FontSize = 20 };
                //TODO center
                label.FormattedText = Time.FormattedDay(day).ToString();
                label.TextColor = Color.FromHex("#ADD8E6");
                label.FontAttributes = FontAttributes.Bold;
                label.HorizontalOptions = LayoutOptions.Center;
                label.TranslationX = startPoint.X + offsetX * dayCount;
                label.TranslationY = startPoint.Y;
                layout.Children.Add(label);
                dayCount++;
            }

            startPoint.Y += offsetY;
            for (int i = 0; i < 31; i++)
            {
                int date = i + 1;
                var buttonDay = new Button { FontSize = 20 };
                buttonDay.Text = date.ToString();
                buttonDay.TextColor = Color.FromHex("#87CEFA");
                //buttonDay.FontAttributes = FontAttributes.Italic;
                buttonDay.TranslationX = startPoint.X + offsetX * (i % 7);
                buttonDay.TranslationY = startPoint.Y + offsetY * (i / 7);
                layout.Children.Add(buttonDay);
                buttonDay.Clicked += OnButtonDayClicked;
            }

            // add button
            var button = new Button();
            button.Text = "Add Notes";
            button.FontAttributes = FontAttributes.Italic;
            button.FontSize = 10;
            button.TextColor = Color.White;
            button.TranslationX = 240;
            button.TranslationY = 50;
            layout.Children.Add(button);
            button.Clicked += OnButtonClicked;
        }

		async void OnButtonDayClicked(object sender, System.EventArgs e)
		{
            Time.SetDay(Int32.Parse(((Button) sender).Text));
            await Navigation.PushAsync(new DayPage());
		}

        async void OnButtonClicked(object sender, System.EventArgs e){
            await Navigation.PushAsync(new NotePage());
        }
    } 
}
