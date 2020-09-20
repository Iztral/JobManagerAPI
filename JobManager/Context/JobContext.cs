using JobManager.Models;
using Microsoft.EntityFrameworkCore;

namespace JobManager.Context
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job { ID = 22, Title = "Task 1", Description = "Task to be compleated." },
                new Job { ID = 1, Title = "Task 2", Description = "Task to be compleated." },
                new Job { ID = 2, Title = "Task 3", Description = "Task to be compleated." },
                new Job { ID = 3, Title = "Task 4", Description = "Task to be compleated." },
                new Job { ID = 4, Title = "Task 5", Description = "Task to be compleated." },
                new Job { ID = 5, Title = "Task 6", Description = "Task to be compleated." },
                new Job { ID = 6, Title = "Task 7", Description = "Task to be compleated." },
                new Job { ID = 7, Title = "Task 8", Description = "Task to be compleated." },
                new Job { ID = 8, Title = "Task 9", Description = "Task to be compleated." },
                new Job { ID = 9, Title = "Task 10", Description = "Task to be compleated." },
                new Job { ID = 10, Title = "Task 11", Description = "Task to be compleated." },
                new Job { ID = 11, Title = "Task 12", Description = "Task to be compleated." },
                new Job { ID = 12, Title = "Task 13", Description = "Task to be compleated." },
                new Job { ID = 13, Title = "Task 14", Description = "Task to be compleated." },
                new Job { ID = 14, Title = "Task 15", Description = "Task to be compleated." },
                new Job { ID = 15, Title = "Task 16", Description = "Task to be compleated." },
                new Job { ID = 16, Title = "Task 17", Description = "Task to be compleated." },
                new Job { ID = 17, Title = "Task 18", Description = "Task to be compleated." },
                new Job { ID = 18, Title = "Task 19", Description = "Task to be compleated." },
                new Job { ID = 19, Title = "Task 20", Description = "Task to be compleated." },
                new Job { ID = 20, Title = "Task 21", Description = "Task to be compleated." },
                new Job { ID = 21, Title = "Task 22", Description = "Task to be compleated." }
                );
        }
    }
}
