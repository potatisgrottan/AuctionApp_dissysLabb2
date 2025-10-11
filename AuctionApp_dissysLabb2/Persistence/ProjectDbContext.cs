using Microsoft.EntityFrameworkCore;

namespace AuctionApp_dissysLabb2.Persistence;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)  : base(options) {}
    
    public DbSet<TaskDb> Tasks { get; set; }
    public DbSet<ProjectDb> ProjectDbs { get; set; }

    
    //Seeder
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ProjectDb pdb = new ProjectDb
        {

        };
        ModelBuilder.Entity<ProjectDb>().HasData(pdb);
    }*/
}