namespace ArtTrail.Data.Interfaces
{
    using System;
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public interface IVenueRepository
    {
        IEnumerable<Venue> GetVenues();
    }
}
