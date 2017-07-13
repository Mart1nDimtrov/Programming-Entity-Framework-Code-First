using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayGeekAdventures.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Country { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string todayForecast;

        [NotMapped]
        public string Forecast
        {
            get { return todayForecast; }
            set { todayForecast = value; }
        }

        [Column(TypeName = "image")]
        public byte [] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; }


    }
}
