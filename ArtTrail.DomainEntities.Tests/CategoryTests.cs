namespace ArtTrail.DomainEntities.Tests
{
    using ArtTrail.DomainEntities;

    using Cavity;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void CategoryShouldHaveAnId()
        {
            // Arrange
            const int expectedCategoryId = 1;

            // Act
            var category = new Category { CategoryId = expectedCategoryId };

            // Assert
            category.CategoryId.Should().Be(expectedCategoryId);

            new PropertyExpectations<Category>(x => x.CategoryId)
                .IsAutoProperty<int>()
                .Result.Should().Be(true);
        }

        [Test]
        public void CategoryShouldHaveAName()
        {
            // Arrange
            const string expectedCategoryName = "A";

            // Act
            var category = new Category { CategoryName = expectedCategoryName };

            // Assert
            category.CategoryName.Should().Be(expectedCategoryName);

            new PropertyExpectations<Category>(x => x.CategoryName)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void CategoryShouldHaveADescription()
        {
            // Arrange
            const string expectedCategoryDescription = "A";

            // Act
            var category = new Category { CategoryDescription = expectedCategoryDescription };

            // Assert
            category.CategoryDescription.Should().Be(expectedCategoryDescription);

            new PropertyExpectations<Category>(x => x.CategoryDescription)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void CategoryShouldHaveAnOptionalVenueOnlyLocation()
        {
            // Arrange
            const bool expectedIsVenueOnlyCategory = true;

            // Act
            var category = new Category { IsVenueOnlyCategory = expectedIsVenueOnlyCategory };

            // Assert
            category.IsVenueOnlyCategory.Should().Be(expectedIsVenueOnlyCategory);

            new PropertyExpectations<Category>(x => x.IsVenueOnlyCategory)
                .IsAutoProperty<bool>()
                .Result.Should().Be(true);
        }

        [Test]
        public void CategoryObjectToStringShouldGiveCategoryNameForEasyComparison()
        {
            // Arrange
            const string expectedCategoryName = "A";

            // Act
            var category = new Category { CategoryName = expectedCategoryName };

            // Assert
            category.ToString().Should().Be(expectedCategoryName);
        }

        [Test]
        public void CategoryCanHaveSubCategories()
        {
            // Arrange
            const int expectedCategoryCount = 1;

            // Act
            var category = new Category();
            category.AddCategory(new Category());

            // Assert
            category.ChildCategories.Count.Should().Be(expectedCategoryCount);
        }
    }
}
