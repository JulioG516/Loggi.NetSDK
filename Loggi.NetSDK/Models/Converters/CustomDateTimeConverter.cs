using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Converters
{
    public class CustomDateTimeConverter : JsonConverter<DateTime?>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (DateTime.TryParseExact(reader.GetString(), DateFormat, null,
                        System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString(DateFormat));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}