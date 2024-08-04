using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleGuideTutorial.Model
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Path { get; set; }
        public bool Removed { get; set; } = false;

        // Nullable foreign key and navigation property for Description
        public int? DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}
