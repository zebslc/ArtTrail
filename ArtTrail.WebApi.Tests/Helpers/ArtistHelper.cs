namespace ArtTrail.WebApi.Tests.Helpers
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public static class ArtistHelper
    {

       public static IEnumerable<Artist> ExampleArtists()
       {
           var artist1 = new Artist { ArtistId = 1, ArtistName = "Artist1" };
           artist1.AddCategory(new Category { CategoryId = 1 });
           artist1.AddCategory(new Category { CategoryId = 2 });
           artist1.AddPainting(new Painting { PaintingId = 1, PaintingName = "A" });
           artist1.AddPainting(new Painting { PaintingId = 2, PaintingName = "B" });

           var artist2 = new Artist { ArtistId = 2, ArtistName = "Artist2" };
           artist1.AddCategory(new Category { CategoryId = 2 });

           return new List<Artist> { artist1, artist2 };
       }
    }
}
