using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PayConnect.Domain.Entities;

namespace PayConnect.Infrastructure.EntityFramework.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<PaymentGateway> PaymentGateway { get; set; }
    public DbSet<Merchant> Merchant { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}