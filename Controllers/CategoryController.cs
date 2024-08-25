using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGuideTutorial.DTO.Category;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _ICategory;
        public CategoryController(ICategory categoryService)
        {
            this._ICategory = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery] bool filterRemoveStatus = false)
        {
            var category = await _ICategory.SelectAllCategories(filterRemoveStatus);
            return Ok(category);
        }

        [HttpGet("active{categoryId,filterRemoveStatus}")]
        public async Task<IActionResult> GetAllCategoryByRemovedFalse(int categoryId,bool filterRemoveStatus = false)
        {
            var category = await _ICategory.SelectAllCategoriesById(categoryId,filterRemoveStatus);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategories([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            if(_ICategory.Existing(createCategoryDTO))
                return BadRequest(new { message = "Category already exists" });
            var success = await _ICategory.InsertCategory(createCategoryDTO);
            if(success)
                return Ok(new { message = "Category inserted successfully!" });
            return BadRequest(new { message = "Category inserted failed!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            var success = await _ICategory.UpdateCategory(id, updateCategoryDTO);
            if(success)
                return Ok(new { message = "Category Updated Successfully" });
            return BadRequest(new { message = "Category not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _ICategory.DeleteCategory(id);
            if(success)
                return Ok(new { message = "Category marked as removed Successfully" });
            return NotFound(new { message = "Category not found" });
        }
    }
}
