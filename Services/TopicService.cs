using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleGuideTutorial.Context;
using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Services
{
    public class TopicService : ITopic
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;
        public TopicService(ApplicationDbContext dbcontext, IMapper mapper) 
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<ICollection<TopicDTO>> SelectAllTopics()
        {
            var topics = await _dbcontext.Topics.ToListAsync();
            return _mapper.Map<ICollection<TopicDTO>>(topics);
        }

        public async Task<ICollection<TopicDTO>> SelectAllTopicsByRemovedFalse()
        {
            var topics = await _dbcontext.Topics.Where(x => x.Removed == false).ToListAsync();
            return _mapper.Map<ICollection<TopicDTO>>(topics);
        }

        public async Task<bool> InsertTopic(CreateTopicDto createTopicDto)
        {
           var topic = _mapper.Map<Topic>(createTopicDto);
            _dbcontext.Topics.Add(topic);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> UpdateTopic(int id, UpdateTopicDto updateTopicDto)
        {
           var existingTopic = await _dbcontext.Topics.FindAsync(id);
            if (existingTopic == null)
                return false;
            _mapper.Map(updateTopicDto, existingTopic);
            _dbcontext.Topics.Update(existingTopic);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> DeleteTopic(int id)
        {
            var topic = await _dbcontext.Topics.FindAsync(id);
            if (topic == null) 
                return false;
            //_dbcontext.Topics.Remove(topic);
            topic.Removed = true;
            _dbcontext.Topics.Update(topic);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }
    }
}
