using SimpleGuideTutorial.DTO.Category;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface ICategory
    {
        //Task<ICollection<CategoryDTO>> SelectAllCategories(int topicId);
        //Task<ICollection<CategoryDTO>> SelectAllCategoriesByRemovedFalse(int topicId);
        Task<List<CategoryDTO>> SelectAllCategories(bool filterRemovedStatus);
        Task<List<CategoryDTO>> SelectAllCategoriesById(int topicId, bool filterRemovedStatus);

        Task<bool> InsertCategory(CreateCategoryDTO createCategoryDTO);
        Task<bool> UpdateCategory(int categoryId,UpdateCategoryDTO updateCategoryDTO);
        Task<bool> DeleteCategory(int categoryId);
        bool Existing(CreateCategoryDTO createCategoryDTO);
    }
}
