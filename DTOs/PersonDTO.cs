namespace GraphQL.API.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
