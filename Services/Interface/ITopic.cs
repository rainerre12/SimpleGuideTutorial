﻿using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface ITopic
    {
        Task<ICollection<TopicDTO>> SelectAllTopics();
        Task<ICollection<TopicDTO>> SelectAllTopicsByRemovedFalse();
        Task<bool> InsertTopic(CreateTopicDto createTopicDto);
        Task<bool> UpdateTopic(int id,UpdateTopicDto updateTopicDto);
        Task<bool> DeleteTopic(int id);
    }
}
