using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Loggi.NetSDK;
using Loggi.NetSDK.Models.Addresses;
using Loggi.NetSDK.Models.Shipments;
using Loggi.NetSDK.Models.Shipments.AddressTypes;
using Loggi.NetSDK.Models.Shipments.DocumentTypes;
using Loggi.NetSDK.Models.Shipments.ShipmentBuilder;
using Microsoft.Extensions.Configuration;

namespace LoggiTests;

public class Tests
{
    private LoggiClient _loggiClient;

    private JsonSerializerOptions _serializerOptions;

    private LoggiConfig _loggiConfig;


    [SetUp]
    public async Task Setup()
    {
        // Config from AppSettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

        var config = builder.Build();

        var loggiSection = config.GetSection("Loggi");

        _loggiConfig = new LoggiConfig()
        {
            ClientId = loggiSection["ClientId"]!,
            ClientSecret = loggiSection["ClientSecret"]!,
            CompanyId = loggiSection["CompanyId"]!
        };

        _loggiClient = new LoggiClient(_loggiConfig.CompanyId);

        await _loggiClient.AuthenticateAsync(_loggiConfig.ClientId, _loggiConfig.ClientSecret);

        _serializerOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }


    [Test]
    public void TestUnauthenticatedClient()
    {
        var emptyClient = new LoggiClient("");
        Assert.ThrowsAsync<ArgumentNullException>(async () => { await emptyClient.AuthenticateAsync("", ""); });
    }

    [Test]
    public void TestInvalidAuthenticationWithEmptyValues()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _loggiClient.AuthenticateAsync("", ""));
    }

    [Test]
    public async Task TestInvalidAuthenticationAnythingValue()
    {
        var response = await _loggiClient.AuthenticateAsync("asddsadsag", "fhghgfhfg");

        Assert.That(response.Error, Is.Not.Null);
    }

    [Test]
    public async Task TestSuccessfullyAuthentication()
    {
        var data = await _loggiClient.AuthenticateAsync(_loggiConfig.ClientId, _loggiConfig.ClientSecret);

        Assert.That(data.Error, Is.Null);
        TestContext.WriteLine(data);
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
                                Icms = IcmsTypes.Free
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

    [Test]
    public void TestInvalidBuilder()
    {
        var shipmentBuilder = new ShipmentBuilder();
        shipmentBuilder = shipmentBuilder.SetShipFrom(new ShipFrom()
        {
            Name = "Jose dos Santos Alvarenga",
            PhoneNumber = "55119999999999",
            FederalTaxId = "12345678909",
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
        });

        // Assert that an InvalidOperationException is thrown
        Assert.Throws<InvalidOperationException>(() => shipmentBuilder.Build());
    }

    [Test]
    public void TestValidBuilder()
    {
        var shipmentBuilder = new ShipmentBuilder();
        var shipment = shipmentBuilder.SetShipFrom(new ShipFrom()
        {
            Name = "Jose dos Santos Alvarenga",
            PhoneNumber = "55119999999999",
            FederalTaxId = "12345678909",
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
        }).SetShipTo(new ShipTo()
        {
            Name = "Jose dos Santos Alvarenga",
            Email = "jose.alvarenga@email.com",
            PhoneNumber = "351911169807",
            FederalTaxId = "23742246000134",
            StateTaxId = "123233578",
            Address = new LineAddressType()
            {
                Instrunctions = "Próximo ao posto.",
                LineAddress = new LineAddress()
                {
                    AddressLine1 = "Alameda Santos, 2400 - Jardim Paulista, São Paulo, Brasil",
                    AddressLine2 = "Alameda Santos, 2800 - Jardim Paulista, São Paulo, Brasil",
                    PostalCode = "1418200",
                    City = "São Paulo",
                    State = "São Paulo",
                    Country = "Brasil"
                }
            }
        }).AddPackage(new Package()
        {
            WeightG = 250,
            LengthCm = 50,
            WidthCm = 50,
            HeightCm = 25,
            DocumentTypes = new List<IDocumentType>()
            {
                new InvoiceDocumentType()
                {
                    Invoice = new Invoice()
                    {
                        Key = "35200920402853000167550100000013071406204048",
                        Series = "10",
                        Number = "1306",
                        TotalValue = "844.82"
                    }
                }
            }
        }).Build();

        Assert.That(shipment, Is.Not.Null);
    }


    [Test]
    [Ignore(reason: "Para não criar diversos shipments enviando a loggi.")]
    public async Task TestSendValidShipment()
    {
        var shipmentBuilder = new ShipmentBuilder();
        var shipment = shipmentBuilder.SetShipFrom(new ShipFrom()
        {
            Name = "Jose dos Santos Alvarenga",
            PhoneNumber = "55119999999999",
            FederalTaxId = "12345678909",
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
        }).SetShipTo(new ShipTo()
        {
            Name = "Jose dos Santos Alvarenga",
            Email = "jose.alvarenga@email.com",
            PhoneNumber = "351911169807",
            FederalTaxId = "23742246000134",
            StateTaxId = "123233578",
            Address = new LineAddressType()
            {
                Instrunctions = "Próximo ao posto.",
                LineAddress = new LineAddress()
                {
                    AddressLine1 = "Alameda Santos, 2400 - Jardim Paulista, São Paulo, Brasil",
                    AddressLine2 = "Alameda Santos, 2800 - Jardim Paulista, São Paulo, Brasil",
                    PostalCode = "14182000",
                    City = "São Paulo",
                    State = "São Paulo",
                    Country = "Brasil"
                }
            }
        }).AddPackage(new Package()
        {
            WeightG = 250,
            LengthCm = 50,
            WidthCm = 50,
            HeightCm = 25,
            DocumentTypes = new List<IDocumentType>()
            {
                new InvoiceDocumentType()
                {
                    Invoice = new Invoice()
                    {
                        Key = "35200920402853000167550100000013071406204048",
                        Series = "10",
                        Number = "1306",
                        TotalValue = "844.82"
                    }
                }
            }
        }).Build();

        var json = JsonSerializer.Serialize(shipment, _serializerOptions);
        TestContext.WriteLine(json);


        var response = await _loggiClient.CriarShipmentAsync(shipment);


        Assert.That(shipment, Is.Not.Null);
        Assert.That(response.Error, Is.Null);
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Packages, Is.Not.Zero);
    }

    [Test]
    [Ignore(reason: "Para não criar diversos shipments enviando a loggi.")]
    public async Task TestSendInvalidShipment()
    {
        // Sends with an empty ShipFrom 
        var shipmentBuilder = new ShipmentBuilder();
        var shipment = shipmentBuilder.SetShipFrom(new ShipFrom())
            .SetShipTo(new ShipTo()
            {
                Name = "Jose dos Santos Alvarenga",
                Email = "jose.alvarenga@email.com",
                PhoneNumber = "351911169807",
                FederalTaxId = "23742246000134",
                StateTaxId = "123233578",
                Address = new LineAddressType()
                {
                    Instrunctions = "Próximo ao posto.",
                    LineAddress = new LineAddress()
                    {
                        AddressLine1 = "Alameda Santos, 2400 - Jardim Paulista, São Paulo, Brasil",
                        AddressLine2 = "Alameda Santos, 2800 - Jardim Paulista, São Paulo, Brasil",
                        PostalCode = "14182000",
                        City = "São Paulo",
                        State = "São Paulo",
                        Country = "Brasil"
                    }
                }
            }).AddPackage(new Package()
            {
                WeightG = 250,
                LengthCm = 50,
                WidthCm = 50,
                HeightCm = 25,
                DocumentTypes = new List<IDocumentType>()
                {
                    new InvoiceDocumentType()
                    {
                        Invoice = new Invoice()
                        {
                            Key = "35200920402853000167550100000013071406204048",
                            Series = "10",
                            Number = "1306",
                            TotalValue = "844.82"
                        }
                    }
                }
            }).Build();

        var json = JsonSerializer.Serialize(shipment, _serializerOptions);
        TestContext.WriteLine(json);

        var response = await _loggiClient.CriarShipmentAsync(shipment);
        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(EnumErrorCode.FailedPrecondition));
    }

    [Test]
    public void TestInvalidRastrearPacote()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _loggiClient.RastrearPacote(""));
    }

    [Test]
    public async Task TestRastrearPacote()
    {
        var response = await _loggiClient.RastrearPacote("R021125001546");

        Assert.That(response.Error, Is.Null);
        Assert.That(response.Data.Packages, Is.Not.Zero);
    }

    [Test]
    public async Task TestRastrearPacoteDetalhado()
    {
        var response = await _loggiClient.RastrearPacoteDetalhado("R021125001546");

        Assert.That(response.Error, Is.Null);
        Assert.That(response.Data.Packages, Is.Not.Zero);
    }

    # region Etiquetas

    [Test]
    public async Task TestCriarUmaEtiqueta()
    {
        var response = await _loggiClient.CriarEtiqueta("MVTTG2LG3TXAOY3DASIM3WQZT4");

        Assert.That(response.Error, Is.Null);
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Success, Is.Not.Null);
    }

    [Test]
    public async Task TestCriaEtiquetasComErro()
    {
        var response = await _loggiClient.CriarEtiqueta(new List<string>
        {
            "MVTTG2LG3TXAOY3DASIM3WQZT4", "MVTTG2LG3TXAOY3DASIM3WQ234",
            "INIDKWLG3TXAJJAXCYNN3GQ4DV"
        });

        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Success, Is.Not.Null);
        Assert.That(response.Data.Failure.Count, Is.Not.Zero);
    }

    [Test]
    public void TestCriarEtiquetaException()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _loggiClient.CriarEtiqueta(""));
    }

    #endregion
}