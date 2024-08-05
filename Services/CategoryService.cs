using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleGuideTutorial.Context;
using SimpleGuideTutorial.DTO.Category;
using SimpleGuideTutorial.Model;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryDTO>> SelectAllCategories(int topicId)
        {
            var categories = await _dbcontext.Categories.Where(x => x.TopicId == topicId).ToListAsync();
            return _mapper.Map<ICollection<CategoryDTO>>(categories);
        }

        public async Task<ICollection<CategoryDTO>> SelectAllCategoriesByRemovedFalse(int topicId)
        {
            var categories = await _dbcontext.Categories.Where(x => x.TopicId == topicId && x.Removed == false).ToListAsync();
            return _mapper.Map<ICollection<CategoryDTO>>(categories);
        }

        public async Task<bool> InsertCategory(CreateCategoryDTO createCategoryDTO)
        {
            var categories = _mapper.Map<Category>(createCategoryDTO);
            _dbcontext.Categories.Add(categories);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateCategory(int categoryId, UpdateCategoryDTO updateCategoryDTO)
        {
            var existingCategory = await _dbcontext.Categories.FindAsync(categoryId);
            if (existingCategory == null)
                return false;
            _mapper.Map(updateCategoryDTO, existingCategory);
            _dbcontext.Categories.Update(existingCategory);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _dbcontext.Categories.FindAsync(categoryId);
            if (category == null) 
                return false;
            category.Removed = true;
            _dbcontext.Categories.Update(category);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public bool Existing(CreateCategoryDTO createCategoryDTO)
        {
            var result = _dbcontext.Categories.Where(x => x.Name == createCategoryDTO.Name);
            if (result.Count() > 0)
                return true;
            return false;
        }
    }
}
