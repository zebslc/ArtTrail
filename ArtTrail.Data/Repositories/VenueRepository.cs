namespace ArtTrail.Data.Repositories
{
    using System.Collections.Generic;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class VenueRepository : IVenueRepository
    {       
        #region Fields

        private readonly IArtTrailDataContext dataContext;

        #endregion

        #region Constructors and Destructors

        public VenueRepository(IArtTrailDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #endregion


        public IEnumerable<Venue> GetVenues()
        {
            return this.dataContext.Venues;
        }
    }
}
