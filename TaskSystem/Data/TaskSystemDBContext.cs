using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.Map;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    public class TaskSystemDBContext : DbContext 
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(builder);
        }
    }
}
