using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
namespace API
{
    public static class GlobalVariable
    {

        public static HttpClient httpClient = new HttpClient();
        static GlobalVariable()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44375/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}