using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayGeekAdventures.Model
{
    [ComplexType]
    public class Address
    {
       
        public int AdressId { get; set; }
        [MaxLength(150)]
        [Column("StreetAddress")]
        public string StreetAddress { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
    }

    [ComplexType]
    public class PersonalInfo
    {
        public Measurement Weigth { get; set; }
        public Measurement Height { get; set; }
    }

    public class Measurement
    {
        public decimal Reading { get; set; }
        public string Units { get; set; }
    }
    public class Person
    {
        public Person()
        {
            Address = new Address();
            Info = new PersonalInfo
            {
                Weigth = new Measurement(),
                Height = new Measurement()

            };
        }
        public int PersonId { get; set; }
        // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public PersonPhoto Photo { get; set; }
        [ConcurrencyCheck]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get {
                return String.Format("{0} {1}",
              FirstName.Trim(), LastName); }
        }
        public Address Address { get; set; }
        public PersonalInfo Info { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }

        
    }
}
