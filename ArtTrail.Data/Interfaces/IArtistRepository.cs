namespace ArtTrail.Data.Interfaces
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public interface IArtistRepository
    {       
        /// <summary>
        /// A list of all the artist categories held
        /// </summary>
        /// <returns>A list of categories</returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        /// Returns all artists
        /// </summary>
        /// <returns>A list of artists</returns>
        IEnumerable<Artist> GetArtists();

        /// <summary>
        /// Get hold of the category id by looking up the name
        /// </summary>
        /// <param name="categoryName">A category to search against</param>
        /// <returns>A category id</returns>
        int GetCategoryIdFromName(string categoryName);
    }
}