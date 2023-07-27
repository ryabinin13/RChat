using Microsoft.Extensions.Hosting;
using RChat.BLL.Bots;
using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
using RChat.DAL.Interfaces;
using RChat.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RChat.BLL.Managers
{
    public class BotManager : BackgroundService, IBotManager
    {
        private Queue<MessageDto> messages;
        public List<BotDto> Bots { get; set; }

        //TODO ошибка singelton не может зависеть от transient
        private IBotService botService;
        public BotManager(IBotService _botService)
        {
            messages = new Queue<MessageDto>();
            botService = _botService;
            WeatherBot weatherBot = new WeatherBot();
            FactBot factBot = new FactBot();
            Bots = new List<BotDto>() { weatherBot, factBot };
        }
        public void AddMessages(MessageDto messageDto)
        {
            messages.Enqueue(messageDto);
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (messages.Count > 0)
                {
                    var messageDto = messages.Dequeue();

                    foreach (var bot in Bots)
                    {
                        if (messageDto.Text.Split(' ')[0] == bot.Name)
                        {
                            var message = bot.SendMessage(messageDto);
                            botService.SendMessage(message);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
