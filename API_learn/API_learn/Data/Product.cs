using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_learn.Data
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProdName { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public byte Sale { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        //Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
