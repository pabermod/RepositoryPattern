using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RP.Data.Mappings
{
    public class CustomerMap : EntityMap<Customer>
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
            : base(entityBuilder)
        {
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.MobileNumber);
        }
    }
}