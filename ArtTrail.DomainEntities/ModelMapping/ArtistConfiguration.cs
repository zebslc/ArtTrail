namespace ArtTrail.DomainEntities.ModelMapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ArtistConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistConfiguration()
        {
            this.Property(x => x.ArtistName).HasMaxLength(50).IsRequired();
            this.HasMany(x => x.Paintings).WithRequired(x => x.Artist);
            this.HasMany(c => c.Categories)
                .WithMany(p => p.ArtistCategories)
                .Map(m =>
                    {
                        m.MapLeftKey("ArtistId");
                        m.MapRightKey("CategoryId");
                        m.ToTable("ArtistCategories");
                    });
        }
    }
}
