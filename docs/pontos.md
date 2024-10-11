# Pontos API

## Listar Loggi Pontos
Lista os Loggi Pontos disponíveis para dropoff.

```csharp
var response = await _loggiClient.ListarLoggiPontos(
    new PontosRequest()
{
    Categories = new List<string> { "mg" },
    State = "Minas Gerais",
    PostalCode = "05407002"
});

if (response.IsSuccess)
{
    Console.WriteLine(response.Data.Status);
}
else
{
    Console.WriteLine(response.Error);
}


```

## Parametros de Envio
É enviado uma classe  ```PontosRequest``` contendo diversas opções para ser obtida da Loggi, sendo a propriedade ```Categorias``` obrigatória.

Detalhes da classe abaixo.
```csharp
    public class PontosRequest
    {
        /// <summary>
        /// Nome da categoria do Loggi Ponto. Atualmente é a sigla do estado e só será considerado o primeiro campo da lista.
        /// </summary>
        [Required(ErrorMessage = "Ao menos uma categoria é necessario.")]
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Quantidade máxima de Loggi Pontos a serem retornados por página.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 100;

        /// <summary>
        /// Posição do primeiro Loggi Ponto a ser retornado.
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Filtro por identificador único para retornar um Loggi Ponto específico.
        /// </summary>
        [JsonPropertyName("location_id")]
        public string? LocationId { get; set; } = null;

        /// <summary>
        /// Filtro por proximidade de CEP.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; } = null;

        /// <summary>
        /// Filtro por país.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; } = "Brasil";

        /// <summary>
        /// Filtro de cidade.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; } = null;

        /// <summary>
        /// Filtro por estado.
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; } = null;

        /// <summary>
        /// Filtro por longitude.
        /// </summary>
        [JsonPropertyName("longitude")]
        public long? Longitude { get; set; } = null;

        /// <summary>
        /// Filtro por latitude.
        /// </summary>
        [JsonPropertyName("latitude")] public long? Latitude { get; set; } = null;
        
        /// <summary>
        /// Filtro por distância (em metros).
        /// </summary>
        [JsonPropertyName("distance")]
        public long? Distance { get; set; } = null;
    }
```


## Retorno
é retornado a classe ```PontosResponse``` contendo a propriedade
```Status``` informando se houve sucesso na pesquisa
e a propriedade ```Message``` contendo o tipo ```PontosMessage```

```csharp
    public class PontosResponse
    {
        /// <summary>
        /// Informa que houve sucesso na pesquisa.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Paginação dos resultados com o objeto <see cref="PontosMessage"/>
        /// </summary>
        [JsonPropertyName("message")]
        public PontosMessage Message { get; set; }
    }

    public class PontosResponse
    {
        /// <summary>
        /// Informa que houve sucesso na pesquisa.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Paginação dos resultados com o objeto <see cref="PontosMessage"/>
        /// </summary>
        [JsonPropertyName("message")]
        public PontosMessage Message { get; set; }
    }
```

## Nota 
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
