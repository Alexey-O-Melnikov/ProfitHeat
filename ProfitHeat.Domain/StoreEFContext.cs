namespace ProfitHeat.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreEFContext : DbContext
    {
        public StoreEFContext()
            : base("name=StoreEFContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoreEFContext>());
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
        public virtual DbSet<Glass> Glases { get; set; }
        public virtual DbSet<WindowProfile> WindowsProfiles { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Radiator> Radiators { get; set; }
        public virtual DbSet<TypeRoom> TypesRooms { get; set; }
    }
}