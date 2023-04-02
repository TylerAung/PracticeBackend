using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PraceticeBackend.Interfaces;

namespace PraceticeBackend.Infrastructure
{
    public class State
    {
        [Key]
        public Guid StateId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string Abbreviation { get; set; }

        public ICollection<City> Cities { get; set; }
    }

    public class City
    {
        [Key]
        public Guid CityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //[Required]
        [ForeignKey("StateId")]
        public State State { get; set; }

        
    }

    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string ApartmentNumber { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public ICity City { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        public ICollection<UserProfile> UserEntities { get; set; }
    }

}
