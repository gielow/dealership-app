using System;
using System.Collections.Generic;
using System.Text;

namespace dealership.data
{
    public static class ParseUtils
    {
        public static decimal ParseDecimalFromWithQuotes(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            return decimal.Parse(value.Replace("\"", string.Empty));
        }

        public static DateTime? ParseDateTimeFromWithQuotes(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return DateTime.Parse(value.Replace("\"", string.Empty));
        }

        public static string RemoveOuterQuotesFromString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Trim('"');
        }
    }
}
