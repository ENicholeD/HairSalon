namespace HairSalon.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int StylistId { get; set; }
        public virtual Stylist Stylist { get; set; } 
    }
}