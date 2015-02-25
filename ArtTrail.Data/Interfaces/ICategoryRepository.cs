namespace ArtTrail.Data.Interfaces
{
    using System.Collections.Generic;

    using ArtTrail.DomainEntities;

    public interface ICategoryRepository
    {
        /// <summary>
        ///     A list of all the categories held
        /// </summary>
        /// <returns>A list of categories</returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        ///     Get hold of the category id by looking up the name
        /// </summary>
        /// <param name="categoryName">A category to search against</param>
        /// <returns>A category id</returns>
        int GetCategoryIdFromName(string categoryName);
    }
}
