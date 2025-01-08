using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayConnect.Domain.Entities;

namespace PayConnect.Infrastructure.EntityFramework.Configuration;

public class GatewayConfigurationConfiguration : IEntityTypeConfiguration<GatewayConfiguration>
{
    public void Configure(EntityTypeBuilder<GatewayConfiguration> builder)
    {
        builder.ToTable(nameof(GatewayConfiguration));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.MerchantId).IsRequired();
        builder.Property(x => x.PaymentGatewayId).IsRequired();
        
        builder.Property(x => x.Key).IsRequired();
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.IsSensitive).IsRequired();
        
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        
        builder.HasIndex(gc => new { gc.MerchantId, gc.PaymentGatewayId, gc.Key }).IsUnique();
        
    }
}