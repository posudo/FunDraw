using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FunDraw
{
    public class HTTPClient
    {
        private static readonly Lazy<HttpClient> _httpClientInstance = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient();
            // client.DefaultRequestHeaders.Add("X-Custom-Header", "MyCustomValue");
            return client;
        });

        public static HttpClient Instance => _httpClientInstance.Value;

        public static async Task<JObject> GetAsync(string url, string queryParams = "", Dictionary<string, string>? headers)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await Instance.GetAsync($"{url}?{queryParams}");
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JObject>(content) ?? new JObject() { ["Error"] = "Request response content return null"};
            }
            catch (Exception ex)
            {
                return new JObject { ["Error"] = ex.Message };
            }
        }

        public static async Task<JObject> PostFormUrlEncodedAsync(string url, Dictionary<string, string> formData, Dictionary<string, string>? headers = null)
        {
            try
            {
                var content = new FormUrlEncodedContent(formData);
                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await Instance.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string resContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JObject>(resContent) ?? new JObject() { ["Error"] = "Request response content return null" };
            }
            catch (Exception ex)
            {
                return new JObject { ["Error"] = ex.Message };
            }
        }
    }
}
