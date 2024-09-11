using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments.NifTypes;

namespace Loggi.NetSDK.Models.Converters
{
    internal class NifTypeConverter : JsonConverter<INifType>
    {
        public override INifType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("national", out _))
                {
                    return JsonSerializer.Deserialize<NationalNifType>(root.GetRawText(), options);
                }
                else
                {
                    return JsonSerializer.Deserialize<InternationalNifType>(root.GetRawText(), options);
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, INifType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}