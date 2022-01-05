

using Telegram.Bot;
using Telegram.Bot.Types;
using WebApplication1.BotService;

namespace WebApplication1.Commands
{
    public class StartCommand : BasisCommand
    {
        private readonly TelegramBotClient botClient;
        private readonly UserService userService;

        public StartCommand(Bot bot)
        {
            botClient = bot.GetBot().Result;
        }

        public override string Name => NameCommands.StartCommand;


        public override async Task ExecuteAsyns(Update update)
        {
            var appUser = await userService.GetOrAdd(update);
            await botClient.SendStickerAsync(appUser.Id,
                "CAACAgIAAxkBAAIKQWHUrPR_Y1RRxYzXm322rWdXYCXOAAI4CwACTuSZSzKxR9LZT4zQIwQ");
        }
    }
}
