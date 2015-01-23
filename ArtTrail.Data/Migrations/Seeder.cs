namespace ArtTrail.Data.Migrations
{
    using ArtTrail.Data.Migrations.Helpers;

    public class Seeder
    {
        public Seeder(ArtTrailDataContext context)
        {
            this.DataContext = context;
        }

        private ArtTrailDataContext DataContext { get; set; }

        public void Seed()
        {
            this.SetStaticData();
        }

        private void SetStaticData()
        {
            CategorySeedHelper.PopulateCategories(this.DataContext);
            ArtistSeedHelper.PopulateArtists(this.DataContext);
        }
    }
}
