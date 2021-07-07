using NodaTime;
using NodaTime.Text;
using System;

namespace DateTimeManagement.Core
{
    public static class IANADateTimeExtensions
    {
        public static IANADateTime ToTimeZone(this IANADateTime iANADateTime, string targetTimeZone)
        {
            ZonedDateTime newZonedDateTime = ZonedDateTime.FromDateTimeOffset(iANADateTime.OffsetUTC)
                .WithZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(targetTimeZone));

            return new IANADateTime()
            {
                OriginalDate = newZonedDateTime.ToString("F", null),
                TimeZone = targetTimeZone,
                OffsetUTC = iANADateTime.OffsetUTC,
            };
        }
        static ZonedDateTimePattern defaultPattern = ZonedDateTimePattern.CreateWithInvariantCulture("F", DateTimeZoneProviders.Tzdb);
        public static IANADateTime ToIANADateTime(this string value)
        {
            var parseResult = defaultPattern.Parse(value);
            if (!parseResult.Success)
                parseResult = ZonedDateTimePattern.ExtendedFormatOnlyIso.Parse(value);
            else if (!parseResult.Success)
                parseResult = ZonedDateTimePattern.GeneralFormatOnlyIso.Parse(value);
            else if (!parseResult.Success)
                throw new Exception("invalid format");

            return new IANADateTime()
            {
                OriginalDate = value,
                TimeZone = parseResult.Value.Zone.Id,
                OffsetUTC = parseResult.Value.ToDateTimeOffset().ToUniversalTime(),
            };
        }

        public static string ToExtendIsoString(this IANADateTime value)
            => ZonedDateTimePattern.ExtendedFormatOnlyIso.Format(value.ToZoneDateTime());
        public static string ToGeneralIsoString(this IANADateTime value)
            => ZonedDateTimePattern.GeneralFormatOnlyIso.Format(value.ToZoneDateTime());

        private static ZonedDateTime ToZoneDateTime(this IANADateTime iANADateTime)
            => ZonedDateTime.FromDateTimeOffset(iANADateTime.OffsetUTC).WithZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(iANADateTime.TimeZone));
    }
}
