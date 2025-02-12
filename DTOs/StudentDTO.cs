namespace GraphQL.API.DTOs
{
    public class StudentDTO : PersonDTO
    {
        public double GPA { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }

    }
}
