using Loggi.NetSDK;
using Microsoft.Extensions.Configuration;

namespace LoggiTests;

public class Tests
{
    private LoggiClient _loggiClient;

    [SetUp]
    public void Setup()
    {
        // Config from AppSettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(System.AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

        var config = builder.Build();

        var lastFm = config.GetSection("Loggi");
        var lastFmConfig = new LoggiConfig()
        {
            ClientId = lastFm["ClientId"]!,
            ClientSecret = lastFm["ClientSecret"]!
        };
        
        
        _loggiClient = new LoggiClient("", "");
    }

    [Test]
    public void TestSerializeErrorResponse()
    {
        var filePath = @"C:\Users\julio\OneDrive\Área de Trabalho\Loggi\ErrorResponse.json";
        var jsonString = File.ReadAllText(filePath);

        var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonString);

        Assert.That(errorResponse, Is.Not.Null);
        Assert.That(errorResponse.Code, Is.EqualTo(EnumErrorCode.InvalidArgument));
    }

    [Test]
    public async Task TestGetToken()
    {
        var data = await _loggiClient.GetToken();
        
        Assert.That(data.Error, Is.Null);
    }
}