using Microsoft.EntityFrameworkCore;

namespace BooksRazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
    }
}
