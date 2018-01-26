using Autofac;
using OlmeLabs.LogAggregator.Configuration;

namespace OlmeLabs.LogAggregator.Repositories
{
    public class StorageFactory : IStorageFactory
    {
        private readonly ILifetimeScope _scope;
        private readonly IAppSettings _settings;
        public StorageFactory(ILifetimeScope scope, IAppSettings settings)
        {
            _settings = settings;
            _scope = scope;
        }

        public IStorage ResolveStorage()
        {
           return _scope.ResolveNamed<IStorage>(_settings.StorageName);
        }
    }
}