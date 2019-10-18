using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System.Web;

namespace ProjectManagerUI.ViewModels
{
    public class ApiManager
    {
        private string _baseUrl = "";
        private HttpClient http;

        public ApiManager(string baseurl)
        {
            this._baseUrl = baseurl;
            http = new HttpClient();
            http.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<string> DisplayTaskAsync()
        {
            string ResponseContent = string.Empty;
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await http.GetAsync("api/ProjectApi");
            if (Response.IsSuccessStatusCode)
            {
                ResponseContent = await Response.Content.ReadAsStringAsync();
            }
            return ResponseContent;
        }
    }
}