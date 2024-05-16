namespace Framework.Core.Messeaging
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event);
    }
}