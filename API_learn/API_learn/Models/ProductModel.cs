namespace API_learn.Models
{
    public class ProductModel
    {
        public string ProdName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public byte Sale { get; set; }
        public int? CategoryId { get; set; }
    }
}
