using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HWPostSystem.Models
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://spos.uz/v1/";
        public ApiServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CheckLoginAsync(int companyCode, string username, string password)
        {
            string address = "auth/login";

            var queryParams = new Dictionary<string, string> {
                {"org", companyCode.ToString() },
                { "login", username },
                { "parol", password }
            };
            var content = new FormUrlEncodedContent(queryParams);
            var requestUri = _baseUrl + address;

            try
            {
                Trace.WriteLine($"fullUrl: {requestUri}");
                var responseMessage = await _httpClient.PostAsync(requestUri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseData = await responseMessage.Content.ReadAsStringAsync();
                    Trace.WriteLine($"responseData: {responseData}");
                    var responseDataJson = JObject.Parse(responseData); //JsonConvert.DeserializeObject<string>(responseData);
                    //var responseDataJson = JsonConvert.DeserializeObject<string>(responseData);
                    Trace.WriteLine($"responseDataJson: {responseDataJson}");

                    return true;
                }
                else
                {
                    Trace.WriteLine("IsSuccessStatusCode was false", "Login Request");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Trace.WriteLine($"Error during login: {ex.Message}");
                Console.WriteLine($"Error during login: {ex.Message}");
                return false;

            }
        }
        private string ToQueryString(Dictionary<string, string> parameters)
        {
            var array = parameters.Select(p => $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}").ToArray();
            return "?" + string.Join("&", array);
        }

        // 
        public async Task<string> GetLoginResponseAsync(string address, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri(new Uri(_baseUrl), address);
                var query = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
                var response = await client.GetAsync($"{url}?{query}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
