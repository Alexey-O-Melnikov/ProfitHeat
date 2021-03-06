﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using ProfitHeat.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;

namespace ProfitHeat.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StoreEFContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<Cladding> Claddings { get; set; }
        public virtual DbSet<WallLayer> WallLayers { get; set; }
        //Plot
        //public virtual DbSet<Plot> Plots { get; set; }
        //public virtual DbSet<Layer> Layers { get; set; }
        //public virtual DbSet<Item> Items { get; set; }
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
        public virtual DbSet<Pipe> Pipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey =
                        l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(o => o.Projects)
                .WithRequired()
                .HasForeignKey(o => o.UserID);

            //типы ограждающей конструкции
            //string claddingType = "CladdingType";
            //modelBuilder.Entity<Cladding>()
            //    .Map<Wall>(m =>
            //    {
            //        //m.Requires(claddingType).HasValue("Стена");
            //        m.ToTable("Wall");
            //    })
            //    .Map<Roof>(m =>
            //    {
            //        //m.Requires(claddingType).HasValue("Потолок");
            //        m.ToTable("Roof");
            //    })
            //    .Map<Floor>(m =>
            //    {
            //        //m.Requires(claddingType).HasValue("Полы");
            //        m.ToTable("Floor");
            //    })
            //    .Map<Door>(m =>
            //    {
            //        //m.Requires(claddingType).HasValue("Дверь");
            //        m.ToTable("Door");
            //    });
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                       .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);
                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}