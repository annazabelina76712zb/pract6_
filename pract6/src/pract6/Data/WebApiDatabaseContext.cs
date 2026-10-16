using Microsoft.EntityFrameworkCore;
using pract6.Models;

namespace pract6.Data;

public partial class WebApiDatabaseContext : DbContext
{
    public WebApiDatabaseContext()
    {
    }

    public WebApiDatabaseContext(DbContextOptions<WebApiDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=sql.ects;Database=WebApiDatabase;User Id=student_00;Password=student_00;TrustServerCertificate=True;Encrypt=False");
        }
    }
    //"Server=sql.ects;Database=WebApiDatabase;User Id=student_00;Password=student_00;TrustServerCertificate=True;Encrypt=False";
    // "Server=WIN-9M0BHNPHGIQ\\SQLEXPRESS;Database=WebApiDatabase;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False";
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Movies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}