using DateTimeManagement.Core;
using NodaTime;
using NodaTime.Text;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateTimeManagement.Converters
{
    public class IANADateConverter : JsonConverter<IANADateTime>
    {
        private static ZonedDateTimePattern ParsePattern = ZonedDateTimePattern.CreateWithInvariantCulture("F", DateTimeZoneProviders.Tzdb);

        private static ZonedDateTime GetZonedDateTimeFromDataString(string dateTime) => ParsePattern.Parse(dateTime).Value;

        public override IANADateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string rawDateTime = reader.GetString();
            return GetIANADateFromString(rawDateTime);
        }

        public override void Write(Utf8JsonWriter writer, IANADateTime value, JsonSerializerOptions options)
        {
            //string originalDate = value.OriginalDate;
            ZonedDateTime zdt = ToZoneDateTime(value);
            string originalDate = ParsePattern.Format(zdt);
            writer.WriteStringValue(originalDate);
        }

        private static ZonedDateTime ToZoneDateTime(IANADateTime value)
        {
            return new ZonedDateTime(Instant.FromDateTimeUtc(value.OffsetUTC.UtcDateTime), DateTimeZoneProviders.Tzdb.GetZoneOrNull(value.TimeZone));
        }

        public static IANADateTime GetIANADateFromString(string rawDateTime)
        {
            ZonedDateTime nodaTime = GetZonedDateTimeFromDataString(rawDateTime);

            return new IANADateTime()
            {
                OriginalDate = rawDateTime,
                OffsetUTC = new DateTimeOffset(nodaTime.ToDateTimeUtc()),
                TimeZone = nodaTime.Zone.Id
            };
        }
    }
}