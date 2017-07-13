using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayGeekAdventures.Model
{
    public class Lodging
    {
        [Required]
        public int LodgingId { get; set; }

        public string Name { get; set; }

        [InverseProperty("PrimaryContactFor")]
        public Person PrimaryContact { get; set; }

        [InverseProperty("SecondaryContactFor")]
        public Person SecondaryContact { get; set; }

        [MaxLength(200)]
        [MinLength(10)]
        public string Owner { get; set; }

        public decimal MilesFromNearestAirport { get; set; }
        public bool IsResort { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        public List<InternetSpecial> InternetSpecials { get; set; }
    }

    [Table("Resorts")]
    public class Resort : Lodging
    {
        public string Entertainment { get; set; }
        public string Activities { get; set; }
    }
}
