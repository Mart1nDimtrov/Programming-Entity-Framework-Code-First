using BreakAwayAdventuresFluentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayAdventuresFluentAPI
{
    class BreakAwayAdventuresFluentAPI
    {
        static void Main(string[] args)
        {
            InsertDestination();
            InsertPerson();
        }
        public static void InsertDestination()
        {
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };
            var context = new BreakAwayContext();
            context.Destinations.Add(destination);
            context.SaveChanges();
        }


        public static void InsertPerson()
        {
            var person = new Person
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678
            };
            var context = new BreakAwayContext();
            context.People.Add(person);
            context.SaveChanges();
        }
        public static void UpdateTrip()
        {
            var context = new BreakAwayContext();
            var trip = context.Trips.FirstOrDefault();
            trip.CostUSD = 750;
            context.SaveChanges();
        }
        public static void UpdatePerson()
        {
            var context = new BreakAwayContext();
            var person = context.People.FirstOrDefault();
            person.FirstName = "Rowena";
            context.SaveChanges();
        }
        public static void InsertLodging()
        {
            var lodging = new Lodging
            {
                Name = "Rainy Day Motel",
                Destination = new Destination
                {
                    Name = "Seattle, Washington",
                    Country = "USA"
                }
            };
            using (var context = new BreakAwayContext())
            {
                context.Lodgings.Add(lodging);
                context.SaveChanges();
            }
        }

        public static void InsertResort()
        {
            var resort = new Resort
            {
                Name = "Top Notch Resort and Spa",
                MilesFromNearestAirport = 30,
                Activities = "Spa, Hiking, Skiing, Ballooning",
                Destination = new Destination
                {
                    Name = "Stowe, Vermont",
                    Country = "USA"
                }
            };

            using (var context = new BreakAwayContext())
            {
                context.Lodgings.Add(resort);
                context.SaveChanges();
           }
        }
    }
}
