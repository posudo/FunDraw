using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FunDraw
{
    public class HTTPClient
    {
        private static readonly Lazy<HttpClient> _httpClientInstance = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
            return client;
        });

        public static HttpClient Instance => _httpClientInstance.Value;

        private static async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
        {
            HttpResponseMessage response = await Instance.SendAsync(request);

            return response;
        }

        public static async Task<JObject> GetAsync(string url, string? queryParams = "", Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?{queryParams}");

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await SendRequestAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JObject>(content) ?? new JObject() { ["Error"] = "Request response content return null" };
            }
            catch (Exception ex)
            {
                return new JObject { ["Error"] = ex.Message };
            }
        }

        public static async Task<JObject> PostAsync(string url, string? queryParams = "", Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{url}?{queryParams}");

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await SendRequestAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JObject>(content) ?? new JObject() { ["Error"] = "Request response content return null" };
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
