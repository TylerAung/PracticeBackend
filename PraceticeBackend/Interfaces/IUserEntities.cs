using PraceticeBackend.Infrastructure;

namespace PraceticeBackend.Interfaces
{
    public interface IUserEntities
    {
        Guid EntityId { get; set; }
        string FullName { get; set;}
        char Gender { get; set; }
        string PreferredName { get; set; }
        string IdentityNo { get; set; }
        int DOB { get; set; }
        Address AddressId { get; set; }
        short PhoneNumber { get; set; }
    }
}
