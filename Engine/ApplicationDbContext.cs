using AliceHook.Models;
using Microsoft.EntityFrameworkCore;

namespace AliceHook.Engine
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
