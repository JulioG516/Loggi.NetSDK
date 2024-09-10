using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Loggi.NetSDK;
using Loggi.NetSDK.Models.Shipments;
using Loggi.NetSDK.Models.Shipments.AddressTypes;
using Loggi.NetSDK.Models.Shipments.DocumentTypes;
using Microsoft.Extensions.Configuration;

namespace LoggiTests;

public class Tests
{
    private LoggiClient _loggiClient;

    private JsonSerializerOptions _serializerOptions;

    [SetUp]
    public void Setup()
    {
        // Config from AppSettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
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


        _loggiClient = new LoggiClient(lastFmConfig.ClientId,  lastFmConfig.ClientSecret);

        _serializerOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    [Test]
    public async Task TestUnauthenticatedClient()
    {
        var emptyClient = new LoggiClient("", "");

        var response = await emptyClient.GetToken();

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Data, Is.Null);
        Assert.That(response.Error.Code, Is.EqualTo(EnumErrorCode.Unauthenticated));
        TestContext.WriteLine(response);
    }

    [Test]
    public async Task TestGetToken()
    {
        var data = await _loggiClient.GetToken();

        Assert.That(data.Error, Is.Null);
    }

    [Test]
    public void TestPackageDocumentTypeSerialization()
    {
        var shipment = new Shipment()
        {
            Packages = new List<Package>()
            {
                new Package()
                {
                    DocumentTypes = new List<IDocumentType>
                    {
                        new InvoiceDocumentType
                        {
                            Invoice = new Invoice
                            {
                                Key = "12345678901234567890123456789012345678901234",
                                Series = "001",
                                Number = "123456789",
                                TotalValue = "1000",
                                Icms = IcmsTypes.IcmsFree
                            }
                        },
                        new ContentDeclarationDocumentType
                        {
                            ContentDeclaration = new ContentDeclaration
                            {
                                TotalValue = "500",
                                Description = "Sample Description"
                            }
                        }
                    }
                }
            }
        };


        var json = JsonSerializer.Serialize(shipment, _serializerOptions);
        Assert.IsNotNull(json);
        Assert.IsNotEmpty(json);
        TestContext.WriteLine(json);
    }

    [Test]
    public void TestAddressSerialization()
    {
        var shipFrom = new ShipFrom()
        {
            Name = "José dos Santos",
            PhoneNumber = "55119999999999",
            FederalTaxId = "23742246000134",
            Address = new CorreiosAddressType()
            {
                Instrunctions = "Prédio da Loggi.",
                CorreiosAddress = new CorreiosAddress()
                {
                    Logradouro = "R. Liberdade",
                    Numero = "2400",
                    Complemento = "apto 42, em frente ao lava-jato",
                    Bairro = "Bonsucesso",
                    Cep = "30622580",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                }
            }
        };


        var json = JsonSerializer.Serialize(shipFrom, _serializerOptions);
        Assert.IsNotNull(json);
        Assert.IsNotEmpty(json);
        TestContext.WriteLine(json);
    }
}