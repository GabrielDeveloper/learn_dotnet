using learn_dotnet.Interfaces;

namespace learn_dotnet.Models
{
    public class CustomersMongoSettings : ICustomersMongoSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}