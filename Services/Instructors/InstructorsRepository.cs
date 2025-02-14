using GraphQL.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Services.Instructors
{
    public class InstructorsRepository
    {
        private readonly IDbContextFactory<SchoolDBContext> _contextFactory;
        public InstructorsRepository(IDbContextFactory<SchoolDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<InstructorDTO> GetById(Guid instructorId)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors
                    .FirstOrDefaultAsync(c => c.Id == instructorId);
            }
        }

        public async Task<IEnumerable<InstructorDTO>> GetManyByIds(IReadOnlyList<Guid> instructorIds)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors
                    .Where(i => instructorIds.Contains(i.Id))
                    .ToListAsync();
            }
        }
    }
}