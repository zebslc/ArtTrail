namespace ArtTrail.DomainEntities
{
    using System.Collections.Generic;

    public class Artist
    {
        #region Constructors and Destructors

        public Artist()
        {
            this.Paintings = new List<Painting>();
            this.Categories = new List<Category>();
            this.Venues = new List<Venue>();
        }

        #endregion

        #region Public Properties

        public string ArtistDescription { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public IList<Category> Categories { get; private set; }

        public IList<Painting> Paintings { get; private set; }

        public IList<Venue> Venues { get; private set; }

        #endregion

        #region Public Methods and Operators

        public void AddCategory(Category categoryToAdd)
        {
            this.Categories.Add(categoryToAdd);
        }

        public void AddPainting(Painting paintingToAdd)
        {
            this.Paintings.Add(paintingToAdd);
        }

        public void AddVenue(Venue venueToAdd)
        {
            this.Venues.Add(venueToAdd);
        }

        public override string ToString()
        {
            return this.ArtistName;
        }

        #endregion
    }
}