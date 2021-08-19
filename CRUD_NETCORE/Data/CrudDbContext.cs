using CRUD_NETCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_NETCORE.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Students> Students { get; set; }


    }
}
