namespace ArtTrail.DomainEntities
{
    using System.Collections.Generic;

    public class Venue
    {
        #region Constructors and Destructors

        public Venue()
        {
            this.Categories = new List<Category>();
            this.Artists = new List<Artist>();
        }

        #endregion

        #region Public Properties

        public IList<Artist> Artists { get; private set; }

        public IList<Category> Categories { get; private set; }

        public string VenueDescription { get; set; }

        public int VenueId { get; set; }

        public string VenueName { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddArtist(Artist artistToAdd)
        {
            this.Artists.Add(artistToAdd);
        }

        public void AddCategory(Category categoryToAdd)
        {
            this.Categories.Add(categoryToAdd);
        }

        public override string ToString()
        {
            return this.VenueName;
        }

        #endregion
    }
}