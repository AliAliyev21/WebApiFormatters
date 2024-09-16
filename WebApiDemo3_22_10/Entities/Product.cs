namespace WebApiDemo3_22_10.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
