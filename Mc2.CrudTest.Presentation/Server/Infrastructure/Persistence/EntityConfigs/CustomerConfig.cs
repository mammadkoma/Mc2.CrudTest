using Mc2.CrudTest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Presentation.Server.Infrastructure.Persistence.EntityConfigs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("DateTime2(2)").IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(14)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.BankAccountNumber).HasColumnType("decimal(18,0)").IsRequired();

            builder.HasData(new Customer // Seed
            {
                Id = 1,
                FirstName = "Mohammad",
                LastName = "Komaei",
                DateOfBirth = new System.DateTime(1986, 07, 28),
                PhoneNumber = "+989371448346",
                Email = "komaei@live.com",
                BankAccountNumber = 123456789,
            });
        }
    }
}