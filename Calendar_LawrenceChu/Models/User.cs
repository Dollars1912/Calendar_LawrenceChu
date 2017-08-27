using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Calendar_LawrenceChu
{
    public class User
    {
        private const string ServerRoute = "http://introtoapps.com/datastore.php";

        private static User currentUser = null;

        public static User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

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

        public async Task<bool> Login() {
            var result = await FetchUsersFromServer();
            if (!result) {
                return false;
            }
            return true;
        }

        public async Task<bool> FetchUsersFromServer()
        {
            var uriString = string.Format("http://introtoapps.com/datastore.php?action=load&appid=215194361&objectid={0}_account", Username.ToLower());
            var uri = new Uri(uriString);
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(content);
                var result = this.Password == user.Password;
                if (result) {
                    currentUser = user;
                }
                return result;
            }
            return false;
        }

        public async void PushToServer() {
            var json = JsonConvert.SerializeObject(this);
            var uriString = string.Format("http://introtoapps.com/datastore.php?action=save&appid=215194361&objectid={0}_account", Username.ToLower());
			var uri = new Uri(uriString);
			var client = new HttpClient();
			var pairs = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("data", json)
			};
			var content = new FormUrlEncodedContent(pairs);
            var response = await client.PostAsync(uri, content);
        }
    }
}
