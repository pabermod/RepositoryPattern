using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RP.Data.Mappings
{
    public class AddressMap : EntityMap<Address>
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
            : base(entityBuilder)
        {
            entityBuilder.Property(t => t.AddressLine1).IsRequired();
            entityBuilder.Property(t => t.Street).IsRequired();
            entityBuilder.Property(t => t.City).IsRequired();
            entityBuilder.Property(t => t.Postcode).IsRequired();
            entityBuilder.HasOne(e => e.Customer).WithMany(e => e.Addresses).HasForeignKey(e => e.CustomerId);
        }
    }
}