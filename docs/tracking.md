# Tracking API

## Rastrear Pacote
Faz o rastreio de pacotes a partir das informações de TrackingCode (Codigo de rastreio obtido da Loggi.)

```csharp
var response = await _loggiClient.RastrearPacote("R012321001540");
if (response.IsSuccess)
{
    Console.WriteLine(response.Data.Packages.First());
}
else
{
    Console.WriteLine(response.Error);
}

```

## Retorno - Rastrear Pacote
Objeto `TrackingResponse` contedo uma lista de objetos `TrackingPackage`
dentro da propriedade `Packages`.
```csharp
    public class TrackingResponse
    {
        /// <summary>
        /// Lista de objetos <see cref="TrackingPackage"/>
        /// </summary>
        [JsonPropertyName("packages")] public List<TrackingPackage> Packages { get; set; }
    }

    public class TrackingPackage
    {
        /// <summary>
        /// Chave que identifica unicamente um pacote dentro da Loggi.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Código de rastreio de um pacote.
        /// </summary>
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Objeto que representa as informações do status de um pacote.
        /// </summary>
        [JsonPropertyName("status")]
        public TrackingStatus Status { get; set; }

        /// <summary>
        /// Objeto que representa a localização do pacote em seu status atual.
        /// </summary>
        [JsonPropertyName("location")]
        public TrackingLocation Location { get; set; }

        /// <summary>
        /// Estimativa de data para a primeira tentativa de entrega.
        /// </summary>
        [JsonPropertyName("promisedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Timestamp do momento da requisição.
        /// </summary>
        [JsonPropertyName("requestTime")]
        public DateTime? RequestTime { get; set; }

        /// <summary>
        /// Histórico de status de um pacote.
        /// </summary>
        [JsonPropertyName("trackingHistory")]
        public List<TrackingHistory> TrackingHistory { get; set; }

        /// <summary>
        /// Objeto contendo a informações da entrega.
        /// </summary>
        [JsonPropertyName("deliveryInformation")]
        public TrackingDeliveryInformation DeliveryInformation { get; set; }
    }

```



## Detalhes do Pacote
Recupera detalhes de um pacote a partir das informações do TrackingCode.

```csharp
var response = await _loggiClient.RastrearPacote("R012321001540");
if (response.IsSuccess)
{
    Console.WriteLine(response.Data);
}
else
{
    Console.WriteLine(response.Error);
}

```

## Retorno - Detalhes do Pacote
Objeto `TrackingResponse` contedo uma lista de objetos `TrackingDetailsPackage`
dentro da propriedade `Packages`.
```csharp
    public class TrackingDetailsResponse
    {
        /// <summary>
        /// Lista de objetos <see cref="TrackingDetailsPackage"/>
        /// </summary>
        [JsonPropertyName("packages")]
        public List<TrackingDetailsPackage> Packages { get; set; }
    }

    public class TrackingDetailsPackage
    {
        /// <summary>
        /// Chave que identifica unicamente um pacote dentro da Loggi.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Código de rastreio de um pacote.
        /// </summary>
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Objeto que representa as informações do status de um pacote.
        /// </summary>
        [JsonPropertyName("status")]
        public TrackingStatus Status { get; set; }

        /// <summary>
        /// Objeto que contém informações ligados ao Destino.
        /// </summary>
        [JsonPropertyName("destination")]
        public TrackingDetailsDestination Destination { get; set; }

        /// <summary>
        /// Estimativa de data para a primeira tentativa de entrega.
        /// </summary>
        [JsonPropertyName("promisedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? PromisedDate { get; set; }


        /// <summary>
        /// Objeto que contèm detalhes da dimensão do pacote.
        /// </summary>
        [JsonPropertyName("dimension")]
        public TrackingDetailsDimension Dimension { get; set; }

        /// <summary>
        /// Objeto que contém detalhes da nota fiscal do pacote.
        /// </summary>
        [JsonPropertyName("invoice")]
        public TrackingDetailsInvoice Invoice { get; set; }

        /// <summary>
        /// Objeto que contém informações da origem do pacote.
        /// </summary>
        [JsonPropertyName("origin")]
        public TrackingDetailsOrigin Origin { get; set; }

        /// <summary>
        /// objeto que contém informações de quem recebeu o pacote.
        /// </summary>
        [JsonPropertyName("receiver")]
        public TrackingDetailsReceiver Receiver { get; set; }

        /// <summary>
        /// Objeto que representa as informações de precificação do envio de um pacote.
        /// </summary>
        [JsonPropertyName("pricing")]
        public TrackingDetailsPricing Pricing { get; set; }

        /// <summary>
        /// Representação númerica do SLO (Service Level Objective) associado ao pacote. Comumente 0 ou 1.
        /// </summary>
        [JsonPropertyName("slo")]
        public int Slo { get; set; }

        /// <summary>
        /// Objeto que contém informações relacionados a operação de redespacho do pacote.
        /// </summary>
        [JsonPropertyName("redispatch")]
        public TrackingDetailsRedispatch Redispatch { get; set; }

        /// <summary>
        /// Objeto que contém informações relacionados a direção do pacote.
        /// </summary>
        [JsonPropertyName("direction")]
        public TrackingDetailsDirection Direction { get; set; }

        /// <summary>
        /// Objeto que contém informações relacionados a informação de entrega do pacote.
        /// </summary>
        [JsonPropertyName("deliveryInformation")]
        public TrackingDeliveryInformation DeliveryInformation { get; set; }

        /// <summary>
        /// Objeto que contém informações relacionados a informação de coleta do pacote..
        /// </summary>
        [JsonPropertyName("pickup_receipt")]
        public TrackingDetailsPickupReceipt PickupReceipt { get; set; }

        /// <summary>
        /// Informações de volume do pacote.
        /// </summary>
        [JsonPropertyName("volumetric_info")]
        public TrackingDetailsVolumetricInfo VolumetricInfo { get; set; }

        /// <summary>
        /// Timestamp do momento da requisição.
        /// </summary>
        [JsonPropertyName("requestTime")]
        public DateTime? RequestTime { get; set; }
    }
```

## Nota 
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
