using CsvHelper.Configuration;
using CsvToJson.Models;

namespace CsvToJson.Mappers
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(m => m.Address.Line1).Name("address_line1");
            Map(m => m.Address.Line2).Name("address_line2");
            Map(m => m.Name).Name("name");
        }
    }
}
