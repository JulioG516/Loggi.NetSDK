﻿using System;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Tracking;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Objeto que é retornado ao obter Tracking => DetailsAPI
    /// </summary>
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

    /// <summary>
    /// Objeto que contèm detalhes da dimensão do pacote.
    /// </summary>
    public class TrackingDetailsDimension
    {
        /// <summary>
        /// Peso do pacote, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("weightG")]
        public int WeightG { get; set; }

        /// <summary>
        /// Comprimento do pacote, representado em centímetros (cm).
        /// </summary>
        [JsonPropertyName("lengthCm")]
        public int LengthCm { get; set; }

        /// <summary>
        /// Largura do pacote, representado em centímetros (cm).
        /// </summary>
        [JsonPropertyName("widthCm")]
        public int WidthCm { get; set; }

        /// <summary>
        /// Altura do pacote, representado em centímetros (cm).
        /// </summary>
        [JsonPropertyName("heightCm")]
        public int HeightCm { get; set; }
    }

    /// <summary>
    /// Objeto que contém detalhes da nota fiscal do pacote.
    /// </summary>
    public class TrackingDetailsInvoice
    {
        /// <summary>
        /// Série da Nota Fiscal associada ao pacote.
        /// </summary>
        [JsonPropertyName("series")]
        public string Series { get; set; }

        /// <summary>
        /// Número da Nota Fiscal associada ao pacote.
        /// </summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Chave da Nota Fiscal Eletrônica (NFe) associada ao pacote, formada por 44 números.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Valor total emitido na Nota Fiscal associada ao pacote.
        /// </summary>
        [JsonPropertyName("totalValue")]
        public string TotalValue { get; set; }
    }

    /// <summary>
    /// Objeto que contém informações da origem do pacote.
    /// </summary>
    public class TrackingDetailsOrigin
    {
        /// <summary>
        /// Código postal do endereço enviado. No Brasil, usa-se o CEP.
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    }

    /// <summary>
    /// objeto que contém informações de quem recebeu o pacote.
    /// </summary>
    public class TrackingDetailsReceiver
    {
        /// <summary>
        /// Nome de quem recebeu o pacote no momento de sua entrega. Não necessariamente é igual ao nome do destinatário.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Objeto que representa as informações de precificação do envio de um pacote.
    /// </summary>
    public class TrackingDetailsPricing
    {
        /// <summary>
        /// Objeto com as informações do preço do envio de pacote.
        /// </summary>
        [JsonPropertyName("amount")]
        public PricingAmount Amount { get; set; }
    }

    /// <summary>
    /// Objeto que representa as informações de precificação do envio de um pacote.
    /// </summary>
    public class TrackingDetailsRedispatch
    {
        /// <summary>
        /// Código de barras associado à operação de redespacho do pacote para os Correios.
        /// </summary>
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }
    }

    /// <summary>
    /// Objeto que contém informações relacionados a informação de coleta do pacote..
    /// </summary>
    public class TrackingDetailsPickupReceipt
    {
        /// <summary>
        /// Nome da pessoa que fez a coleta.
        /// </summary>
        [JsonPropertyName("driver_name")]
        public string DriverName { get; set; }

        /// <summary>
        /// Placa do veículo de coleta.
        /// </summary>
        [JsonPropertyName("license_plate")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Timestamp do momento da coleta.
        /// </summary>
        [JsonPropertyName("pickup_end_time")]
        public DateTime? PickupEndTtime { get; set; }

        /// <summary>
        /// Código numérico referente ao tipo de veículo que realizou a coleta.
        /// </summary>
        [JsonPropertyName("transport_type")]
        public long TransportType { get; set; }
    }
}