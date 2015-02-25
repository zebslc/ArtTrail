namespace ArtTrail.Data.Interfaces
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public interface IVenueRepository
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Returns all venues
        /// </summary>
        /// <returns>A list of venues</returns>
        IEnumerable<Venue> GetVenues();

        #endregion
    }
}