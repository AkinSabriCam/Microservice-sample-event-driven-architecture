using System.Threading.Tasks;

namespace Common.Event
{
    public interface IEventHandler<TEvent> where TEvent : IUserEvent
    {
        Task Handle(TEvent @event);
    }
}