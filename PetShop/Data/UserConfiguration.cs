using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Modules.Users;

namespace PetShop.Data;

public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("cliente");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("nome").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.Password).HasColumnName("senha").IsRequired();
        builder.Property(x => x.Role).HasColumnName("perfil").IsRequired();
        builder.Property(x => x.Phone).HasColumnName("telefone");
        builder.Property(x => x.Address).HasColumnName("endereco");
        
        builder.HasMany(x => x.Pets).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Cascade);
    }
}
