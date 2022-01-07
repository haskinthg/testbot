using Telegram.Bot.Types;

namespace WebApplication1.BotService
{
    public interface IExecutor
    {
        Task Execute(Update update);
    }
}
