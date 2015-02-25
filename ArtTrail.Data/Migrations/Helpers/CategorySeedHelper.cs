namespace ArtTrail.Data.Migrations.Helpers
{
    using System.Diagnostics;

    using ArtTrail.DomainEntities;

    internal static class CategorySeedHelper
    {
        #region Public Methods and Operators

        [Conditional("DEBUG")]
        public static void PopulateCategories(ArtTrailDataContext dataContext)
        {
            var master1 =
                dataContext.Categories.Add(
                    new Category
                        {
                            CategoryName = "MasterCatA", 
                            IsVenueOnlyCategory = false, 
                            CategoryDescription = "Master Category A", 
                            ParentCategoryId = 0
                        });
            dataContext.SaveChanges();

            dataContext.Categories.Add(
                new Category
                    {
                        CategoryName = "ChildA", 
                        CategoryDescription = "Child category A", 
                        IsVenueOnlyCategory = false, 
                        ParentCategoryId = master1.CategoryId
                    });
            dataContext.SaveChanges();

            dataContext.Categories.Add(
                new Category
                    {
                        CategoryName = "ChildB", 
                        CategoryDescription = "Child category B", 
                        IsVenueOnlyCategory = false, 
                        ParentCategoryId = master1.CategoryId
                    });
            dataContext.SaveChanges();
            dataContext.Categories.Add(
                new Category
                    {
                        CategoryName = "MasterCatB", 
                        IsVenueOnlyCategory = true, 
                        CategoryDescription = "Master Category B", 
                        ParentCategoryId = 0
                    });
            dataContext.SaveChanges();
        }

        #endregion
    }
}