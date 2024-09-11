using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Labels;

namespace Loggi.NetSDK.Models.Converters
{
    internal class LabelResponseTypeConverter : JsonConverter<ILabelResponseType>
    {
        public override ILabelResponseType? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (root.TryGetProperty("content", out _))
            {
                return JsonSerializer.Deserialize<LabelResponseBase64>(root.GetRawText());
            }
            else if (root.TryGetProperty("url", out _))
            {
                return JsonSerializer.Deserialize<LabelResponseUrl>(root.GetRawText());
            }

            throw new JsonException("Unknown LabelResponseType.");
        }

        public override void Write(Utf8JsonWriter writer, ILabelResponseType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);

        }
    }
}