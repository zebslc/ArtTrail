namespace ArtTrail.WebApi.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;
    using ArtTrail.WebApi.Controllers;
    using ArtTrail.WebApi.Tests.Helpers;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ArtistCategoryTests
    {
        #region Public Methods and Operators

        [Test]
        public void AnArtistWithinACategoryIsReturned()
        {
            // Arrange
            const int expectedArtistCount = 1;
            const string expectedCategory = "A";

            var dataArtistRep = new Mock<IArtistRepository>();
            dataArtistRep.Setup(x => x.GetArtists()).Returns(ArtistHelper.ExampleArtists());
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());
            dataCategoryRep.Setup(x => x.GetCategoryIdFromName(It.IsAny<string>())).Returns(1);

            // Act
            var artistCount = new ArtistController(dataArtistRep.Object, dataCategoryRep.Object).GetArtistsInCategory(expectedCategory).Count();

            // Assert
            artistCount.Should().Be(expectedArtistCount);
        }

        [Test]
        public void VenueOnlyCategoriesAreNotReturnedWhenRequestingArtistCategories()
        {
            // Arrange
            const int expectedCategoryCount = 0;
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());
            var dataArtistRep = new Mock<IArtistRepository>();

            // Act
            var actualCategories =
                new ArtistController(dataArtistRep.Object, dataCategoryRep.Object).GetListOfMajorArtistCategories().Where(x => x.IsVenueOnlyCategory);
            var actualCategoriesWithVenueOnlyCount = actualCategories.Count(x => x.IsVenueOnlyCategory);

            // Assert
            actualCategoriesWithVenueOnlyCount.Should().Be(expectedCategoryCount);
        }

        #endregion

    }
}