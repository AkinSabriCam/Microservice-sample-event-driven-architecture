using Mapster;

namespace Notification.Mapping
{
    public class MapsterMapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>();
        }   
    }
}