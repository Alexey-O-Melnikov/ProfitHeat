namespace ProfitHeat.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration;    //using WebUI.Models;
    public class StoreEFContext : DbContext
    {
        public StoreEFContext()
            : base("name=StoreEFContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoreEFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Keep this:
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            // Change TUser to ApplicationUser everywhere else - IdentityUser 
            // and ApplicationUser essentially 'share' the AspNetUsers Table in the database:
            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            // EF won't let us swap out IdentityUserRole for ApplicationUserRole here:
            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            // Leave this alone:
            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey =
                        l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            // Add this, so that IdentityRole can share a table with ApplicationRole:
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            modelBuilder.Entity<ApplicationUser>()
                // Настройка связи между таблицами
                .HasMany(o => o.Projects)
                .WithRequired()
                // Указание внешнего ключа
                .HasForeignKey(o => o.UserID);
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<Cladding> Claddings { get; set; }
        public virtual DbSet<WallLayer> WallLayers { get; set; }
        //Plot
        public virtual DbSet<Plot> Plots { get; set; }
        public virtual DbSet<Layer> Layers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        //Tabular
        public virtual DbSet<Glass> Glasses { get; set; }
        public virtual DbSet<WindowProfile> WindowsProfiles { get; set; }
        public virtual DbSet<ManufacturerWindowProfile> ManufacturerWindowProfiles { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Radiator> Radiators { get; set; }
        public virtual DbSet<ManufacturerRadiator> ManufacturerRadiators { get; set; }
        public virtual DbSet<MaterialRadiator> MaterialRadiators { get; set; }
        public virtual DbSet<TypeRoom> TypesRooms { get; set; }

    }
}