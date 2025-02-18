using AutoMapper;
using GraphQL.API.DataLoaders;
using GraphQL.API.DTOs;
using GraphQL.API.Models;

namespace GraphQL.API.Schema.Queries
{

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public Subject Subject { get; set; }
        [IsProjected(true)]
        public Guid InstructorId { get; set; }
        [GraphQLNonNullType]
        public async Task<InstructorType> Instructor(InstructorDataLoader instructorDataLoader,
            IMapper mapper)
        {
            InstructorDTO instructorDTO = await instructorDataLoader
                .LoadAsync(InstructorId, CancellationToken.None);
            return mapper.Map<InstructorType>(instructorDTO);
        }
        public IEnumerable<StudentType> Students { get; set; }

        public string Description()
        {
            return $"{Name}: This is a course for the {Subject} subject";
        }
    }
}
