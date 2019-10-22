using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
          public Stylist()
        {
            this.Customers = new HashSet<Customer>();
        }
          public string FirstName {get; set;}
        public string LastName {get; set;}
        public int StylistId {get; set;}
         public virtual ICollection<Customer> Customers {get; set; }
    }
}