using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayConnect.Domain.Entities;
using PayConnect.Domain.ValueObjects;

namespace PayConnect.Infrastructure.EntityFramework.Configuration;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable(nameof(Merchant));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LegalName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).HasConversion(email => email.Address, address => Email.Create(address))
            .HasColumnName("Email").IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Document).IsRequired().HasMaxLength(14);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Currency).IsRequired().HasMaxLength(3);
        builder.Property(x => x.WebhookUrl).HasMaxLength(200);
        builder.Property(x => x.NotificationEmail).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
    }
}