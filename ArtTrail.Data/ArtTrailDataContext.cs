namespace ArtTrail.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using ArtTrail.DomainEntities;
    using ArtTrail.DomainEntities.ModelMapping;

    public class ArtTrailDataContext : DbContext, IArtTrailDataContext
    {
        #region Public Properties

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Painting> Paintings { get; set; }

        public IDbSet<Venue> Venues { get; set; }

        #endregion

        #region Public Methods and Operators

        public void InitialiseDatabase()
        {
            this.Database.Initialize(true);
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ArtistConfiguration());
            modelBuilder.Configurations.Add(new PaintingConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new VenueConfiguration());

        }

        #endregion
    }
}