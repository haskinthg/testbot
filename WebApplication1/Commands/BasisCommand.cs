using Telegram.Bot.Types;

namespace WebApplication1.Commands
{
    public abstract class BasisCommand
    {
        public abstract string Name { get; }
        public abstract Task ExecuteAsyns(Update update);
    }
}
