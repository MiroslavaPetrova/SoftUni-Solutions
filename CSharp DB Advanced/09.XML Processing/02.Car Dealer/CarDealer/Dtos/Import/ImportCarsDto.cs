using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

    
    
        [XmlElement("model")]
       
        public string Model { get; set; }

  
      
        [XmlElement("TraveledDistance")]
        
        public long TravelledDistance { get; set; }

  
 
        [XmlArray("parts")]
       
        public List<PartsDto> Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
