namespace learn_dotnet.Interfaces
{
    public interface ICustomersMongoSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}