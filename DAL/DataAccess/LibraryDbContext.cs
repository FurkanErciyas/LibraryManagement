using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkout>()
                .HasKey(d => new { d.CheckoutId });

            modelBuilder.Entity<Checkout>()
                .HasOne(d => d.User)
                .WithMany(u => u.Checkouts) // User'ın birden fazla checkout'u olabilir.
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<Checkout>()
                .HasOne(d => d.Book)
                .WithMany(b => b.Checkouts) // Book'un birden fazla checkout'u olabilir.
                .HasForeignKey(d => d.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
