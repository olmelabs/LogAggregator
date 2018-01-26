namespace OlmeLabs.LogAggregator.Configuration
{
    public interface IAppSettings
    {
        string StorageName { get; }
        string MongoConnectString { get; }
        string MongDbName { get; }
        string FileSystemStoragePath { get; }
        int PageSize { get; }
    }
}