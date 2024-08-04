using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleGuideTutorial.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Removed { get; set; } = false;

        public int TopicId { get; set; }
        public Topic topic { get; set; } // Navigation Property

        public ICollection<Description> Descriptions { get; set; } // Navigation Property
    }
}
