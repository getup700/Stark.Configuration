namespace Stark.Configuration.Test;

public class Tests
{
    private IConfiguration _configuration;
    [SetUp]
    public void SetUp()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("lib.json");
        _configuration = builder.Build();
    }













}