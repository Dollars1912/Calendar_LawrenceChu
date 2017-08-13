using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar_LawrenceChu
{
    public class User
    {
        private const string ServerRoute = "http://introtoapps.com/datastore.php";

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public User()
        {
            this.Username = "";
            this.Password = "";
        }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public async Task<List<User>> RefreshDataAsync()
        {
            var json = JsonConvert.SerializeObject(this);
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems/
            var uri = new Uri("http://introtoapps.com/datastore.php?action=load&appid=215194361&objectid=user");
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);
                return users;
            }
            return null;
        }
    }
}
