using Bogus;
using GraphQL.API.Models;

namespace GraphQL.API.Schema.Queries;

[QueryType]
public class Query
{
    private readonly Faker<InstructorType> _instuctorFaker;
    private readonly Faker<StudentType> _studentFaker;
    private readonly Faker<CourseType> _courseFaker;

    public Query()
    {
        _instuctorFaker = new Faker<InstructorType>()
           .RuleFor(c => c.Id, f => Guid.NewGuid())
           .RuleFor(c => c.FirstName, f => f.Name.FirstName())
           .RuleFor(c => c.LastName, f => f.Name.LastName())
           .RuleFor(c => c.Salary, f => Math.Round(f.Random.Decimal(14000, 100000), 2));

        _studentFaker = new Faker<StudentType>()
             .RuleFor(c => c.Id, f => Guid.NewGuid())
             .RuleFor(c => c.FirstName, f => f.Name.FirstName())
             .RuleFor(c => c.LastName, f => f.Name.LastName())
             .RuleFor(c => c.GPA, f => Math.Round(f.Random.Double(1, 4), 2));

        _courseFaker = new Faker<CourseType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.JobTitle())
            .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
            .RuleFor(c => c.Instructor, f => _instuctorFaker.Generate())
            .RuleFor(c => c.Students, f => _studentFaker.Generate(5));

    }


    public IEnumerable<CourseType> GetCourse()
    {
        return _courseFaker.Generate(5);
    }

    public async Task<CourseType> GetCourseByIdAsync(Guid id)
    {
        await Task.Delay(1000);

        CourseType course = _courseFaker.Generate();

        course.Id = id;

        return course;
    }
}
