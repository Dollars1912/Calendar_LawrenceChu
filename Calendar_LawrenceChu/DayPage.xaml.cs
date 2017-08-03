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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MainLabel.Text = "Well Done!";
        }
    }
}
