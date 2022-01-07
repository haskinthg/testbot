
using Telegram.Bot.Types;
using WebApplication1.Commands;

namespace WebApplication1.BotService
{
    public class Executor : IExecutor
    {
        private BasisCommand command;
        private readonly List<BasisCommand> listCommands;

        public Executor(IServiceProvider provider)
        {
            listCommands = provider.GetServices<BasisCommand>().ToList();
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            command = listCommands.FirstOrDefault(c => c.Name == commandName);

            await command.ExecuteAsyns(update);
        }

        public async Task Execute(Update update)
        {
            if (update.Message.Chat == null)
                return;

            await ExecuteCommand(NameCommands.StartCommand, update);

        }
    }
}
