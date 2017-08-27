using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, System.EventArgs e)
        {
            MainLabel.Text = "Well Done!";
        }
    }
}
