using PraceticeBackend.Infrastructure;

namespace PraceticeBackend.Interfaces
{
    public interface IAddress
    {
        Guid AddressId { get; set; }
        string Street { get; set; }
        string ApartmentNumber { get; set; }
        string ZipCode { get; set; }
        int CityId { get; set; }
        ICity City { get; set; }
        ICollection<UserProfile> UserEntities { get; set; }
    }

    public interface ICity
    {
        Guid CityId { get; set; }
        string Name { get; set; }
        int StateId { get; set; }
        IState State { get; set; }
    }

    public interface IState
    {
        Guid StateId { get; set; }
        string Name { get; set; }
        string Abbreviation { get; set; }
    }

}
