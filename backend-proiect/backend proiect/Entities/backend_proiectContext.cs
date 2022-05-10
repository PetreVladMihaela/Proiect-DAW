using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend_proiect.Entities
{
    public class backend_proiectContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>,
    IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public backend_proiectContext(DbContextOptions<backend_proiectContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Landmark> Landmarks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<LandmarkVisitor> LandmarkVisitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //Comment/Uncomment when not using/using lazy loading
                //.UseLazyLoadingProxies() 
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(@"Server=(localdb)\ProjectModels;Initial Catalog=backend_proiect;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //One to One
            builder.Entity<Landmark>()
                .HasOne(landmark => landmark.Location)
                .WithOne(location => location.Landmark);

            //One to Many
            builder.Entity<Country>()
                .HasMany(a => a.Landmarks)
                .WithOne(b => b.Country);

            //Many To Many
            builder.Entity<LandmarkVisitor>().HasKey(ac => new { ac.LandmarkId, ac.VisitorEmail });

            builder.Entity<LandmarkVisitor>()
                .HasOne(ac => ac.Landmark)
                .WithMany(a => a.LandmarkVisitors)
                .HasForeignKey(ac => ac.LandmarkId);

            builder.Entity<LandmarkVisitor>()
                .HasOne(ac => ac.Visitor)
                .WithMany(c => c.LandmarkVisitors)
                .HasForeignKey(ac => ac.VisitorEmail);
        }
    }
}