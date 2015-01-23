namespace ArtTrail.DomainEntities
{
    using System.Collections.Generic;

    public class Artist
    {
        public Artist()
        {
            this.Paintings = new List<Painting>();
            this.Categories = new List<Category>();
        }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string ArtistDescription { get; set; }

        public IList<Category> Categories { get; private set; }

        public IList<Painting> Paintings { get; private set; }

        public void AddPainting(Painting paintingToAdd)
        {
            this.Paintings.Add(paintingToAdd);
        }

        public void AddCategory(Category categoryToAdd)
        {
            this.Categories.Add(categoryToAdd);
        }
        
        public override string ToString()
        {
            return this.ArtistName;
        }
    }
}
