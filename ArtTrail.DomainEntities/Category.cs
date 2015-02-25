namespace ArtTrail.DomainEntities
{
    using System.Collections.Generic;

    public class Category
    {
        #region Constructors and Destructors

        public Category()
        {
            this.ChildCategories = new List<Category>();
        }

        #endregion

        #region Public Properties

        public IList<Artist> ArtistCategories { get; private set; }

        public IList<Venue> VenueCategories { get; private set; }

        public string CategoryDescription { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IList<Category> ChildCategories { get; private set; }

        public bool IsVenueOnlyCategory { get; set; }

        public int ParentCategoryId { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddCategory(Category categoryToAdd)
        {
            this.ChildCategories.Add(categoryToAdd);
        }

        public override string ToString()
        {
            return this.CategoryName;
        }

        #endregion
    }
}