using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minimal.Mappins
{
    public class EmployeeAddressMap : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            /// <summary>
            /// Fluent API
            /// </summary>

            #region 

            // builder.HasKey(p => p.Id);   

            builder.Property(p => p.Street)
            .HasMaxLength(255)
            .IsRequired();   

            builder.Property(p => p.AddressNumber)
            .HasMaxLength(15)
            .IsRequired(); 

            #endregion   
  
        }
    }
}