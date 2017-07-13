using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayAdventuresFluentAPI.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        
        public string Description { get; set; }

        public string todayForecast;
        public string Forecast
        {
            get { return todayForecast; }
            set { todayForecast = value; }
        }

        public byte [] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; }


    }
}
