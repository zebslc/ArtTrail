namespace ArtTrail.DomainEntities
{
    public class Painting
    {
        #region Public Properties

        public virtual Artist Artist { get; set; }

        public string PaintingDescription { get; set; }

        public int PaintingId { get; set; }

        public string PaintingName { get; set; }

        public string PaintingUrl { get; set; }

        #endregion

        #region Public Methods and Operators

        public override string ToString()
        {
            return this.PaintingName;
        }

        #endregion
    }
}