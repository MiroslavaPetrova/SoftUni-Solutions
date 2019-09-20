using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class CustomUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersAndProductsDto [] UsersAndProductsDto { get; set; }
    }
}
