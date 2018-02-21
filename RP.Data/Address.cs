using System;

namespace RP.Data
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}