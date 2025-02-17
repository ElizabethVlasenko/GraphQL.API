using GraphQL.API.Schema.Queries;
using HotChocolate.Data.Sorting;

namespace GraphQL.API.Schema.Sorters
{
    public class CourseSortType : SortInputType<CourseType>
    {
        protected override void Configure(ISortInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(c => c.InstructorId);
            descriptor.Ignore(c => c.Id);
            //descriptor.Field(c => c.Name).Name("CourseName");
            base.Configure(descriptor);
        }

    }
}
