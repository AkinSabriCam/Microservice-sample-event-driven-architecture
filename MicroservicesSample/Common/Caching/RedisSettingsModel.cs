namespace Common.Caching
{
    public class RedisSettingsModel
    {
        public string EndPoint { get; set; }
        public string Password { get; set; }
        public int DefaultDatabase { get; set; }
        public int SyncTimeout { get; set; }
        public int ConnectTimeout { get; set; }
    }
}