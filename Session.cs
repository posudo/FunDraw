using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunDraw.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FunDraw
{
    public class Session
    {
        public Session()
        {
            accessToken = LocalStorage.GetAccessToken();
            refreshToken = LocalStorage.GetRefreshToken();
        }
        public static string accessToken { get; set; } = "";
        public static string refreshToken { get; set; } = "";

        public static async Task Login(string username, string password)
        {
            var userCredentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/auth/login", userCredentials);
            if (response.ContainsKey("Error")) return;
            var data = JsonConvert.DeserializeObject<Types.Login>(response.ToString());
            LocalStorage.SetAccessToken(data.data.accessToken);
            LocalStorage.SetRefreshToken(data.data.refreshToken);
        }

        public static async Task Register(string username, string password, string email)
        {
            var userCredentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/auth/login", userCredentials);
        }

        public static async Task RefreshToken()
        {
            string refreshToken = LocalStorage.GetRefreshToken();
            JObject response = await HTTPClient.PostAsync($"{AppConfig.APP_API_HOST}/auth/refresh-token", $"refreshToken={refreshToken}");
            if (response.ContainsKey("Error")) return;
            var data = JsonConvert.DeserializeObject<Types.Login>(response.ToString());
            LocalStorage.SetAccessToken(data.data.accessToken);
            LocalStorage.SetRefreshToken(data.data.refreshToken);
        }

        public static async Task<JObject> GET(string path, string? queryParams = "")
        {
            string accessToken = LocalStorage.GetAccessToken();
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken}" }
            };
            JObject response = await HTTPClient.GetAsync($"{AppConfig.APP_API_HOST}/{path}", queryParams, headers);
            return response;
        }
        public static async Task<bool> ForgotPassword(string email)
        {
            try
            {
                var requestData = new Dictionary<string,string>
                {
                { "email", email },
                };

                JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/users/reset-password", requestData);

                if (response.ContainsKey("message") && response["message"].ToString() == "User not found!")
                {
                    return false;
                }
                       
                Debug.WriteLine("Forgot Password Email Sent Successfully");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
