namespace ArtTrail.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class ArtistRepository : IArtistRepository
    {
        private readonly IArtTrailDataContext dataContext;

        public ArtistRepository(IArtTrailDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.dataContext.Categories;
        }

        public IEnumerable<Artist> GetArtists()
        {
            return this.dataContext.Artists;
        }

        public int GetCategoryIdFromName(string categoryName)
        {
            var categories = this.GetCategories()
                .FirstOrDefault(x => x.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            return categories != null ? categories.CategoryId : 0;
        }
    }
}