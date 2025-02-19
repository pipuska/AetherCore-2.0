using Microsoft.EntityFrameworkCore;
using AetherCore.Models;
using System.Data;

namespace AetherCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Hyesosi { get; set; }
        public DbSet<FeedBack> Otsivi { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связи между User и FeedBack
            modelBuilder.Entity<FeedBack>()
                .HasOne(f => f.User) // У FeedBack есть один User
                .WithMany(u => u.FeedBacks) // У User может быть много FeedBack
                .HasForeignKey(f => f.Id_Prepod); // fk в feedback
        }
    }
}
