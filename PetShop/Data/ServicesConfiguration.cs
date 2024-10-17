using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShop.Modules.Services;

namespace PetShop.Data;

public class ServicesConfiguration : IEntityTypeConfiguration<ServiceModel>
{
    public void Configure(EntityTypeBuilder<ServiceModel> builder)
    {
        builder.ToTable("servico");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ServiceType).HasColumnName("tiposervico").IsRequired();
        builder.Property(x => x.Price).HasColumnName("preco");

        builder.HasMany(x => x.Schedulings).WithOne(p => p.Service).HasForeignKey(p => p.ServiceId).OnDelete(DeleteBehavior.Cascade);
    }
}