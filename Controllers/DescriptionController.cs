using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGuideTutorial.DTO.Description;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptions _IDescriptions;
        public DescriptionController(IDescriptions descriptionService)
        {
            this._IDescriptions = descriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDescription([FromQuery] bool filterRemoveStatus = false)
        {
            var description = await _IDescriptions.SelectAllDescription(filterRemoveStatus);
            return Ok(description);
        }

        [HttpPost]
        public async Task<IActionResult> InsertDescription([FromBody] CreateDescriptionDTO createDescriptionDTO)
        {
            if (_IDescriptions.Existing(createDescriptionDTO))
                return BadRequest(new { message = "Description already exists" });
            var success = await _IDescriptions.InsertDescription(createDescriptionDTO);
            if (success)
                return Ok(new { message = "Description inserted successfully!" });
            return BadRequest(new { message = "Description inserted faile!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDescription(int id, [FromBody] UpdateDescriptionDTO updateDescriptionDTO)
        {
            var success = await _IDescriptions.UpdateDescription(id, updateDescriptionDTO);
            if (success)
                return Ok(new { message = "Description Updated Succesfully!" });
            return BadRequest(new { message = "Description not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescription(int id)
        {
            var success = await _IDescriptions.DeleteDescription(id);
            if (success)
                return Ok(new { message = "Description marked as removed successfully" });
            return NotFound(new { message = "Description not found" });
        }

    }
}
