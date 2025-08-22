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
    }
}
