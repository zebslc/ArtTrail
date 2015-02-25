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
    public class VenueCategoryTests
    {
        #region Public Methods and Operators

        [Test]
        public void AVenueWithinACategoryIsReturned()
        {
            // Arrange
            const int expectedVenueCount = 1;
            const string expectedCategory = "A";

            var dataVenueRep = new Mock<IVenueRepository>();
            dataVenueRep.Setup(x => x.GetVenues()).Returns(VenueHelper.ExampleVenues());
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());
            dataCategoryRep.Setup(x => x.GetCategoryIdFromName(It.IsAny<string>())).Returns(1);

            // Act
            var artistCount = new VenueController(dataVenueRep.Object, dataCategoryRep.Object).GetVenuesInCategory(expectedCategory).Count();

            // Assert
            artistCount.Should().Be(expectedVenueCount);
        }

        [Test]
        public void OnlyChildrenSubCategoriesAreReturnedWhenAMajorCategoryIsRequested()
        {
            // Arrange
            const string majorCategory = "A";
            const int expectedCategoryId = 1;

            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());
            dataCategoryRep.Setup(x => x.GetCategoryIdFromName(It.IsAny<string>())).Returns(1);

            // Act
            var actualCategories = new VenueController(null, dataCategoryRep.Object).GetListOfSubCategories(majorCategory);
            var category = actualCategories.First();

            // Assert
            category.ParentCategoryId.Should().Be(expectedCategoryId);
        }

        [Test]
        public void OnlyParentCategoriesAreReturnedWhenMajorCategoriesRequested()
        {
            // Arrange
            const int expectedCategoryCount = 1;
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());

            // Act
            var actualCategoryCount = new VenueController(null, dataCategoryRep.Object).GetListOfMajorCategories().Count();

            // Assert
            actualCategoryCount.Should().Be(expectedCategoryCount);
        }

        [Test]
        public void VenueOnlyCategoriesAreReturnedWhenRequestingCategories()
        {
            // Arrange
            const int expectedCategoryCount = 1;
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());

            // Act
            var actualCategories =
                new VenueController(null, dataCategoryRep.Object).GetListOfMajorCategories().Where(x => x.IsVenueOnlyCategory);
            var actualCategoriesWithVenueOnlyCount = actualCategories.Count(x => x.IsVenueOnlyCategory);

            // Assert
            actualCategoriesWithVenueOnlyCount.Should().Be(expectedCategoryCount);
        }

        #endregion

    }
}