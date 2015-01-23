namespace ArtTrail.DomainEntities.Tests
{
    using ArtTrail.DomainEntities;

    using Cavity;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class PaintingTests
    {
        [Test]
        public void PaintingShouldHaveAnId()
        {
            // Arrange
            const int expectedPaintingId = 1;

            // Act
            var painting = new Painting { PaintingId = expectedPaintingId };

            // Assert
            painting.PaintingId.Should().Be(expectedPaintingId);

            new PropertyExpectations<Painting>(x => x.PaintingId)
                .IsAutoProperty<int>()
                .Result.Should().Be(true);
        }

        [Test]
        public void PaintingShouldHaveAName()
        {
            // Arrange
            const string expectedPaintingName = "A";

            // Act
            var painting = new Painting { PaintingName = expectedPaintingName };

            // Assert
            painting.PaintingName.Should().Be(expectedPaintingName);

            new PropertyExpectations<Painting>(x => x.PaintingName)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void PaintingShouldHaveADescription()
        {
            // Arrange
            const string expectedPaintingDescription = "A";

            // Act
            var painting = new Painting { PaintingDescription = expectedPaintingDescription };

            // Assert
            painting.PaintingDescription.Should().Be(expectedPaintingDescription);

            new PropertyExpectations<Painting>(x => x.PaintingDescription)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }
        [Test]
        public void PaintingShouldHaveUrl()
        {
            // Arrange
            const string expectedPaintingUrl = "A";

            // Act
            var painting = new Painting { PaintingUrl = expectedPaintingUrl };

            // Assert
            painting.PaintingUrl.Should().Be(expectedPaintingUrl);

            new PropertyExpectations<Painting>(x => x.PaintingUrl)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void PaintingObjectToStringShouldGivePaintingNameForEasyComparison()
        {
            // Arrange
            const string expectedPaintingName = "A";

            // Act
            var painting = new Painting { PaintingName = expectedPaintingName };

            // Assert
            painting.ToString().Should().Be(expectedPaintingName);
        }
    }
}
