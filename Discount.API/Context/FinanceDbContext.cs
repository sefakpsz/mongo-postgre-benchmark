using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Context
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        //migration yapılmak istendiği sırada üstteki kısmı comment line'a alıp alttaki kapalı kısım açılıp daha sonra Finance.Persistence dizini içerisinde
        //dotnet ef migrations add istediğiniz-migration-ismi
        //dotnet ef database update

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql(@"User ID=admin;Password=admin;Server=localhost;Port=5432;Database=finance;Integrated Security=true;Pooling=true;", sqlOptions =>
        //     {
        //         sqlOptions.EnableRetryOnFailure(3);
        //     });
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.id)
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
            });
        }

        public DbSet<Content> content { get; set; }
    }
}