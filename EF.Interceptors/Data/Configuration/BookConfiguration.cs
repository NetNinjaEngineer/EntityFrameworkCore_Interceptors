using EF.Interceptors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Interceptors.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(18, 2).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.ToTable("Books");
        }
    }
}
