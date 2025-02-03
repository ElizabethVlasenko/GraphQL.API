using Bogus;
using GraphQL.Types;

namespace GraphQL.API.Types;

[QueryType]
public class Query
{
    public IEnumerable<CourseType> GetCourse()
    {
        Faker<InstructorType> instuctorFaker = new Faker<InstructorType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Salary, f => Math.Round(f.Random.Decimal(14000, 100000), 2));

        Faker<StudentType> studentFaker = new Faker<StudentType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.GPA, f => Math.Round(f.Random.Double(1, 4), 2));

        Faker<CourseType> courseFaker = new Faker<CourseType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.JobTitle())
            .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
            .RuleFor(c => c.Instructor, f => instuctorFaker.Generate())
            .RuleFor(c => c.Students, f => studentFaker.Generate(5));

        List<CourseType> courses = courseFaker.Generate(5);

        return courses;
    }
}
