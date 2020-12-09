using Mapster;

namespace Notification.Mapping
{
    public class MapsterProfile
    {
        public void Configure()
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

        }
    }
}