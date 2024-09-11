using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.FreightPriceQuotation;

namespace Loggi.NetSDK.Models.Converters
{
    internal class QuotationAddressConverter : JsonConverter<IQuotationAddress>
    {
        public override IQuotationAddress Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                if (doc.RootElement.TryGetProperty("correios", out _))
                {
                    return JsonSerializer.Deserialize<QuotationAddressCorreios>(doc.RootElement.GetRawText(), options);
                }

                if (doc.RootElement.TryGetProperty("lines", out _))
                {
                    return JsonSerializer.Deserialize<QuotationAddressLine>(doc.RootElement.GetRawText(), options);
                }

                if (doc.RootElement.TryGetProperty("widget", out _))
                {
                    return JsonSerializer.Deserialize<QuotationAddressWidget>(doc.RootElement.GetRawText(), options);
                }

                throw new JsonException("Unknown IQuotationAddress type.");
            }
        }

        public override void Write(Utf8JsonWriter writer, IQuotationAddress value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}