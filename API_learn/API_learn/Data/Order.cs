namespace API_learn.Data
{
    public enum OrderStatus
    {
        New = 0, Completed = 1, Canceled = -1
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
