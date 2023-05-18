namespace API_learn.Data
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Qtty { get; set; }
        public double Price { get; set; }
        public byte Sale { get; set; }

        //Relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
