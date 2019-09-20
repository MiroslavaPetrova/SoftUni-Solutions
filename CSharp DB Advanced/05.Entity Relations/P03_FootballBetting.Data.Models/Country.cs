using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }


        //•	Country – CountryId, Name
        //a Country can have many Towns
    }
}
