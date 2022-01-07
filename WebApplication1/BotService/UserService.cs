using System.Data.Entity;
using Telegram.Bot.Types;
using WebApplication1.Entities;

namespace WebApplication1.BotService
{
    public class UserService : IUserService
    {

        private readonly DataContext _context = new DataContext();

        public async Task<AppUser> GetOrAdd(Update update)
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
                {
                    var user = await connection.Users.FirstOrDefaultAsync(u => u.ChatID == appUser.ChatID);
                    var result = await connection.Users.AddAsync(appUser);
                    await connection.SaveChangesAsync();
                    return result.Entity;
                }

                /*
                var user = await connection.Users.FirstOrDefaultAsync(temp => temp.Id == chat.Id);
                if (user != null) return user;
                var result = await connection.Users.AddAsync(appUser); 
                await connection.SaveChangesAsync();
                return result.Entity;
                */
            }

          
            await _context.SaveChangesAsync();
            return appUser;

        }
    }
}
