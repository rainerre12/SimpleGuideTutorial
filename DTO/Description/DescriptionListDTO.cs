namespace SimpleGuideTutorial.DTO.Description
{
    public class DescriptionListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public bool isRemoved { get; set; }
    }
}
