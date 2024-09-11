using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments.AddressTypes;

namespace Loggi.NetSDK.Models.Converters
{
    internal class AddressTypeConverter : JsonConverter<IAddressType>
    {
        public override IAddressType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("correiosAddress", out _))
                {
                    return JsonSerializer.Deserialize<CorreiosAddressType>(root.GetRawText(), options);
                }
                else
                {
                    return JsonSerializer.Deserialize<LineAddressType>(root.GetRawText(), options);
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, IAddressType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}