using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvParser
{
    public static class StringCsvExtension
    {
        public static List<string> ParseCSV(this string rec, char delimiter = ',', char quote = '"')
        {
            var fields = new List<StringBuilder>() { new StringBuilder() };
            bool inQuote = false;
            StringBuilder currentItem = fields[fields.Count - 1];
            for (int i = 0; i < rec.Length; i++)
            {
                char c = rec[i];
                if (c == delimiter && !inQuote)
                {
                    // If this is a delimiter character advance the field.
                    fields.Add(new StringBuilder());
                    currentItem = fields[fields.Count - 1];
                }
                else if (c == quote)
                {
                    if (inQuote                 // We're in a quote...
                        && i + 1 < rec.Length   // not end of line...
                        && rec[i + 1] == quote) // next character is a quote.
                    {
                        currentItem.Append(c);  // This quote is escaped.
                    }
                    else
                    {
                        inQuote = !inQuote;
                    }
                }
                else
                {
                    // If this is just a normal letter
                    currentItem.Append(c);
                }
            }
            return fields.Select(s => s.ToString()).ToList();
        }
    }
}
