using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Converters
{
    internal class ErrorCodeConverter : JsonConverter<EnumErrorCode>
    {
        public override EnumErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int intValue = reader.GetInt32();
            return (EnumErrorCode)intValue;
        }

        public override void Write(Utf8JsonWriter writer, EnumErrorCode value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}