using Microsoft.EntityFrameworkCore;

namespace Backend_Project
{
    public class PeopleDataContext : DbContext
    {
        const string connectionString = "Server=localhost; User ID=root; Password=123; Database=blog";
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
