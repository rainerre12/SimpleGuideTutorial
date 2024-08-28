namespace SimpleGuideTutorial.DTO.Description
{
    public class CreateDescriptionDTO
    {
        public string DescriptionText { get; set; }
        public int CategoryId { get; set; }
        public int? ImageId { get; set; } = 0;
        public int? VideoId { get; set; } = 0;
        public bool isRemoved = false;
    }
}
