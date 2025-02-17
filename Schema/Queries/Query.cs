using AutoMapper;
using GraphQL.API.DTOs;
using GraphQL.API.Services;
using GraphQL.API.Services.Courses;

namespace GraphQL.API.Schema.Queries;

[QueryType]
public class Query
{
    private readonly CoursesRepository _coursesRepository;
    private readonly IMapper _mapper;
    public Query(CoursesRepository coursesRepository, IMapper mapper)
    {
        _coursesRepository = coursesRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<CourseType>> GetCourse()
    {
        IEnumerable<CourseDTO> courseDTOList = await _coursesRepository.GetAll();
        IEnumerable<CourseType> courses = _mapper.Map<IEnumerable<CourseType>>(courseDTOList);

        return courses;
    }

    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    public IQueryable<CourseType> GetPaginatingCourse(SchoolDBContext context)
    {
        IQueryable<CourseType> courses = context.Courses.Select(c => _mapper.Map<CourseType>(c));

        return courses;
    }

    public async Task<CourseType> GetCourseByIdAsync(Guid id)
    {
        CourseDTO courseDTO = await _coursesRepository.GetById(id);
        CourseType course = _mapper.Map<CourseType>(courseDTO);

        return course;

    }
}
