using Xamarin.Forms;
using Calendar_LawrenceChu.Models;


namespace Calendar_LawrenceChu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			//MainPage = new Calendar_LawrenceChuPage();
            MainPage = new NavigationPage(new HomePage
            {
                BindingContext = new EventData()
            });
		}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
