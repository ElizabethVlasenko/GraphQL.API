using GraphQL.API.Schema.Queries;

namespace GraphQL.API.Schema.Mutations
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid instructorId { get; set; }

    }
}
