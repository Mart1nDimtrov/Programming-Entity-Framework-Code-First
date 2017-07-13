namespace BreakAwayAdventuresFluentAPI
{
    using BreakAwayGeekAdventures.Model;
    using Model;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual DbSet<Lodging> Lodgings { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        public virtual DbSet<Person> People { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<PersonalInfo>();
            modelBuilder.Entity<PersonPhoto>().ToTable("PersonPhotos");

        }
    }
}