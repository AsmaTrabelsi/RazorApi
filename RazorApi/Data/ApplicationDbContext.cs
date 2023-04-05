using Microsoft.EntityFrameworkCore;
using RazorApi.Model;

namespace RazorApi.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
