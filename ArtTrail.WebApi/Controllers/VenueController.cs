namespace ArtTrail.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class VenueController
    {
        private readonly IVenueRepository venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        public Venue GetVenueByName(string expectedVenueName)
        {
            return
                this.venueRepository.GetVenues()
                    .FirstOrDefault(x => x.VenueName.Equals(expectedVenueName, StringComparison.OrdinalIgnoreCase));
        }

        public Venue GetVenueById(int expectedVenueId)
        {
            return this.venueRepository.GetVenues().FirstOrDefault(x => x.VenueId == expectedVenueId);
        }

        public IEnumerable<Venue> GetVenueList()
        {
            return this.venueRepository.GetVenues();
        }
    }
}