using System;

namespace DateTimeManagement.Core
{
    public class IANADateTime
    {
        public string OriginalDate { get; set; }
        public string TimeZone { get; set; }
        // TODO Offset ou pas ?  : a justifer @Aurelien
        public DateTimeOffset OffsetUTC { get; set; }
    }
}