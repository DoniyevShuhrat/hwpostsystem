using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HWPostSystem.Models
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://spos.loc/v1/";
        public ApiServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CheckLoginAsync(int companyCode, string username, string password)
        {
            Trace.WriteLine("Begin CheckLoginAsync");
            
            var address = "auth/login";
            //var url = $"{_baseUrl}{address}?org={org}&login={login}&parol={parol}";

            var queryParams = new Dictionary<string, string> {
                {"org", companyCode.ToString() },
                { "login", username },
                { "parol", password }
            };
            //var loginData = new {}

            //var response = await _httpClient.GetAsync(_httpClient.BaseAddress +);
            string queryString = ToQueryString(queryParams);
            string requestUri = _baseUrl + address + queryString;
            Trace.WriteLine("Before  try");
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(requestUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Trace.WriteLine("into response");
                    // Handle the response here
                    string responseData = await responseMessage.Content.ReadAsStringAsync();
                    MessageBox.Show(responseData, "responseData");
                    // You can parse the responseData if needed
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
