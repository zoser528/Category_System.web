using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Categorey
    {
        // we can use data annotation to ovrride database creation convertions

        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display order should be between 1 -> 100 !! ")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
