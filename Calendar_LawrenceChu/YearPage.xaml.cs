using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class YearPage : ContentPage
    {
        public YearPage()
        {
            InitializeComponent();
        }

        void OnPlusOrMinusClicked(object sender, System.EventArgs e)
        {
            if (sender == PlusButton) {
				YearLabel.Text = (Int32.Parse(YearLabel.Text) + 1).ToString();
            } else if (sender == MinusButton) {
				YearLabel.Text = (Int32.Parse(YearLabel.Text) - 1).ToString();
			}
		}

		async void OnMonthClicked(object sender, System.EventArgs e)
		{
            if (sender == JanButton) {
                Date.Month = 1;
            } else if (sender == FebButton) {
                Date.Month = 2;
            }
            // TODO
			await Navigation.PushAsync(new MonthPage());
		} 
    }
}
