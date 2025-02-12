namespace GraphQL.API.DTOs
{
    public class InstructorDTO : PersonDTO
    {
        public decimal Salary { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }

    }
}
