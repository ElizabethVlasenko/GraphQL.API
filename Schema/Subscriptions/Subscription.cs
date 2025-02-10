using GraphQL.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string updateCourseTopic = $"{courseId}_{nameof(CourseUpdated)}";

            return topicEventReceiver.SubscribeAsync<CourseResult>(updateCourseTopic);
        }
    }
}
