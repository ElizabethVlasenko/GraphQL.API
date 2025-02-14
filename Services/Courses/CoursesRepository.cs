using GraphQL.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Services.Courses
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDBContext> _contextFactory;
        public CoursesRepository(IDbContextFactory<SchoolDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .ToListAsync();
            }
        }
        public async Task<CourseDTO> GetById(Guid courseId)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .FirstOrDefaultAsync(c => c.Id == courseId);
            }
        }

        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    Id = id
                };

                context.Courses.Remove(course);
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
