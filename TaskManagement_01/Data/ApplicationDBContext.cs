using Microsoft.EntityFrameworkCore;
using TaskEntity = TaskManagement_01.Models.Entities.Task;

/*namespace TaskManagement_01.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Task> Tasks { get; set; }

    }
}*/
namespace TaskManagement_01.Data // Replace with your actual namespace
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                object value = entity.HasKey(e => e.TaskId);
            });
        }
    }
}
