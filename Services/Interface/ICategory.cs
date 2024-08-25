using SimpleGuideTutorial.DTO.Category;

namespace SimpleGuideTutorial.Services.Interface
{
    public interface ICategory
    {
        //Task<ICollection<CategoryDTO>> SelectAllCategories(int topicId);
        //Task<ICollection<CategoryDTO>> SelectAllCategoriesByRemovedFalse(int topicId);
        Task<List<CategoryListDTO>> SelectAllCategories(bool filterRemovedStatus);
        Task<List<CategoryListDTO>> SelectAllCategoriesById(int topicId, bool filterRemovedStatus);
        Task<bool> InsertCategory(CreateCategoryDTO createCategoryDTO);
        Task<bool> UpdateCategory(int categoryId,UpdateCategoryDTO updateCategoryDTO);
        Task<bool> DeleteCategory(int categoryId);
        bool Existing(CreateCategoryDTO createCategoryDTO);
    }
}
