namespace HairSalon.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int stylistId { get; set; }
        public virtual Stylists Stylists { get; set; } 
    }
}