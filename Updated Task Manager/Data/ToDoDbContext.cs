using Microsoft.EntityFrameworkCore;

using Updated_Task_Manager.Models;

namespace Updated_Task_Manager.Data
{
    public class ToDoDbContext : DbContext
    {


        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
