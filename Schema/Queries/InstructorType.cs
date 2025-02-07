namespace GraphQL.API.Schema.Queries
{
    public class InstructorType : PersonType
    {
        public double GPA { get; set; }
        public decimal Salary { get; set; }
    }
}
