using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RChat.BLL.Services
{
    public static class BotService
    {
        public static double GetWeather(string city)
        {
            string key = "31cb2a997ca715d41ee353a45317c092";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}";

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string responseBody = response.Content.ReadAsStringAsync().Result;

            JObject json = JObject.Parse(responseBody);
            double temperature = (double)json["main"]["temp"];

            return temperature;
        }
    }
}
