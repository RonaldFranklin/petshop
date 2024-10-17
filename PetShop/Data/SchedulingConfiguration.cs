using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Modules.Scheduling;

namespace PetShop.Data;

public class SchedulingConfiguration : IEntityTypeConfiguration<SchedulingModel>
{
    public void Configure(EntityTypeBuilder<SchedulingModel> builder)
    {
        builder.ToTable("agendamento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Date).HasColumnName("data").IsRequired();
        builder.Property(x => x.Time).HasColumnName("hora").IsRequired();
        builder.Property(x => x.PetId).HasColumnName("petid").IsRequired();
        builder.Property(x => x.ServiceId).HasColumnName("servicoid").IsRequired();
        builder.Property(x => x.Status).HasColumnName("status");

        builder.HasOne(x => x.Pet).WithMany(c => c.Schedulings).HasForeignKey(x => x.PetId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Service).WithMany(c => c.Schedulings).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
    }
}
