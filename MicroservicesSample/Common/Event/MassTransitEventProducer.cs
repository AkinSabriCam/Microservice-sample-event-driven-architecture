using System.Threading.Tasks;
using MassTransit;

namespace Common.Event
{
    public class MassTransitEventProducer : IMassTransitEventProducer
    {
        private readonly IBusControl _bus;

        public MassTransitEventProducer(IBusControl bus)
        {
            _bus = bus;
        }

        public Task Publish<TEvent>(TEvent @event) where TEvent : class, IUserEvent
        {
            return _bus.Publish(@event, @event.GetType());
        }
    }
}