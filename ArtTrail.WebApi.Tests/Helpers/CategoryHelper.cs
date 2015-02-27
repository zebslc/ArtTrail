using System.Collections.Generic;

namespace ArtTrail.WebApi.Tests.Helpers
{
    using ArtTrail.DomainEntities;

    public static class CategoryHelper
    {
        public static IEnumerable<Category> ExampleParentChildCategories()
        {
            return new List<Category>
                       {
                           new Category
                               {
                                   CategoryId = 1, 
                                   ParentCategoryId = 0, 
                                   IsVenueOnlyCategory = false, 
                                   CategoryName = "A"
                               }, 
                           new Category
                               {
                                   CategoryId = 2, 
                                   ParentCategoryId = 1, 
                                   IsVenueOnlyCategory = false, 
                                   CategoryName = "B"
                               }, 
                           new Category
                               {
                                   CategoryId = 3, 
                                   ParentCategoryId = 0, 
                                   IsVenueOnlyCategory = true, 
                                   CategoryName = "C"
                               }, 
                           new Category
                               {
                                   CategoryId = 4, 
                                   ParentCategoryId = 0, 
                                   IsVenueOnlyCategory = false, 
                                   CategoryName = "D"
                               }, 
                           new Category
                               {
                                   CategoryId = 5, 
                                   ParentCategoryId = 3, 
                                   IsVenueOnlyCategory = true, 
                                   CategoryName = "E"
                               }
                       };
        }
    }
}
