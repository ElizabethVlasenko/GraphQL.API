﻿namespace GraphQL.API.Schema.Queries
{
    public class PersonType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
