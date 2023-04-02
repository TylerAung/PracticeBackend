using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PraceticeBackend.Interfaces;

namespace PraceticeBackend.Infrastructure
{
    public class UserProfile : IUserEntities
    {
        [Key]
        public Guid EntityId { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public string PreferredName { get; set; }
        public string IdentityNo { get; set; }
        public int DOB { get; set; }
        [ForeignKey("AddressId")]
        public Address AddressId { get; set; }
        public short PhoneNumber { get; set; }
    }
}
