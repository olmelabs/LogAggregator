namespace OlmeLabs.LogAggregator.Repositories
{
    public interface IStorageFactory
    {
        IStorage ResolveStorage();
    }
}