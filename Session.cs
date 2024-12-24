using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunDraw.Types;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FunDraw
{
    public class Session
    {
        public Session()
        {
            accessToken = LocalStorage.GetAccessToken();
        }
        public static string accessToken { get; set; } = "";
        public static string username { get; set; } = "";

        public static async Task<bool> Login(string username, string password)
        {
            var userCredentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/auth/login", userCredentials);
            if (response.ContainsKey("error")) return false;
            var data = JsonConvert.DeserializeObject<Types.Login>(response.ToString());
            if (data?.data?.accessToken != null)
            {
                Session.accessToken = data.data.accessToken;
                Session.username = data.data.user.username;
                LocalStorage.SetAccessToken(data.data.accessToken);
                return true;
            }
            return false;
        }

        public static async Task<bool> Logout()
        {
            string accessToken = LocalStorage.GetAccessToken();
            JObject response = await HTTPClient.PostAsync($"{AppConfig.APP_API_HOST}/auth/logout", $"accessToken={accessToken}");
            LocalStorage.SetAccessToken(string.Empty);
            if (Gateway.socketState)
            {
                Gateway.Instance.Disconnect();
            }
            if (response.ContainsKey("error")) return false;
            return true;
        }

        public static async Task<bool> Register(string username, string password, string email)
        {
            var userCredentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password },
                { "confirm_password", password },
                { "email", email }
            };

            JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/auth/register", userCredentials);
            return !response.ContainsKey("error");
        }

        public static async Task<bool> RefreshTokenForFeature(string path, Dictionary<string, string> requestData)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
               { "Authorization", $"Bearer {accessToken}" }
            };
            try
            {
                JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}{path}", requestData, headers);

                int retryCount = 0;
                const int maxRetries = 3;

                while (response.ContainsKey("error") && retryCount < maxRetries)
                {
                    // await RefreshToken();

                    headers["Authorization"] = $"Bearer {accessToken}";
                    response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}{path}", requestData, headers);

                    retryCount++;
                }

                if (response.ContainsKey("error"))
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while refreshing the access token for feature: " + ex.Message);
                return false;
            }
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

        public static async Task<bool> ChangePassword(string new_pass)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                   { "Authorization", $"Bearer {accessToken}" }
                };
                var requestData = new Dictionary<string, string>
                {
                   { "password", new_pass },
                   { "confirm_password", new_pass }
                };

                JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/users/change-password", requestData, headers);
                if (!response.ContainsKey("error"))
                {
                    Debug.WriteLine("Changed Password Successfully");
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static async Task<bool> ForgotPassword(string email)
        {
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "email", email }
                };

                JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/users/reset-password", requestData);

                if (response.ContainsKey("error"))
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

        public static async Task<bool> PasswordOTP(string email, string otp, string password, string confirm_password)
        {
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "email", email },
                    { "otp", otp },
                    { "password", password },
                    { "confirm_password", confirm_password }
                };

                JObject response = await HTTPClient.PostFormUrlEncodedAsync($"{AppConfig.APP_API_HOST}/users/reset-otp", requestData);

                if (response.ContainsKey("error"))
                {
                    return false;
                }

                Debug.WriteLine("Successfully changed user password!");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static async Task<Types.UserProfile> GetUserProfile()
        {
            string accessToken = LocalStorage.GetAccessToken();
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken}" }
            };

            JObject response = await HTTPClient.GetAsync($"{AppConfig.APP_API_HOST}/users/profile", "", headers);

            if (response.ContainsKey("error"))
            {
                return null;
            }
            UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(response["data"].ToString());
            return profile;
        }
    }
}