namespace ArtTrail.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class ArtistRepository : IArtistRepository
    {
        #region Fields

        private readonly IArtTrailDataContext dataContext;

        #endregion

        #region Constructors and Destructors

        public ArtistRepository(IArtTrailDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #endregion

        #region Public Methods and Operators

        public IEnumerable<Artist> GetArtists()
        {
            return this.dataContext.Artists;
        }

        #endregion
    }
}