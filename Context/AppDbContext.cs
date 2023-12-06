using Microsoft.EntityFrameworkCore;
using UnityApi.Model;

namespace UnityApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                entity.Property(e => e.Age).HasColumnName("Age").IsRequired();
                entity.Property(e => e.OnOff).HasColumnName("OnOff").IsRequired();
            });
        }
    }
}
