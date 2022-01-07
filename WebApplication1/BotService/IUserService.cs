using Telegram.Bot.Types;
using WebApplication1.Entities;

namespace WebApplication1.BotService
{
    public interface IUserService
    {
        Task<AppUser> GetOrAdd(Update update);
    }
}
