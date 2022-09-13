using Microsoft.EntityFrameworkCore;
using LibraryDAL.Entities;

namespace LibraryDAL.LibraryDbContext
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Rating>? Ratings { get; set; }
        public DbSet<Review>? Reviews { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> opt)
            : base(opt) 
        {
            var ratings = Ratings?
                .Include(rating => rating.Book)
                .ToList();
            var reviews = Reviews?
                .Include(review => review.Book)
                .ToList();
        }
    }
}
