using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ProductDto [] SoldProducts { get; set; }

            //    <User>
            //<firstName>Almire</firstName>
            //<lastName>Ainslee</lastName>
            //<soldProducts>
            //  <Product>
            //    <name>olio activ mouthwash</name>
            //    <price>206.06</price>
            //  </Product>

    }
    [XmlType("Product")]
    public class ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
