using LBMS_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace LBMS_V1
{
    public class LibraryContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<borrow> Borrows { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships and configurations can be added here if needed.
        }
    }
}
