namespace WebApiDemo3_22_10.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string ?Fullname { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
