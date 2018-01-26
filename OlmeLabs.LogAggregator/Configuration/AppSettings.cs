using System.Configuration;

namespace OlmeLabs.LogAggregator.Configuration
{
    public class AppSettings : IAppSettings
    {
        public string StorageName => ConfigurationManager.AppSettings["StorageName"];

        public string MongoConnectString => ConfigurationManager.AppSettings["MongoConnectString"];

        public string MongDbName => ConfigurationManager.AppSettings["MongDbName"];

        public string FileSystemStoragePath => ConfigurationManager.AppSettings["FileSystemStoragePath"];

        public int PageSize => GetIntOrDefault(ConfigurationManager.AppSettings["PageSize"], 10);

        private int GetIntOrDefault(string val, int def)
        {
            int i;
            bool res = int.TryParse(val, out i);
            return res ? i : def;
        }
    }
}