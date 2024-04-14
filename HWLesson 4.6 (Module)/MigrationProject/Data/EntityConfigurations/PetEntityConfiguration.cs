using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.ToTable("pet", schema: "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
            builder.Property(x => x.CategoryId).IsRequired().HasColumnName("category_id");
            builder.Property(x => x.BreedId).HasColumnName("breed_id");
            builder.Property(x => x.Age).HasColumnName("age");
            builder.Property(x => x.LocationId).HasColumnName("location_id");
            builder.Property(x => x.ImageURL).HasColumnName("image_url").HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(300);
            builder.HasIndex(x => new { x.BreedId, x.CategoryId, x.Name });

            builder.HasOne(x => x.Category).WithMany(x => x.Pets).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Breed).WithMany(x => x.Pets).HasForeignKey(x => x.BreedId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Location).WithMany(x => x.Pets).HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
