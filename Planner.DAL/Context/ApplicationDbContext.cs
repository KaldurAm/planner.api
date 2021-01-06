using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planner.DAL.Tables;

namespace Planner.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<UserInfo> UserList { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<AreaProperty> AreaProperties { get; set; }
        public virtual DbSet<ObjectStatus> ObjectStatuses { get; set; }
        public virtual DbSet<FileExtension> FileExtensions { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<BuildingObject> Objects { get; set; }
        public virtual DbSet<TaskCard> Tasks { get; set; }
        public virtual DbSet<TaskColor> Colors { get; set; }
        public virtual DbSet<TaskHistory> TaskHistoryList { get; set; }
        public virtual DbSet<AttachFile> Files { get; set; }
        public virtual DbSet<TaskUserMap> TaskUserMappingList { get; set; }
        public virtual DbSet<FileMap> FileMappingList { get; set; }
        public virtual DbSet<ObjectPartnerMap> ObjectPartnerMappingList { get; set; }
        public virtual DbSet<ObjectHistory> ObjectHistoryList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //builder.UseSqlServer("Data source=KMERGAZIYEV\\SQLEXPRESS;Initial Catalog=Planner;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskUserMap>()
                .HasOne(o => o.User)
                .WithMany(m => m.Tasks)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TaskUserMap>()
                .HasOne(o => o.Task)
                .WithMany(m => m.ResponsibleUsers)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ObjectPartnerMap>()
                .HasOne(o => o.BuildingObject)
                .WithMany(m => m.Partners)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ObjectPartnerMap>()
                .HasOne(o => o.User)
                .WithMany(m => m.Objects)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
