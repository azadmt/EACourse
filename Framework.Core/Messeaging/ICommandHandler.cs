namespace Framework.Core.Messeaging
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public class CommandValidatorCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        ICommandHandler<TCommand> commandHandler;

        public CommandValidatorCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public void Handle(TCommand command)
        {
            if (!command.Validate())
                throw new Exception("command is not valid to execute!!!");
            commandHandler.Handle(command); 
        }
    }
}
