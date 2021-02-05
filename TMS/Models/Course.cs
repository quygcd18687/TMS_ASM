using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int CatId { get; set; }
        public Category Category { get; set; }
        public object CategoryId { get; internal set; }
    }
}