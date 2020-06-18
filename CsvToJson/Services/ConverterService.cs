using CsvHelper;
using CsvToJson.Interfaces;
using CsvToJson.Mappers;
using CsvToJson.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace CsvToJson.Services
{
    public class ConverterService : IConverterService
    {
        public string ConvertCsvToJson(string csvPath)
        {
            string json;
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<UserMap>();
                var user = csv.GetRecords<User>();

                json = JsonConvert.SerializeObject(user);
            }

            return json;
        }
    }
}
