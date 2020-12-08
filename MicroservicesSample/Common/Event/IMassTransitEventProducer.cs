using System.Threading.Tasks;

namespace Common.Event
{
    public interface IMassTransitEventProducer
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : class, IUserEvent;
    }
}