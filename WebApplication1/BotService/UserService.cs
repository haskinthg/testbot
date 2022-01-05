using Telegram.Bot.Types;
using WebApplication1.Entities;

namespace WebApplication1.BotService
{
    public class UserService
    {

        private readonly DataContext _context = new DataContext();

        public async Task<AppUser> GetOrAdd (Update update)
        {
            var chat = update.Message.Chat;
            var appUser = new AppUser()
            {
                UserName = chat.Username,
                ChatID = chat.Id,
                FirstName = chat.FirstName,
                LastName = chat.LastName
            };

            using (var connection = new DataContext())
            {

                if (!(connection.Users.Any(u => u.ChatID == appUser.ChatID)))
                    connection.Users.AddAsync(appUser);
                else connection.Users.Update(appUser);
                await connection.SaveChangesAsync();
            }

            return appUser;     
        }
    }
}
