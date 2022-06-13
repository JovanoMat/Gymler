using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GymlerWPFApp
{
    internal class RestHelper
    {
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:2682/api/") };
        static JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


        


    }
}
