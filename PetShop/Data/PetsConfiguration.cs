using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Modules.Pets;

namespace PetShop.Data;

public class PetsConfiguration : IEntityTypeConfiguration<PetModel>
{
    public void Configure(EntityTypeBuilder<PetModel> builder)
    {
        builder.ToTable("pet");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("nome").IsRequired();
        builder.Property(x => x.Race).HasColumnName("raca").IsRequired();
        builder.Property(x => x.Size).HasColumnName("porte").IsRequired();
        builder.Property(x => x.OwnerId).HasColumnName("clienteid").IsRequired();

        builder.HasOne(x => x.Owner).WithMany(c => c.Pets).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Schedulings).WithOne(p => p.Pet).HasForeignKey(p => p.PetId).OnDelete(DeleteBehavior.Cascade);
    }
}