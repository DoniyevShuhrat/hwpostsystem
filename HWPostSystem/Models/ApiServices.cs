using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(requestUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    // Handle the response here
                    string responseData = await responseMessage.Content.ReadAsStringAsync();

                    // You can parse the responseData if needed
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine($"Error during login: {ex.Message}");
                return false;

            }
        }
        private string ToQueryString(Dictionary<string, string> parameters)
        {
            var array = parameters.Select(p => $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}").ToArray();
            return "?" + string.Join("&", array);
        }

    }
}
