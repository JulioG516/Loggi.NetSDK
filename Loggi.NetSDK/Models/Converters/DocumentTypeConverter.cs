using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments.DocumentTypes;

namespace Loggi.NetSDK.Models.Converters
{
    internal class DocumentTypeConverter : JsonConverter<IDocumentType>
    {
        public override IDocumentType? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;

                if (root.TryGetProperty("invoice", out _))
                {
                    return JsonSerializer.Deserialize<InvoiceDocumentType>(root.GetRawText(), options);
                }

                if (root.TryGetProperty("contentDeclaration", out _))
                {
                    return JsonSerializer.Deserialize<ContentDeclarationDocumentType>(root.GetRawText(), options);
                }

                if (root.TryGetProperty("dir", out _))
                {
                    return JsonSerializer.Deserialize<DirDocumentType>(root.GetRawText(), options);
                }
                
                throw new JsonException("Unknown document type");
            }
        }

        public override void Write(Utf8JsonWriter writer, IDocumentType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}