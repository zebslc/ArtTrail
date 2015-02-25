namespace ArtTrail.Data.Migrations.Helpers
{
    using System.Diagnostics;
    using System.Linq;

    using ArtTrail.DomainEntities;

    internal static class ArtistSeedHelper
    {
        #region Public Methods and Operators

        [Conditional("DEBUG")]
        public static void PopulateArtists(ArtTrailDataContext dataContext)
        {
            var artist = new Artist { ArtistName = "Artist1", ArtistDescription = "Artist1Desc" };
            artist.AddPainting(
                new Painting
                    {
                        PaintingName = "Painting1Name", 
                        PaintingDescription = "Painting1Desc", 
                        PaintingUrl = "Painting1Url"
                    });
            artist.AddPainting(
                new Painting
                    {
                        PaintingName = "Painting2Name", 
                        PaintingDescription = "Painting2Desc", 
                        PaintingUrl = "Painting2Url"
                    });
            var category = dataContext.Categories.First(x => x.ParentCategoryId == 0);
            artist.AddCategory(category);
            dataContext.Artists.Add(artist);
            dataContext.SaveChanges();

            var artist2 = new Artist { ArtistName = "Artist2", ArtistDescription = "Artist2Desc" };
            artist2.AddPainting(
                new Painting
                    {
                        PaintingName = "Painting3Name", 
                        PaintingDescription = "Painting3Desc", 
                        PaintingUrl = "Painting3Url"
                    });
            artist2.AddPainting(
                new Painting
                    {
                        PaintingName = "Painting4Name", 
                        PaintingDescription = "Painting4Desc", 
                        PaintingUrl = "Painting4Url"
                    });
            artist2.AddCategory(category);
            dataContext.Artists.Add(artist2);
            dataContext.SaveChanges();
        }

        #endregion
    }
}