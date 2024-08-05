using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface ITopic
    {
        Task<ICollection<TopicDTO>> SelectAllTopics();
        Task<ICollection<TopicDTO>> SelectAllTopicsByRemovedFalse();
        Task<bool> InsertTopic(CreateTopicDTO createTopicDto);
        Task<bool> UpdateTopic(int topicId,UpdateTopicDTO updateTopicDto);
        Task<bool> DeleteTopic(int topicId);

        bool Existing(CreateTopicDTO createTopicDto);
    }
}
