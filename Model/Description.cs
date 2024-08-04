using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleGuideTutorial.Model
{
    public class Description
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DescriptionText { get; set; }
        public bool Removed { get; set; } = false;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Nullable foreign key and navigation property for Image
        public int? ImageId { get; set; }
        public Image Image { get; set; }

        // Nullable foreign key and navigation property for Video
        public int? VideoId { get; set; }
        public Video Video { get; set; }
    }
}
