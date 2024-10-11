# Loggi.NET

> O Loggi .Net SDK é uma biblioteca poderosa e fácil de usar que permite integrar as funcionalidades da API da Loggi diretamente em suas aplicações .NET. Com este SDK, você pode realizar diversas operações de forma simples e eficiente, utilizando métodos e classes intuitivas.

## Como começar
Primeiro, instale o pacote nuget via CLI ou gerenciador de Nugets do Visual Studio ou Jetbrains Rider.
```sh
dotnet add package Loggi.NetSDK --version latest
```

## Instanciando um cliente
Para criar um cliente, você precisará do `CompanyId` fornecido pela Loggi. Além disso, é necessário autenticar o cliente utilizando o `ClientId` e o `ClientSecret`.


```csharp
var _loggiClient = new LoggiClient("COMPANY_ID"); // Company Id obtido da Loggi.
await _loggiClient.AuthenticateAsync("ClientId", "ClientSecret"); // Ambos obtido da Loggi.
```

## Padrão de respostas
A API segue um padrão de resposta que utiliza uma classe genérica contendo o tipo <T> na propriedade Data e uma classe Error em caso de erros. Para verificar se a sua requisição foi bem-sucedida, você pode utilizar o seguinte exemplo:
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

##  <!-- {docsify-ignore} --> Neste Exemplo
- response.IsSuccess: Indica se a requisição foi bem-sucedida.
- response.Data: Contém os dados retornados pela API quando a requisição é bem-sucedida.
- response.Error: Contém informações sobre o erro ocorrido, caso a requisição falhe