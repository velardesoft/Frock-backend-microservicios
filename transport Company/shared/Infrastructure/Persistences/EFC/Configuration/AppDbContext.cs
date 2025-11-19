using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Frock_backend.shared.Infrastructure.Persistences.EFC.Configuration.Extensions;
using Frock_backend.transport_Company.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Frock_backend.shared.Infrastructure.Persistences.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // COMPANY
            builder.Entity<Company>(b =>
            {
                b.HasKey(f => f.Id);
                b.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
                b.Property(f => f.Name).IsRequired();
                b.Property(f => f.LogoUrl).IsRequired();
                b.Property(f => f.FkIdUser).IsRequired();
            });

            builder.UseSnakeCaseNamingConvention();
        }
    }
}