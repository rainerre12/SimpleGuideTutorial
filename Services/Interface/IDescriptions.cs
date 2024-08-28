using SimpleGuideTutorial.DTO.Description;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface IDescriptions
    {
        Task<List<DescriptionListDto>> SelectAllDescription(bool filterRemovedStatus);
        Task<bool> InsertDescription(CreateDescriptionDTO createDescriptionDTO);
        Task<bool> UpdateDescription(int DescriptionId, UpdateDescriptionDTO updateDescriptionDTO);
        Task<bool> DeleteDescription(int DescriptionId);
        bool Existing(CreateDescriptionDTO createDescriptionDTO);
    }
}
