namespace ArtTrail.DomainEntities.ModelMapping
{
    using System.Data.Entity.ModelConfiguration;

    public class VenueConfiguration : EntityTypeConfiguration<Venue>
    {
        #region Constructors and Destructors

        public VenueConfiguration()
        {
            this.Property(x => x.VenueName).HasMaxLength(50).IsRequired();
            this.HasMany(x => x.Artists).WithMany(x => x.Venues);
            this.HasMany(c => c.Categories).WithMany(p => p.VenueCategories).Map(
                m =>
                    {
                        m.MapLeftKey("VenueId");
                        m.MapRightKey("CategoryId");
                        m.ToTable("VenueCategories");
                    });
        }

        #endregion
    }
}
