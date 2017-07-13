using BreakAwayAdventuresFluentAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BreakAwayAdventuresFluentAPI
{
    public class AddressConfiguration :
        ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(a => a.StreetAddress).HasMaxLength(150);
            Property(a => a.StreetAddress).HasColumnName("StreetAddress");
            Property(a => a.City).HasColumnName("City");
            Property(a => a.ZipCode).HasColumnName("ZipCode");
            Property(a => a.State).HasColumnName("State");
        }
    }
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            // HasKey(p => p.SocialSecurityNumber)
            //  .Property(p => p.SocialSecurityNumber)
            //  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.RowVersion).IsRowVersion();
            Property(p => p.SocialSecurityNumber).IsConcurrencyToken();
        }
    }

    public class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasMany(t => t.Activities)
                .WithMany(a => a.Trips)
                .Map(c => {
                    c.ToTable("TripActivities");
                    c.MapLeftKey("TripIdentifier");
                    c.MapRightKey("ActivityId");
                    });
            HasKey(t => t.Identifier)
               .Property(t => t.Identifier)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.RowVersion).IsRowVersion();
            
        }
    }

    public class DestinationConfiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {
            Property(d => d.Name).IsRequired();
            Property(d => d.Description).HasMaxLength(500);
            Property(d => d.Photo).HasColumnType("image");
            HasMany(d => d.Lodgings).WithRequired(l => l.Destination);
            Ignore(d => d.Forecast);
        }
    }

    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Owner).IsRequired().HasMaxLength(200);
            Property(l => l.Owner).IsUnicode(false);
            Property(l => l.MilesFromNearestAirport).HasPrecision(8, 1);
            HasOptional(l => l.PrimaryContact).
                WithMany(p => p.PrimaryContactFor).
                HasForeignKey(p => p.PrimaryContactId);
            HasOptional(l => l.SecondaryContact).
                WithMany(p => p.SecondaryContactFor).
                 HasForeignKey(p => p.SecondaryContactId); ;
            Map(m =>
            {
                m.ToTable("Lodgings");
            }).Map<Resort>(m =>
               {
                   m.ToTable("Resorts");
                   m.MapInheritedProperties();
               });

        }
    }

    public class InternetSpecialConfiguration : EntityTypeConfiguration<InternetSpecial>
    {
        public InternetSpecialConfiguration()
        {
            HasRequired(s => s.Accommodation)
                .WithMany(l => l.InternetSpecials)
                .HasForeignKey(s => s.AccommodationId);
        }
    }

    public class ActivityConfiguration : EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration()
        {
            Property(a => a.Name).HasMaxLength(50).IsRequired();
        }

    }
    public class PersonPhotoConfiguration : EntityTypeConfiguration<PersonPhoto>
    {
        public PersonPhotoConfiguration()
        {
            Property(p => p.Photo).HasColumnType("image");
            HasRequired(p => p.PhotoOf).WithOptional(p => p.Photo);
        }

    }


  

}
