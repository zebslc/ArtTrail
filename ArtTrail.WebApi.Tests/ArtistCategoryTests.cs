namespace ArtTrail.WebApi.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using ArtTrail.Data.Interfaces;
    using ArtTrail.DomainEntities;
    using ArtTrail.WebApi.Controllers;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ArtistCategoryTests
    {
        #region Public Methods and Operators

        [Test]
        public void OnlyParentCategoriesAreReturnedWhenMajorCategoriesRequested()
        {
            // Arrange
            const int expectedCategoryCount = 2;
            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetCategories()).Returns(this.ExampleParentChildCategories());

            // Act
            var actualCategoryCount = new ArtistController(dataRep.Object).GetListOfMajorCategories().Count();

            // Assert
            actualCategoryCount.Should().Be(expectedCategoryCount);
        }

        [Test]
        public void OnlyChildrenSubCategoriesAreReturnedWhenAMajorCategoryIsRequested()
        {
            // Arrange
            const string majorCategory = "A";
            const int expectedCategoryId = 1;

            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetCategories()).Returns(this.ExampleParentChildCategories());
            dataRep.Setup(x => x.GetCategoryIdFromName(It.IsAny<string>())).Returns(1);

            // Act
            var actualCategories = new ArtistController(dataRep.Object).GetListOfSubCategories(majorCategory);
            var category = actualCategories.First();

            // Assert
            category.ParentCategoryId.Should().Be(expectedCategoryId);
        }

        [Test]
        public void VenueOnlyCategoriesAreNotReturnedWhenRequestingArtistCategories()
        {
            // Arrange
            const int expectedCategoryCount = 0;
            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetCategories()).Returns(this.ExampleParentChildCategories());

            // Act
            var actualCategories = new ArtistController(dataRep.Object).GetListOfMajorCategories().Where(x => x.IsVenueOnlyCategory);
            var actualCategoriesWithVenueOnlyCount = actualCategories.Count(x => x.IsVenueOnlyCategory);

            // Assert
            actualCategoriesWithVenueOnlyCount.Should().Be(expectedCategoryCount);
        }

        [Test]
        public void AnArtistWithinACategoryIsReturned()
        {
            // Arrange
            const int expectedArtistCount = 1;
            const string expectedCategory = "A";

            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetArtists()).Returns(ExampleArtists());
            dataRep.Setup(x => x.GetCategories()).Returns(this.ExampleParentChildCategories());
            dataRep.Setup(x => x.GetCategoryIdFromName(It.IsAny<string>())).Returns(1);

            // Act
            var artistCount = new ArtistController(dataRep.Object).GetArtistsInCategory(expectedCategory).Count();

            // Assert
            artistCount.Should().Be(expectedArtistCount);
        }

        private static IEnumerable<Artist> ExampleArtists()
        {
            var artist1 = new Artist { ArtistId = 1, ArtistName = "Artist1" };
            artist1.AddCategory(new Category { CategoryId = 1 });
            artist1.AddCategory(new Category { CategoryId = 2 });
            artist1.AddPainting(new Painting { PaintingId = 1, PaintingName = "A" });
            artist1.AddPainting(new Painting { PaintingId = 2, PaintingName = "B" });

            var artist2 = new Artist { ArtistId = 2, ArtistName = "Artist2" };
            artist1.AddCategory(new Category { CategoryId = 2 });

            return new List<Artist> { artist1, artist2 };
        }

        #endregion

        private IEnumerable<Category> ExampleParentChildCategories()
        {
            return new List<Category>
                                  {
                                      new Category { CategoryId = 1, ParentCategoryId = 0, IsVenueOnlyCategory = false, CategoryName = "A" },
                                      new Category { CategoryId = 2, ParentCategoryId = 1, IsVenueOnlyCategory = false, CategoryName = "B" },
                                      new Category { CategoryId = 3, ParentCategoryId = 0, IsVenueOnlyCategory = true, CategoryName = "C" },
                                      new Category { CategoryId = 4, ParentCategoryId = 0, IsVenueOnlyCategory = false, CategoryName = "D" },
                                      new Category { CategoryId = 5, ParentCategoryId = 3, IsVenueOnlyCategory = true, CategoryName = "E" }
                                  };
        }
    }
}