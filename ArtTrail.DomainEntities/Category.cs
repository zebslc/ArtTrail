namespace ArtTrail.DomainEntities
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.ChildCategories = new List<Category>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsVenueOnlyCategory { get; set; }

        public int ParentCategoryId { get; set; }

        public string CategoryDescription { get; set; }

        public IList<Category> ChildCategories { get; private set; }

        public IList<Artist> ArtistCategories { get; set; }

        public override string ToString()
        {
            return this.CategoryName;
        }


        public void AddCategory(Category categoryToAdd)
        {
            this.ChildCategories.Add(categoryToAdd);
        }
    }
}
