using DataScribeCloudePrototype.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace DataScribeCloudePrototype.Server.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Notes> Notes { get; set; }
    public DbSet<Audio> Audio { get; set; }
    public DbSet<DocFiles> DocFiles { get; set; }
    public DbSet<Pdf> Pdf { get; set; }
}
