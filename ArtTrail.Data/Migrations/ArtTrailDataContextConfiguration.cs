namespace ArtTrail.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics;

    public sealed class ArtTrailDataContextConfiguration : DbMigrationsConfiguration<ArtTrailDataContext>
    {
        #region Constructors and Destructors

        public ArtTrailDataContextConfiguration()
        {
            this.SetMigrationStatus();
        }

        #endregion

        #region Methods

        protected override void Seed(ArtTrailDataContext context)
        {
            var seeder = new Seeder(context);
            seeder.Seed();

            base.Seed(context);
        }

        [Conditional("DEBUG")]
        private void SetMigrationStatus()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        #endregion
    }
}