namespace ArtTrail.DomainEntities.ModelMapping
{
    using System.Data.Entity.ModelConfiguration;

    public class PaintingConfiguration : EntityTypeConfiguration<Painting>
    {
        #region Constructors and Destructors

        public PaintingConfiguration()
        {
            this.Property(x => x.PaintingName).HasMaxLength(50).IsRequired();
        }

        #endregion
    }
}