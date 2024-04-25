using Microsoft.Extensions.DependencyInjection;

namespace Framework.Core.Messeaging
{
    public class CommandBus : ICommandBus
    {
        IServiceProvider serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler=new CommandValidatorCommandHandlerDecorator<TCommand>( serviceProvider.GetService<ICommandHandler<TCommand>>());
            if(handler!=null)
                handler.Handle(command);
           
        }
    }
}
