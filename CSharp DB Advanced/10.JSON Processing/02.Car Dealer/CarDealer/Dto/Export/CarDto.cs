using System.Collections.Generic;

namespace CarDealer.Dto.Export
{
    public class CarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<int> partsId { get; set; } = new List<int>();
    }
}
