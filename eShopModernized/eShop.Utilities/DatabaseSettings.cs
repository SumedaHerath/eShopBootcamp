namespace eShop.Utilities
{
    public class DatabaseSettings
    {
        public CosmosDbSettings Cosmos { get; set; }
    }

    public sealed class CosmosDbSettings
    {
        public string CosmosUri { get; set; }
        public string DbName { get; set; }
        public string Key { get; set; }
    }
}
