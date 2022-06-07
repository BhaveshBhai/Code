using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Client
{
    public class APIClient
    {

        private string _baseURL = string.Empty;
        private string _apiKey = string.Empty;

        public APIClient(string baseURL, string apiKey)
        {
            this._baseURL = baseURL;
            this._apiKey = apiKey;
        }

        public async Task<string> GetDataFromAPI(Object parameters)
        {
            string resultObj = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"ApiKey {this._apiKey}");
                //testing
                var result = await client.PostAsJsonAsync(this._baseURL, parameters);
                var apiResult = result;
                if (result.IsSuccessStatusCode)
                {
                    resultObj = await result.Content.ReadAsStringAsync();
                }
            }

            return resultObj;
        }
    }
}
