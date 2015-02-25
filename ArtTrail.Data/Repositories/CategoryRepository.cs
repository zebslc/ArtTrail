namespace ArtTrail.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class CategoryRepository : ICategoryRepository
    {
        #region Fields

        private readonly IArtTrailDataContext dataContext;

        #endregion

        #region Constructors and Destructors

        public CategoryRepository(IArtTrailDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #endregion

        public IEnumerable<Category> GetCategories()
        {
            return this.dataContext.Categories;
        }

        public int GetCategoryIdFromName(string categoryName)
        {
            var categories =
                this.GetCategories()
                    .FirstOrDefault(x => x.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            return categories != null ? categories.CategoryId : 0;
        }
    }
}
