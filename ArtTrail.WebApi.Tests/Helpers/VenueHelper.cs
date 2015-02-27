namespace ArtTrail.WebApi.Tests.Helpers
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public static class VenueHelper
    {
        public static IEnumerable<Venue> ExampleVenues()
        {
            var venue1 = new Venue { VenueId = 1, VenueName = "Venue1" };
            venue1.AddCategory(new Category { CategoryId = 1 });
            venue1.AddCategory(new Category { CategoryId = 2 });
            venue1.AddArtist(new Artist { ArtistId = 1, ArtistName = "A" });
            venue1.AddArtist(new Artist { ArtistId = 2, ArtistName = "B" });

            var venue2 = new Venue { VenueId = 2, VenueName = "Venue2" };
            venue1.AddCategory(new Category { CategoryId = 2 });

            return new List<Venue> { venue1, venue2 };
        }

    }
}
