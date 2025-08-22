using Microsoft.EntityFrameworkCore;
using UsersTasks.Models.Entities;

namespace UsersTasks.Data.DBContext
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the relationship between TaskEntity and UserEntity
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.User) // Navigation property in TaskEntity
                .WithMany() // No navigation property in UserEntity
                .HasForeignKey(t => t.Assignee); // Foreign key in TaskEntity
        }
    }
}
