using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class Context : DbContext
{
    public Context()
    {
        
    }
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostUsersLikes> PostsUserLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().OwnsOne(x => x.Address);

        modelBuilder.Entity<PostUsersLikes>().HasKey(x => new { x.PostId, x.UserId });

        modelBuilder.Entity<PostUsersLikes>().HasOne(x => x.Post)
            .WithMany(p => p.PostUsersLiked)
            .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<PostUsersLikes>().HasOne(x => x.User)
            .WithMany(p => p.PostUsersLiked)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Argentina"
            },
            new Country
            {
                Id = 2,
                Name = "Brasil"
            },
            new Country
            {
                Id = 3,
                Name = "Chile"
            },
            new Country
            {
                Id = 4,
                Name = "Paraguay"
            },
            new Country
            {
                Id = 5,
                Name = "Uruguay"
            }
        );

        modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = 4,
                Name = "Buenos Aires",
                CountryId = 1
            },new Province
            {
                Id = 1,
                Name = "Córdoba",
                CountryId = 1
            },new Province
            {
                Id = 2,
                Name = "Tucumán",
                CountryId = 1
            },new Province
            {
                Id = 3,
                Name = "Santa Fé",
                CountryId = 1
            }
        );
    }
}