namespace ArtTrail.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;

    public class ArtistController : ApiController
    {
        #region Fields

        private readonly IArtistRepository artistRepository;
        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructors and Destructors

        public ArtistController(IArtistRepository artistRepository, ICategoryRepository categoryRepository)
        {
            this.artistRepository = artistRepository;
            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region Public Methods and Operators

        public Artist GetArtistById(int artistId)
        {
            return this.artistRepository.GetArtists().FirstOrDefault(x => x.ArtistId == artistId);
        }

        public Artist GetArtistByName(string artistName)
        {
            return
                this.artistRepository.GetArtists()
                    .FirstOrDefault(x => x.ArtistName.Equals(artistName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Artist> GetArtistsInCategory(string categoryName)
        {
            var categoryId = this.categoryRepository.GetCategoryIdFromName(categoryName);
            return
                this.artistRepository.GetArtists()
                    .Where(artist => artist.Categories.Any(x => x.CategoryId == categoryId));
        }

        public IEnumerable<Category> GetListOfMajorArtistCategories()
        {
            return
                this.categoryRepository.GetCategories()
                    .Where(x => x.ParentCategoryId == 0 && x.IsVenueOnlyCategory == false);
        }

        public IEnumerable<Category> GetListOfSubCategories(string majorCategory)
        {
            var parentCategoryId = this.categoryRepository.GetCategoryIdFromName(majorCategory);

            return this.categoryRepository.GetCategories().Where(y => y.ParentCategoryId == parentCategoryId);
        }

        #endregion
    }
}