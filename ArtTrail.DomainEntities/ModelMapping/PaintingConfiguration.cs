namespace ArtTrail.DomainEntities.ModelMapping
{
    using System.Data.Entity.ModelConfiguration;

    public class PaintingConfiguration : EntityTypeConfiguration<Painting>
    {
        public PaintingConfiguration()
        {
            this.Property(x => x.PaintingName).HasMaxLength(50).IsRequired();
        }
    }
}
