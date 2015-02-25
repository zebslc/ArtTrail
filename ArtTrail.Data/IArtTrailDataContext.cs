namespace ArtTrail.Data
{
    using System.Data.Entity;

    using ArtTrail.DomainEntities;

    public interface IArtTrailDataContext
    {
        #region Public Properties

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Painting> Paintings { get; set; }

        IDbSet<Venue> Venues { get; set; }

        #endregion

        #region Public Methods and Operators

        void InitialiseDatabase();

        #endregion
    }
}