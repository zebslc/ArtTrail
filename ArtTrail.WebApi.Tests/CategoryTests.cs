namespace ArtTrail.WebApi.Tests
{
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.WebApi.Controllers;
    using ArtTrail.WebApi.Tests.Helpers;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    public class CategoryTests
    {

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
            var actualCategories = new ArtistController(null, dataCategoryRep.Object).GetListOfSubCategories(majorCategory);
            var category = actualCategories.First();

            // Assert
            category.ParentCategoryId.Should().Be(expectedCategoryId);
        }

        [Test]
        public void OnlyParentCategoriesAreReturnedWhenMajorCategoriesRequested()
        {
            // Arrange
            const int expectedCategoryCount = 2;
            var dataCategoryRep = new Mock<ICategoryRepository>();
            dataCategoryRep.Setup(x => x.GetCategories()).Returns(CategoryHelper.ExampleParentChildCategories());

            // Act
            var actualCategoryCount = new ArtistController(null, dataCategoryRep.Object).GetListOfMajorArtistCategories().Count();

            // Assert
            actualCategoryCount.Should().Be(expectedCategoryCount);
        }
    }
}
