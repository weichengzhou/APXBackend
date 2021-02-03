using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APX.Controllers.Converter.JSON
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public string DateTimeFormat { get; private set; }

        public DateTimeConverter(string datetimeFormat) : base()
        {
            this.DateTimeFormat = datetimeFormat;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(this.DateTimeFormat));
        }
    }
}