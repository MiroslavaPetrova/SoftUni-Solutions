using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UsersAndProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductDto SoldProducts { get; set; }
        //        <count>54</count>
        //<users>
        //  <User>
        //    <firstName>Cathee</firstName>
        //    <lastName>Rallings</lastName>
        //    <age>33</age>
        //    <SoldProducts>     //     ELEMENT NOT ARRAY - IT HAS COUNT NOT ONLY ARRAY OF PRODUCTS
        //      <count>9</count>
        //      <products>
        //        <Product>
        //          <name>Fair Foundation SPF 15</name>
        //          <price>1394.24</price>
        //        </Product>

    }

    public class SoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductDto [] Products { get; set; }
    }

    //public class ProductDto           we already have one and the same in separate file
    //{
    //    [XmlElement("name")]
    //    public string Name { get; set; }

    //    [XmlElement("price")]
    //    public decimal Price { get; set; }
    //}
}
