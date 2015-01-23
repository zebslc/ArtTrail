namespace ArtTrail.Data
{
    using System.Data.Entity;

    using ArtTrail.DomainEntities;

    public interface IArtTrailDataContext
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Painting> Paintings { get; set; }

        void InitialiseDatabase();

    }
}