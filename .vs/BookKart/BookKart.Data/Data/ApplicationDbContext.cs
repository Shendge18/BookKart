using BookKart.Models;
using Microsoft.EntityFrameworkCore;

namespace BookKart.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryDALModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDALModel>().HasData(
                new CategoryDALModel { Id = 1, Name = "Action", DisplayOrder = 1 },
                new CategoryDALModel { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new CategoryDALModel { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
