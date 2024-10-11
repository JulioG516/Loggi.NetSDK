# Quotation - API

## Criar Cotação
Esta API disponibiliza opções de preços e prazos da Loggi nas plataformas parceiras, em tempo real, conforme as características do envio e do parceiro e informações de shipFrom, shipTo, packages, pickupTypes ou externalServiceIds (SISUs).

## Como Utilizar <!-- {docsify-ignore} -->
A Criação de um objeto `Quotation` é facilitado graças a Fluent API.
Veja como criar um e obter uma cotação da Loggi.

```csharp
 var quotationPickupTypes = QuotationBuilder.CreateBuilder()
            .UsePickupTypes(new List<string> { "PICKUP_TYPE_SPOT", "PICKUP_TYPE_DEDICATED" })
            .SetShipFrom(new QuotationAddressCorreios()
            {
                Correios = new CorreiosAddress()
                {
                    Logradouro = "R. Liberdade",
                    Cep = "30622580",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                }
            })
            .SetShipTo(new QuotationAddressCorreios
            {
                Correios = new CorreiosAddress()
                {
                    Logradouro = "R. Liberdade",
                    Cep = "30622580",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                }
            })
            .AddPackage(new QuotationPackage
            {
                WeightG = 1200,
                LengthCm = 55,
                WidthCm = 55,
                HeightCm = 100,
                GoodsValue = new PricingAmount()
                {
                    CurrencyCode = "BRL",
                    Units = "87",
                    Nanos = 350000000
                }
            })
            .Build();

        var response = await _loggiClient.CriarCotacao(quotationPickupTypes);
        if (response.IsSuccess)
        {              
        response.Data.PackageQuotations.First().Quotations.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine(response.Error);
        }
```

## Retorno 
É devolvido uma classe `QuotationResponse` que contém uma lista de objetos 
`QuotationResponse` que dentro desta contém a lista de `Quotations`

```csharp
    public class QuotationResponse
    {
        /// <summary>
        /// Objeto que representa a cotação de cada pacote.
        /// </summary>
        [JsonPropertyName("packagesQuotations")]
        public List<PackageQuotations> PackageQuotations { get; set; }
    }
    
    /// <summary>
    /// Wrapper do objeto Quotation Response que contem a lista de cotacoes. 
    /// </summary>
    public class PackageQuotations
    {
        /// <summary>
        /// Objeto que representa a cotação de cada pacote.
        /// </summary>
        [JsonPropertyName("quotations")] public List<LoggiQuotation> Quotations { get; set; }
    }
```

## Nota
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
