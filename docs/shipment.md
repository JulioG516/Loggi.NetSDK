# Shipment API


## Criar um Shipment (Envio)
Cria um Shipment de forma assíncrona. Para iniciar um envio, você precisará de um endereço de origem (ShipFrom), outro de destino (ShipTo) e um pacote (Package).

Você pode criar um shipment com a Fluent API da seguinte forma:

```csharp
   var shipment = ShipmentBuilder.CreateBuilder()
            .SetPickupTypes()
            .UseDefault()
            .SetShipFrom(new ShipFrom()
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

        var response = await _loggiClient.CriarShipmentAsync(shipment);

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Data.Packages);
        }
        else
        {
            Console.WriteLine(response.Error);
        }
```

## Retorno
Objeto `ShipmentResponse` contendo uma lista de objetos `ResponsePackage` dentro da propriedade `Packages`. 

```csharp
    public class ShipmentResponse
    {
        /// <summary>
        /// Lista de <see cref="ResponsePackage"/> de um Shipment que serão processados.
        /// </summary>
        [JsonPropertyName("packages")]
        public List<ResponsePackage> Packages { get; set; }
    }

    public class ResponsePackage
    {
        /// <summary>
        /// Código de rastreio de um envio informado pelo cliente. Caso não seja informado, a Loggi irá gerar um valor para este campo. Tamanho mínimo 1 caractere e Tamanho máximo 100 caracteres.
        /// </summary>
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Conteúdo do código de barras informado pelo cliente. Caso não seja informado, a Loggi irá gerar um valor para este campo. Tamanho mínimo 1 caractere e Tamanho máximo 255 caracteres.
        /// </summary>
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        /// Identificador único de um pacote gerado pela Loggi.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Valor enviado pelo cliente para identificar um pacote dentro de um Shipment. Este valor será retornado
        /// na resposta. Tamanho máximo 100.
        /// </summary>
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
```


## Nota
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
