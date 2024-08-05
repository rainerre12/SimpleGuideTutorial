using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGuideTutorial.DTO.Topic;
using SimpleGuideTutorial.Model;
using SimpleGuideTutorial.Services;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopic _ITopic;
        public TopicController(ITopic topicService)
        {
            this._ITopic = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var topics = await _ITopic.SelectAllTopics(); 
            return Ok(topics);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllTopicsByRemovedFalse() 
        {
            var topics = await _ITopic.SelectAllTopicsByRemovedFalse();
            return Ok(topics);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTopic([FromBody] CreateTopicDTO createTopicDto)
        {
            if(_ITopic.Existing(createTopicDto))
                return BadRequest(new { message = "Topic already exists" });
            var success = await _ITopic.InsertTopic(createTopicDto);
            if (success)
                return Ok(new { message = "Topic inserted Successfully" });
            return BadRequest(new { message = "Topic inserted Failed" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] UpdateTopicDTO updateTopicDto) 
        {
            var success = await _ITopic.UpdateTopic(id, updateTopicDto);
            if (success)
                return Ok(new { message = "Topic updated  Successfully" });
            return BadRequest(new { message = "Topic not found" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var success = await _ITopic.DeleteTopic(id);
            if (success)
                return Ok(new { message = "Topic marked as removed successfully" });
            return NotFound(new { message = "Topic not found" });
        }
    }
}
