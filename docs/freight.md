# Freight Price Quotation - API

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
            response.Data.Quotations.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine(response.Error);
        }
```