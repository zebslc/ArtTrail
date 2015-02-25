namespace ArtTrail.Data.Migrations
{
    using ArtTrail.Data.Migrations.Helpers;

    public class Seeder
    {
        #region Constructors and Destructors

        public Seeder(ArtTrailDataContext context)
        {
            this.DataContext = context;
        }

        #endregion

        #region Properties

        private ArtTrailDataContext DataContext { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Seed()
        {
            this.SetStaticData();
        }

        #endregion

        #region Methods

        private void SetStaticData()
        {
            CategorySeedHelper.PopulateCategories(this.DataContext);
            ArtistSeedHelper.PopulateArtists(this.DataContext);
        }

        #endregion
    }
}