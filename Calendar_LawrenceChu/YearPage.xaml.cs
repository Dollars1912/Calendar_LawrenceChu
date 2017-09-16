using System;
using System.Collections.Generic;
using Calendar_LawrenceChu.Models;
using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class YearPage : ContentPage
    {
        public YearPage()
        {
            Time.SetYear(2017);
            InitializeComponent();
        }

        void OnPlusOrMinusClicked(object sender, System.EventArgs e)
        {
            if (sender == PlusButton) {
				YearLabel.Text = (Int32.Parse(YearLabel.Text) + 1).ToString();
            } else if (sender == MinusButton) {
				YearLabel.Text = (Int32.Parse(YearLabel.Text) - 1).ToString();
			}
            Time.SetYear(Int32.Parse(YearLabel.Text));
		}

		async void OnMonthClicked(object sender, System.EventArgs e)
		{
            int month = 0;
            if (sender == JanButton) {
                month  = 1;
            } else if (sender == FebButton) {
                month = 2;
            } else if (sender == MarButton) {
                month = 3;
            } else if (sender == AprButton) {
				month = 4;
            } else if (sender == MayButton) {
				month = 5;
            } else if (sender == JunButton) {
				month = 6;
            } else if (sender == JulButton) {
				month = 7;
            } else if (sender == AugButton) {
				month = 8;
            } else if (sender == SepButton) {
				month = 9;
            } else if (sender == OctButton) {
				month = 10;
            } else if (sender == NovButton) {
				month = 11;
            } else if (sender == DecButton) {
				month = 12;
            }
            Time.SetMonth(month);
			await Navigation.PushAsync(new MonthPage());
		} 
    }
}
