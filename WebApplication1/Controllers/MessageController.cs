using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebApplication1.BotService;
using WebApplication1.Commands;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route(template: "api/message/update")]
    public class MessageController : ControllerBase
    {
        private readonly TelegramBotClient _botClient;
        private readonly DataContext _dataContext = new DataContext();
        

        public MessageController(Bot bot, StartCommand start)
        {
            _botClient = bot.GetBot().Result;
            

        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] object update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            var chat = upd?.Message?.Chat;

            if (chat == null)
                return Ok();

            

            //await command.ExecuteAsyns(upd);

            await _botClient.SendTextMessageAsync(chat.Id, "kkkk");


            return Ok();
        }

    }
}
