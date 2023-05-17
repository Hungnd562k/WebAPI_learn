namespace API_learn.Models
{
    public class ProductVM
    {
        public string ProdName { get; set; }
        public double Price { get; set; }
    }
    public class Product : ProductVM
    {
        public Guid ProdId { get; set; }
    }
}
