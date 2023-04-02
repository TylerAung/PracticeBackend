using PraceticeBackend.Infrastructure;

namespace PraceticeBackend.Interfaces
{
    public interface ISchool
    {
        Guid SchoolId { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        IEnumerable<IDepartment> Departments { get; set; }
        Address AddressId { get; set; }
    }

    public interface IDepartment
    {
        Guid DepartmentId { get; set; }
        string Name { get; set; }
        IEnumerable<ICourse> Courses { get; set; }
        IEnumerable<ITeacher> Teachers { get; set; }
    }

    public interface ICourse
    {
        Guid CourseId { get; set; }
        string Name { get; set; }
        int Credits { get; set; }
        IEnumerable<IStudent> Students { get; set; }
        ITeacher Teacher { get; set; }
    }

    public interface ITeacher
    {
        Guid TeacherId { get; set; }
        string Subject { get; set; }
        UserProfile UserEntities { get; set; }
        IEnumerable<ICourse> Courses { get; set; }
    }

    public interface IStudent
    {
        Guid StudentId { get; set; }
        string Grade { get; set; }
        UserProfile UserEntities { get; set; }
        IEnumerable<ICourse> Courses { get; set; }
    }

}
