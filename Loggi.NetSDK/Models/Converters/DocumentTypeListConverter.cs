using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments.DocumentTypes;

namespace Loggi.NetSDK.Models.Converters
{
    public class DocumentTypeListConverter : JsonConverter<List<IDocumentType>>
    {
        public override List<IDocumentType>? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var list = new List<IDocumentType>();

            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                foreach (var element in doc.RootElement.EnumerateArray())
                {
                    if (element.TryGetProperty("invoice", out _))
                    {
                        list.Add(JsonSerializer.Deserialize<InvoiceDocumentType>(element.GetRawText(), options));
                    }
                    else if (element.TryGetProperty("contentDeclaration", out _))
                    {
                        list.Add(JsonSerializer.Deserialize<ContentDeclarationDocumentType>(element.GetRawText(),
                            options));
                    }
                    else if (element.TryGetProperty("dir", out _))
                    {
                        list.Add(JsonSerializer.Deserialize<DirDocumentType>(element.GetRawText(), options));
                    }
                    else
                    {
                        throw new JsonException("Unknown document type");
                    }
                }
            }

            return list;
        }

        public override void Write(Utf8JsonWriter writer, List<IDocumentType> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var item in value)
            {
                JsonSerializer.Serialize(writer, (object)item, options);
            }

            writer.WriteEndArray();
        }
    }
}