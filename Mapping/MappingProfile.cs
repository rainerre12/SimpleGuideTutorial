using AutoMapper;
using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;

namespace SimpleGuideTutorial.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region Topic

            CreateMap<Topic, TopicDTO>();
            CreateMap<CreateTopicDto, Topic>();
            CreateMap<UpdateTopicDto, Topic>();
            
            #endregion
            
        }
    }
}
