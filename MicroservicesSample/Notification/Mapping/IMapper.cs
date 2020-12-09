namespace Notification.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}