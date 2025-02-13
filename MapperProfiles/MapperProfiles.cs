namespace GraphQL.API.MapperProfiles
{
    using AutoMapper;
    using GraphQL.API.DTOs;
    using GraphQL.API.Schema.Mutations;
    using GraphQL.API.Schema.Queries;

    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDTO, CourseResult>().ReverseMap();
            CreateMap<CourseInputType, CourseDTO>().ReverseMap();
            CreateMap<CourseDTO, CourseType>()
                .ForMember(d => d.Instructor, opt => opt.MapFrom(src => src.Instructor))
                .ReverseMap();

        }
    }

    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<InstructorType, InstructorDTO>().ReverseMap();
        }
    }
}
