using System.ComponentModel.DataAnnotations;

namespace API_learn.Models
{
    public class CategoriesModel
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
