# Loggi .Net SDK

[![Nuget](https://img.shields.io/nuget/v/Loggi.NETSDK)](https://www.nuget.org/packages/Loggi.NetSDK/)

O Loggi .Net SDK é uma biblioteca poderosa e fácil de usar que permite integrar as funcionalidades da API da Loggi
diretamente em suas aplicações .NET. Com este SDK, você pode realizar diversas operações de forma simples e eficiente,
utilizando métodos e classes intuitivas.

## Funcionalidades

- Gerar envios
- Gerar cotação de envio
- Rastrear encomendas
- Gerar etiquetas
- E muito mais!

Para mais detalhes sobre as funcionalidades disponíveis, 
consulte a documentação oficial da API [Loggi]("https://docs.api.loggi.com/reference").


## Observações Importantes

Alguns endpoints da API Loggi podem não estar funcionando conforme esperado. Por exemplo:

- O método AtualizarPacote, que utiliza Package -> PackageUpdate.
- O método BuscarJanelaColeta, que utiliza PickupTimeSlotApi.

## Instalando

```sh
dotnet add package Loggi.NetSDK --version 1.0.0
```

Ou via gerenciador de Nuget do Visual Studio ou Jetbrains Rider.

## Exemplo: Instanciando um cliente:

    var _loggiClient = new LoggiClient("COMPANY_ID"); // Company Id obtido da Loggi.
    await _loggiClient.AuthenticateAsync("ClientId", "ClientSecret"); // Ambos obtido da Loggi.

## Tipo de Resposta

A API segue um padrão de resposta que utiliza uma classe genérica contendo o tipo `<T>` na propriedade `Data` e uma
classe `Error` em caso de erros. Para verificar se a sua requisição foi bem-sucedida, você pode utilizar o seguinte
exemplo:

```csharp
var response = _loggiClient.Metodo();

if (response.IsSuccess)
{
    Console.WriteLine(response.Data);
}
else
{
    Console.WriteLine(response.Error.Message);
}
```

### Neste exemplo:

- response.IsSuccess: Indica se a requisição foi bem-sucedida.
- response.Data: Contém os dados retornados pela API quando a requisição é bem-sucedida.
- response.Error: Contém informações sobre o erro ocorrido, caso a requisição falhe.

## Exemplo: Criando uma cotação com Fluent Api:

```csharp
var quotationPickupTypes = QuotationBuilder.CreateBuilder()
    .UsePickupTypes(new List<string> { "PICKUP_TYPE_SPOT", "PICKUP_TYPE_DEDICATED" })
    .SetShipFrom(new QuotationAddressCorreios
    {
        Correios = new CorreiosAddress
        {
            Logradouro = "R. Liberdade",
            Cep = "30622580",
            Cidade = "Belo Horizonte",
            Uf = "MG"
        }
    })
    .SetShipTo(new QuotationAddressCorreios
    {
        Correios = new CorreiosAddress
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
        GoodsValue = new PricingAmount
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
    Console.WriteLine(response.Data);
}
else
{
    Console.WriteLine(response.Error.Message);
}
```

### Exemplo: Gerando uma etiqueta com a Loggi Key obtida após o envio.

```csharp
        var response = await _loggiClient.CriarEtiqueta("MVTTG2LG3TXAOY3DASIM3WQZT4", LabelLayouts.LayoutA6);
        if (response.IsSuccess)
        {
            Console.WriteLine(response.Data);
        }
        else
        {
            Console.WriteLine(response.Error.Message);
        }
```

## Mais exemplos

Para mais exemplos detalhados, consulte o projeto LoggiTests.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a licença MIT.