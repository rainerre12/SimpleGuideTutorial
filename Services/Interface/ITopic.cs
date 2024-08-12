using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface ITopic
    {
        //Task<ICollection<Topic>> SelectAllTopics();
        //Task<ICollection<TopicDTO>> SelectAllTopicsByRemovedFalse();
        Task<List<TopicDTO>> SelectAllTopics(bool filterRemovedStatus);
        //Task<List<TopicDTO>> SelectAllTopicsByRemovedFalse();
        Task<bool> InsertTopic(CreateTopicDTO createTopicDto);
        Task<bool> UpdateTopic(int topicId,UpdateTopicDTO updateTopicDto);
        Task<bool> DeleteTopic(int topicId);

        bool Existing(CreateTopicDTO createTopicDto);
    }
}
