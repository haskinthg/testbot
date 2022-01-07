

using Telegram.Bot;
using Telegram.Bot.Types;
using WebApplication1.BotService;

namespace WebApplication1.Commands
{
    public class StartCommand : BasisCommand
    {
        private readonly TelegramBotClient botClient;
        private readonly IUserService _userService;

        public StartCommand(Bot bot, IUserService service)
        {
            botClient = bot.GetBot().Result;
            _userService = service;
        }

        public override string Name => NameCommands.StartCommand;


        public override async Task ExecuteAsyns(Update update)
        {
            var appUser = await _userService.GetOrAdd(update);

            await botClient.SendStickerAsync(appUser.Id,
                "стартовая команда");
        }
    }
}
