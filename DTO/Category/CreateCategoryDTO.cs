namespace SimpleGuideTutorial.DTO.Category
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public bool Removed { get; set; } = false;
        public int TopicId { get; set; }
    }
}
