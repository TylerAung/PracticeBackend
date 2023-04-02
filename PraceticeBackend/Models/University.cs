using System.ComponentModel.DataAnnotations;
using PraceticeBackend.Interfaces;

namespace PraceticeBackend.Infrastructure
{

    public class School : ISchool
    {
        [Key]
        public Guid SchoolId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        public IEnumerable<IDepartment> Departments { get; set; }
        public Address AddressId { get; set; }

        public School()
        {
            this.SchoolId = new Guid();

        }
    }

    public class Department : IDepartment
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public IEnumerable<ICourse> Courses { get; set; }
        public IEnumerable<ITeacher> Teachers { get; set; }
    }

    public class Course : ICourse
    {
        [Key]
        public Guid CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 6)]
        public int Credits { get; set; }

        public IEnumerable<IStudent> Students { get; set; }
        public ITeacher Teacher { get; set; }
    }

    public class Teacher : ITeacher
    {
        [Key]
        public Guid TeacherId { get; set; }
        public UserProfile UserEntities { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        public IEnumerable<ICourse> Courses { get; set; }
    }

    public class Student : IStudent
    {
        [Key]
        public Guid StudentId { get; set; }
        public UserProfile UserEntities { get; set; }
        [Required]
        [MaxLength(2)]
        public string Grade { get; set; }
        public IEnumerable<ICourse> Courses { get; set; }
    }

}
