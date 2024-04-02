using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using DataObjectLayer;


namespace DataAccessLayer
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Mark Stark",
                    UserName = "stark123",
                    Email = "mark@gmail.com",
                    Password = "mark@123",
                    ConfirmPassword= "mark@123",
                    Tokens_Available=1,
                    Books_Borrowed=0,
                    Books_Lent=0,
                    Token = " "
                },
                new User
                {
                    Id = 2,
                    Name = "Rupali Singh",
                    UserName = "rups",
                    Email = "rups@gmail.com",
                    Password = "rupali@123",
                    ConfirmPassword = "rupali@123",
                    Tokens_Available = 1,
                    Books_Borrowed = 0,
                    Books_Lent = 0,
                    Token = " "
                },
                new User
                {
                    Id = 3,
                    Name = "Ronit Roy",
                    UserName = "ronit",
                    Email = "ronit@gmail.com",
                    Password = "ronitroy@123",
                    ConfirmPassword = "ronitroy@123",
                    Tokens_Available = 1,
                    Books_Borrowed = 0,
                    Books_Lent = 0,
                    Token = " "
                },
                new User
                {
                    Id = 4,
                    Name = "John Disouza",
                    UserName = "john",
                    Email = "john@gmail.com",
                    Password = "abc@123",
                    ConfirmPassword = "abc@123",
                    Tokens_Available = 1,
                    Books_Borrowed = 0,
                    Books_Lent = 0,
                    Token = " "
                }
            );
        }
    }
}