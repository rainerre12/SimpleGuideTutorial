using AutoMapper;
using SimpleGuideTutorial.DTO.Category;
using SimpleGuideTutorial.DTO.Description;
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
            CreateMap<CreateTopicDTO, Topic>();
            CreateMap<UpdateTopicDTO, Topic>();

            #endregion Topic END

            #region Category

            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<CategoryListDTO, Category>();

            #endregion Category END

            #region Description

            CreateMap<Description, DescriptionDTO>();
            CreateMap<CreateDescriptionDTO, Description>();
            CreateMap<UpdateCategoryDTO, Description>();
            CreateMap<DescriptionListDto, Description>();

            #endregion
        }
    }
}
