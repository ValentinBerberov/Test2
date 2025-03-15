using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test2.Web.Data.Entity;

namespace Test2.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Author { get; set; } = default!;

    public DbSet<Book> Book { get; set; } = default!;

    public DbSet<Genre> Genre { get; set; } = default!;
    public DbSet<BookGenre> BookGenres { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookID, bg.GenreID });

        builder.Entity<BookGenre>()
            .HasOne(bg => bg.Book)
            .WithMany(b => b.BookGenres)
            .HasForeignKey(bg => bg.BookID);

        builder.Entity<BookGenre>()
            .HasOne(bg => bg.Genre)
            .WithMany(g => g.BookGenres)
            .HasForeignKey(bg => bg.GenreID);

        base.OnModelCreating(builder);
    }
}