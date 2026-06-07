using Microsoft.EntityFrameworkCore;
using BookManager.Models;

namespace BookManager.Data
{
    public class BookManagerContext : DbContext
    {
        public BookManagerContext(DbContextOptions<BookManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Book { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}