using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDraw
{
    public class Session
    {   
        public Session() {
            accessToken = LocalStorage.GetAccessToken();
            refreshToken = LocalStorage.GetRefreshToken();
        }
        public static string accessToken { get; set; } = "";
        public static string refreshToken { get; set; } = "";

        public async Task Login(string username, string password)
        {
            var userCredentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            JObject response = await HTTPClient.PostFormUrlEncodedAsync(AppConfig.APP_API_HOST, userCredentials);
            
        }
    }
}
