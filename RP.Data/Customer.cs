using System.Collections.Generic;

namespace RP.Data
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}