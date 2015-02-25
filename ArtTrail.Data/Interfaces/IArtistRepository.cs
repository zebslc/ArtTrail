namespace ArtTrail.Data.Interfaces
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public interface IArtistRepository
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Returns all artists
        /// </summary>
        /// <returns>A list of artists</returns>
        IEnumerable<Artist> GetArtists();

        #endregion
    }
}