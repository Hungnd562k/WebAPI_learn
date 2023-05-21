using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_learn.Data
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Categories()
        {
            ICollection<Product> Products = new List<Product>();
        }
    }
}
