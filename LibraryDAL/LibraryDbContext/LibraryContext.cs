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
            Database.EnsureDeleted();
            Database.EnsureCreated();
            var ratings = Ratings?
                .Include(rating => rating.Book)
                .ToList();
            var reviews = Reviews?
                .Include(review => review.Book)
                .ToList();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Book-1",
                    Cover = "Cover-1",
                    Content = "Content-1",
                    Author = "Author-1",
                    Genre = "Genre-1"
                },
                new Book
                {
                    Id = 2,
                    Title = "ABook-2",
                    Cover = "Cover-2",
                    Content = "Content-2",
                    Author = "Author-2",
                    Genre = "Genre-1"
                },
                new Book
                {
                    Id = 3,
                    Title = "Book-3",
                    Cover = "Cover-3",
                    Content = "Content-3",
                    Author = "Author-3",
                    Genre = "Genre-3"
                },
                new Book
                {
                    Id = 4,
                    Title = "VBook-4",
                    Cover = "Cover-4",
                    Content = "Content-4",
                    Author = "Author-4",
                    Genre = "Genre-4"
                },
                new Book
                {
                    Id = 5,
                    Title = "Book-5",
                    Cover = "Cover-5",
                    Content = "Content-5",
                    Author = "Author-5",
                    Genre = "Genre-1"
                },
                new Book
                {
                    Id = 6,
                    Title = "CBook-6",
                    Cover = "Cover-6",
                    Content = "Content-6",
                    Author = "Author-6",
                    Genre = "Genre-6"
                },
                new Book
                {
                    Id = 7,
                    Title = "Book-7",
                    Cover = "Cover-7",
                    Content = "Content-7",
                    Author = "Author-7",
                    Genre = "Genre-7"
                },
                new Book
                {
                    Id = 8,
                    Title = "Book-8",
                    Cover = "Cover-8",
                    Content = "Content-8",
                    Author = "Author-8",
                    Genre = "Genre-8"
                },
                new Book
                {
                    Id = 9,
                    Title = "Book-9",
                    Cover = "Cover-9",
                    Content = "Content-9",
                    Author = "Author-9",
                    Genre = "Genre-9"
                },
                new Book
                {
                    Id = 10,
                    Title = "Book-10",
                    Cover = "Cover-10",
                    Content = "Content-10",
                    Author = "Author-10",
                    Genre = "Genre-10"
                }
            );
            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, Score = 3, BookId = 1},
                new Rating { Id = 2, Score = 5, BookId = 1},
                new Rating { Id = 3, Score = 3, BookId = 3},
                new Rating { Id = 4, Score = 5, BookId = 4},
                new Rating { Id = 5, Score = 5, BookId = 4},
                new Rating { Id = 6, Score = 2, BookId = 2},
                new Rating { Id = 7, Score = 1, BookId = 5}
            );
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Message = "Mess-1", Reviewer = "Rev-1", BookId = 1 },
                new Review { Id = 2, Message = "Mess-2", Reviewer = "Rev-2", BookId = 1 },
                new Review { Id = 3, Message = "Mess-3", Reviewer = "Rev-3", BookId = 2 },
                new Review { Id = 4, Message = "Mess-4", Reviewer = "Rev-4", BookId = 2 },
                new Review { Id = 5, Message = "Mess-5", Reviewer = "Rev-5", BookId = 3 },
                new Review { Id = 6, Message = "Mess-6", Reviewer = "Rev-6", BookId = 3 },
                new Review { Id = 7, Message = "Mess-7", Reviewer = "Rev-7", BookId = 4 },
                new Review { Id = 8, Message = "Mess-8", Reviewer = "Rev-8", BookId = 4 },
                new Review { Id = 9, Message = "Mess-9", Reviewer = "Rev-9", BookId = 5 }
            );

        }
    }
}
