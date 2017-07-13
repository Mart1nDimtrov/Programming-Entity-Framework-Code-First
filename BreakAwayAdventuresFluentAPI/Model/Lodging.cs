using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayAdventuresFluentAPI.Model
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public Nullable<int> PrimaryContactId { get; set; }
        public Person PrimaryContact { get; set; }
        public Nullable<int> SecondaryContactId { get; set; }
        public Person SecondaryContact { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }
        public decimal MilesFromNearestAirport { get; set; }

        public int LocationId { get; set; }
        public Destination Destination { get; set; }

        public List<InternetSpecial> InternetSpecials { get; set; }

    }
    public class Resort : Lodging
    {
        public string Entertainment { get; set; }
        public string Activities { get; set; }
    }
}
