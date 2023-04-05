using System.ComponentModel.DataAnnotations;

namespace RazorApi.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display order")]
        [Range(1,1000,ErrorMessage ="Display order should be between 1 and 1000")]
        public int DisplayOrder { get; set; }
    }
}
