namespace SimpleGuideTutorial.DTO.Category
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TopicName { get; set; }
        public bool Removed { get; set; }
        public int TopicId { get; set; }
    }
}
