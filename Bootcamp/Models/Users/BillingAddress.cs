using Bootcamp.Models.Users;

namespace Bootcamp.Models.Users
{
    public class BillingAddress
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public User Users { get; set; }
    }
}
