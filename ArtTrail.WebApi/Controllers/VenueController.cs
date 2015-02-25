namespace ArtTrail.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class VenueController
    {
        #region Fields

        private readonly IVenueRepository venueRepository;
        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructors and Destructors

        public VenueController(IVenueRepository venueRepository, ICategoryRepository categoryRepository)
        {
            this.venueRepository = venueRepository;
            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region Public Methods and Operators

        public IEnumerable<Category> GetListOfMajorCategories()
        {
            return this.categoryRepository.GetCategories().Where(x => x.ParentCategoryId == 0 && x.IsVenueOnlyCategory);
        }

        public IEnumerable<Category> GetListOfSubCategories(string majorCategory)
        {
            var parentCategoryId = this.categoryRepository.GetCategoryIdFromName(majorCategory);

            return this.categoryRepository.GetCategories().Where(y => y.ParentCategoryId == parentCategoryId);
        }

        public Venue GetVenueById(int expectedVenueId)
        {
            return this.venueRepository.GetVenues().FirstOrDefault(x => x.VenueId == expectedVenueId);
        }

        public Venue GetVenueByName(string expectedVenueName)
        {
            return
                this.venueRepository.GetVenues()
                    .FirstOrDefault(x => x.VenueName.Equals(expectedVenueName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Venue> GetVenueList()
        {
            return this.venueRepository.GetVenues().OrderBy(x => x.VenueName);
        }

        public IEnumerable<Venue> GetVenuesInCategory(string categoryName)
        {
            var categoryId = this.categoryRepository.GetCategoryIdFromName(categoryName);
            return this.venueRepository.GetVenues()
                .Where(venue => venue.Categories.Any(x => x.CategoryId == categoryId));
        }

        #endregion
    }
}