namespace CsvToJson.Models
{
    public class User
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }
    }
}
