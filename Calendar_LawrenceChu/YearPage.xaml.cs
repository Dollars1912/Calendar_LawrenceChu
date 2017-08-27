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
            Time.CurrentTime.Year = Int32.Parse(YearLabel.Text);
		}

		async void OnMonthClicked(object sender, System.EventArgs e)
		{
            if (sender == JanButton) {
                Time.CurrentTime.Month = 1;
            } else if (sender == FebButton) {
                Time.CurrentTime.Month = 2;
            } else if (sender == MarButton) {
                Time.CurrentTime.Month = 3;
            } else if (sender == AprButton) {
				Time.CurrentTime.Month = 4;
            } else if (sender == MayButton) {
				Time.CurrentTime.Month = 5;
            } else if (sender == JunButton) {
				Time.CurrentTime.Month = 6;
            } else if (sender == JulButton) {
				Time.CurrentTime.Month = 7;
            } else if (sender == AugButton) {
				Time.CurrentTime.Month = 8;
            } else if (sender == SepButton) {
				Time.CurrentTime.Month = 9;
            } else if (sender == OctButton) {
				Time.CurrentTime.Month = 10;
            } else if (sender == NovButton) {
				Time.CurrentTime.Month = 11;
            } else if (sender == DecButton) {
				Time.CurrentTime.Month = 12;
            }
            // TODO
			await Navigation.PushAsync(new MonthPage());
		} 
    }
}
