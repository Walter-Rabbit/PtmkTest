namespace PtmkTest.Repositories;

public class Configuration
{
    public Configuration(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    public string ConnectionString { get; set; }
}