using Bibliotek_Blazor_API.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Bibliotek_Blazor_API.Data
{
    public class BibliotekContext : DbContext
    {
        public BibliotekContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
    }
}
