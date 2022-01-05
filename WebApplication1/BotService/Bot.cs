using Telegram.Bot;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.BotService
{
    public class Bot
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _bot;

        public Bot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            if (_bot != null)
                return _bot;
            _bot = new TelegramBotClient(_configuration["Token"]);

            var hook = $"{_configuration["Url"]}api/message/update";
            await _bot.SetWebhookAsync(hook);
            return _bot;
        }
    }
}
