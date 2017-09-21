using System;
using System.Collections.Generic;
using Calendar_LawrenceChu.Models;
using Xamarin.Forms;

namespace Calendar_LawrenceChu
{
    public partial class DayPage : ContentPage
    {
        private EventPage lastEventPage;

        public DayPage()
        {
            //InitializeComponent();
            //myList();

			TableView tableView = new TableView { };
			tableView.Root = new TableRoot();
			TableSection tableSection = new TableSection("Events");
			tableView.Root.Add(tableSection);

			// Add create event button
            StackLayout staticStackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(13, 0) };
            Button createEventButton = new Button { Text = "Add a new Event" };
            createEventButton.Clicked += OnCreateEventButtonClicked;
            staticStackLayout.Children.Add(createEventButton);
			tableSection.Add(new ViewCell { View = staticStackLayout });
            // Add 24 hours
            for (int hour = 0; hour < 24; hour++) {
				StackLayout stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(13, 0) };
                Label hourLabel = new Label { Text = string.Format("{00}:00", hour), VerticalOptions = LayoutOptions.Center };

				stackLayout.Children.Add(hourLabel);
                // Add events

                List<Event> userEvents = User.CurrentUser.Events;
                for (int j = 0; j < userEvents.Count; j++)
                {
                    if (userEvents[j].StartTime().Year == Time.CurrentTime.Year
                        && userEvents[j].StartTime().Month == Time.CurrentTime.Month
                        && userEvents[j].StartTime().Day == Time.CurrentTime.Day)
                    {
                        if (userEvents[j].StartTime().Hour <= hour
                            && userEvents[j].EndTime().Hour >= hour
                           ) 
                        {
							stackLayout.Children.Add(AddEvent(userEvents[j]));
						}
					}
                }

                ViewCell cell = new ViewCell { View = stackLayout };
				tableSection.Add(cell);
            }

			this.Content = new StackLayout
			{
				Children = {
			        tableView
		        }
			};
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (lastEventPage != null)
                Navigation.RemovePage(lastEventPage);
        }

		async void OnCreateEventButtonClicked(object sender, System.EventArgs e)
		{
			var newPage = new EventPage(null);
			await Navigation.PushAsync(newPage);
		}

        private BoxView AddEvent(Event eve) {
            BoxView eventRect = new BoxView { Color = Color.FromHex("#45B39D"), WidthRequest = 65 };
			var onClick = new TapGestureRecognizer();
			onClick.Tapped += (sender, e) =>
			{
				lastEventPage = new EventPage(eve);
				Navigation.PushAsync(lastEventPage);
		    };
			eventRect.GestureRecognizers.Add(onClick);
            return eventRect;
		}
    }
}
