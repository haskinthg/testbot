using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebApplication1.BotService;
using WebApplication1.Commands;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route(template: "api/message/update")]
    public class MessageController : ControllerBase
    {
        private IExecutor _executor;

        public MessageController(IExecutor executor)
        {
            _executor = executor;
            
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] object update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());

            if (upd?.Message?.Chat == null)
                return Ok();
            try
            {
                await _executor.Execute(upd);
            }
            catch (Exception ex)
            {
                return Ok();
            }

            return Ok();
        }

    }
}
