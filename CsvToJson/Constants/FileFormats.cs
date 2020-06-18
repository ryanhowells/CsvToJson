using System.Collections.Generic;

namespace CsvToJson.Constants
{
    public class FileFormats
    {
        public const string Json = "JSON";
        public const string Csv = "CSV";
        public static List<string> All = new List<string> { Json, Csv };
    }
}
