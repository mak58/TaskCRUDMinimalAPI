using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minimal.Mappins
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            /// <summary>
            /// Fluent API
            /// </summary>

            #region 

            builder.HasKey(e => e.Id);    

            builder.Property(p => p.FirstName)
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(p => p.LastName)
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsRequired(false);
            
            
            #endregion
  
        }
    }
}