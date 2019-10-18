using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylists
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int StylistId {get;}
          public Stylists()
        {
            this.Customer = new HashSet<Customer>();
        }
    }
}