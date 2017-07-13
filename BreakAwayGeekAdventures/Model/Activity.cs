using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayGeekAdventures.Model
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public List<Trip> Trips { get; set; }

    }
}
