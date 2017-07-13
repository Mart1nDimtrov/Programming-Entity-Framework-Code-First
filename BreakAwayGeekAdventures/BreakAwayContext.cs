namespace BreakAwayGeekAdventures
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BreakAwayContext : DbContext
    {
        
        public BreakAwayContext()
            : base("name=BreakAwayContext")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
        }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Lodging>Lodgings { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
    }

  
}