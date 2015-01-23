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
        private readonly IArtistRepository artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public IEnumerable<Category> GetListOfMajorCategories()
        {
            return this.artistRepository.GetCategories().Where(x => x.ParentCategoryId == 0 && x.IsVenueOnlyCategory == false);
        }

        public IEnumerable<Category> GetListOfSubCategories(string majorCategory)
        {
            var parentCategoryId = this.artistRepository.GetCategoryIdFromName(majorCategory);

            return this.artistRepository.GetCategories().Where(y => y.ParentCategoryId == parentCategoryId);
        }

        public Artist GetArtistByName(string artistName)
        {
            return this.artistRepository.GetArtists().FirstOrDefault(x => x.ArtistName.Equals(artistName, StringComparison.OrdinalIgnoreCase));
        }

        public Artist GetArtistById(int artistId)
        {
            return this.artistRepository.GetArtists().FirstOrDefault(x => x.ArtistId == artistId);
        }

        public IEnumerable<Artist> GetArtistsInCategory(string categoryName)
        {
            var categoryId = this.artistRepository.GetCategoryIdFromName(categoryName);
            return
                this.artistRepository.GetArtists()
                    .Where(
                        artist =>
                        artist.Categories.Any(
                            x => x.CategoryId == categoryId));
        }
    }
}