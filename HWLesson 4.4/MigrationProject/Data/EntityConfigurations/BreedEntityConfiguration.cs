using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  Data.EntityConfigurations
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure (EntityTypeBuilder<BreedEntity> builder)
        {
            builder.ToTable("breed", schema: "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName ("id");
            builder.Property(x => x.BreedName).IsRequired().HasMaxLength(100).HasColumnName("breed_name");
            builder.Property(x => x.CategoryID).IsRequired().HasColumnName("category_id");

            builder.HasOne(h => h.Category)
                .WithMany(h => h.Breeds)
                .HasForeignKey(h => h.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
