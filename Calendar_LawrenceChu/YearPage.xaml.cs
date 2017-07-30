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
            } else if (sender == MarButton) {
                Date.Month = 3;
            } else if (sender == AprButton) {
				Date.Month = 4;
            } else if (sender == MayButton) {
				Date.Month = 5;
            } else if (sender == JunButton) {
				Date.Month = 6;
            } else if (sender == JulButton) {
				Date.Month = 7;
            } else if (sender == AugButton) {
				Date.Month = 8;
            } else if (sender == SepButton) {
				Date.Month = 9;
            } else if (sender == OctButton) {
				Date.Month = 10;
            } else if (sender == NovButton) {
				Date.Month = 11;
            } else if (sender == DecButton) {
				Date.Month = 12;
            }
            // TODO
			await Navigation.PushAsync(new MonthPage());
		} 
    }
}
