namespace ArtTrail.DomainEntities
{
    public class Painting
    {
        public virtual Artist Artist { get; set; }

        public int PaintingId { get; set; }

        public string PaintingName { get; set; }

        public string PaintingDescription { get; set; }

        public string PaintingUrl { get; set; }

        public override string ToString()
        {
            return this.PaintingName;
        }
    }
}