using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class MonthPage : ContentPage
    {
        public MonthPage()
        {
			InitializeComponent();

			var layout = new AbsoluteLayout { Padding = new Thickness(5, 10) };
			this.Content = layout;

            // add title
            var title = new Label { FontSize = 20 };
			title.TextColor = Color.Red;
			title.TranslationX = 100;
			title.TranslationY = 50;
            title.Text = Date.FormattedMonth();
			layout.Children.Add(title);

			// add date
			Point startPoint = new Point(20, 100);
			float offsetX = 50;
			float offsetY = 55;
			for (int i = 0; i < 31; i++)
			{
				int date = i + 1;
				var label = new Label { FontSize = 20 };
				label.FormattedText = date.ToString();
				label.TextColor = Color.Red;
				label.TranslationX = startPoint.X + offsetX * (i % 7);
				label.TranslationY = startPoint.Y + offsetY * (i / 7);
				layout.Children.Add(label);
			}

			// add button
			var button = new Button();
			button.Image = "minions.png";
			button.Text = "+";
			button.TextColor = Color.OrangeRed;
			button.TranslationX = 270;
			button.TranslationY = 20;
			layout.Children.Add(button);
		
        }
    }
}
