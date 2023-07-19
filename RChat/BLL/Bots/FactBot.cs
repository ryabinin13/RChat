using RChat.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RChat.BLL.Bots
{
    public class FactBot : BotDto
    {
        public override MessageDto SendMessage(MessageDto messageDto)
        {
            var number = messageDto.Text.Split(' ')[1];

            HttpClient httpClient = new HttpClient();

            string url = $"http://numbersapi.com/{number}";

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string fact = response.Content.ReadAsStringAsync().Result;

            return new MessageDto() { BotId = this.BotId, Date = DateTime.Now, Text = fact, MessageId = new Guid(), ChatId = messageDto.ChatId };
        }
    }
}
