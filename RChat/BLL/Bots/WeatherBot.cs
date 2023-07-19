using Newtonsoft.Json.Linq;
using RChat.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RChat.BLL.Bots
{
    public class WeatherBot : BotDto
    {        
        public override MessageDto SendMessage(MessageDto messageDto)
        {
            var city = messageDto.Text.Split(' ')[1];

            string key = "31cb2a997ca715d41ee353a45317c092";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}";

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string responseBody = response.Content.ReadAsStringAsync().Result;

            JObject json = JObject.Parse(responseBody);
            double temperature = (double)json["main"]["temp"];

            return new MessageDto() { BotId = this.BotId, Date = DateTime.Now, Text = $"температура в {city} = " +
                $"{temperature - 273}", MessageId = new Guid(), ChatId = messageDto.ChatId};
        }
    }
}
