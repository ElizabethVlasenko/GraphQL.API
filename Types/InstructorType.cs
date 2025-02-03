namespace GraphQL.Types
{
    public class InstructorType : PersonType
    {
        public double GPA { get; set; }
        public decimal Salary { get; set; }
    }
}
