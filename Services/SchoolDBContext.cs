using GraphQL.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Services
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) { }

        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<InstructorDTO> Instructors { get; set; }
        public DbSet<StudentDTO> Students { get; set; }


    }
}
