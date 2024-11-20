using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FunDraw
{
    public class LocalStorage
    {
        static string dataPath = "./localStorage.json";
        private static string ReadStorage(string key)
        {
            try
            {
                using (StreamReader sr = new StreamReader(dataPath))
                {
                    string jsonData = sr.ReadToEnd();
                    var tokenData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                    return tokenData != null ? tokenData[key] : string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string WriteStorage(string key, string value)
        {
            try
            {
                Dictionary<string, object> jsonData;
                if (File.Exists(dataPath))
                {
                    string existingJson = File.ReadAllText(dataPath);
                    jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(existingJson) ?? new Dictionary<string, object>();
                }
                else
                {
                    jsonData = new Dictionary<string, object>();
                }
                jsonData[key] = value;
                string updatedJson = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
                File.WriteAllText(dataPath, updatedJson);

                return "success";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static string GetAccessToken()
        {
            string _accessToken = ReadStorage("accessToken");

            return _accessToken;
        }

        public static string GetRefreshToken()
        {
            string _refreshToken = ReadStorage("refreshToken");

            return _refreshToken;
        }
    }
}
