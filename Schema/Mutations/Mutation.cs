using AutoMapper;
using GraphQL.API.DTOs;
using GraphQL.API.Schema.Subscriptions;
using GraphQL.API.Services.Courses;
using HotChocolate.Subscriptions;

namespace GraphQL.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public Mutation(CoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }

        public async Task<CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = _mapper.Map<CourseDTO>(courseInput);

            courseDTO = await _coursesRepository.Create(courseDTO);

            CourseResult course = _mapper.Map<CourseResult>(courseDTO);

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);

            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {

            CourseDTO courseDTO = _mapper.Map<CourseDTO>(courseInput);

            courseDTO.Id = id;

            courseDTO = await _coursesRepository.Update(courseDTO);

            CourseResult course = _mapper.Map<CourseResult>(courseDTO);

            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);

            return course;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            try
            {
                return await _coursesRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
