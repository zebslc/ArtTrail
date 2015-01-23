namespace ArtTrail.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using ArtTrail.DomainEntities;
    using ArtTrail.DomainEntities.ModelMapping;

    public class ArtTrailDataContext : DbContext, IArtTrailDataContext
    {
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Painting> Paintings { get; set; }

        public void InitialiseDatabase()
        {
            this.Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ArtistConfiguration());
            modelBuilder.Configurations.Add(new PaintingConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}