namespace ArtTrail.DomainEntities.Tests
{
    using ArtTrail.DomainEntities;

    using Cavity;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class ArtistTests
    {
        [Test]
        public void ArtistShouldHaveAnId()
        {
            // Arrange
            const int expectedArtistId = 1;

            // Act
            var artist = new Artist { ArtistId = expectedArtistId };

            // Assert
            artist.ArtistId.Should().Be(expectedArtistId);
            
            new PropertyExpectations<Artist>(x => x.ArtistId)
                .IsAutoProperty<int>()
                .Result.Should().Be(true);
        }

        [Test]
        public void ArtistShouldHaveAName()
        {
            // Arrange
            const string expectedArtistName = "A";

            // Act
            var artist = new Artist { ArtistName = expectedArtistName };

            // Assert
            artist.ArtistName.Should().Be(expectedArtistName);

            new PropertyExpectations<Artist>(x => x.ArtistName)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void ArtistShouldHaveADescription()
        {
            // Arrange
            const string expectedArtistDescription = "A";

            // Act
            var artist = new Artist { ArtistDescription = expectedArtistDescription };

            // Assert
            artist.ArtistDescription.Should().Be(expectedArtistDescription);

            new PropertyExpectations<Artist>(x => x.ArtistDescription)
                .IsAutoProperty<string>()
                .Result.Should().Be(true);
        }

        [Test]
        public void ArtistsCanHavePaintings()
        {
            // Arrange
            const int expectedPaintingCount = 1;
            var artist = new Artist();
            artist.AddPainting(new Painting());

            // Act
            var actualPaintingCount = artist.Paintings.Count;

            // Assert
            actualPaintingCount.Should().Be(expectedPaintingCount);
        }

        [Test]
        public void ArtistObjectToStringShouldGiveArtistNameForEasyComparison()
        {
            // Arrange
            const string expectedArtistName = "A";

            // Act
            var artist = new Artist { ArtistName = expectedArtistName };

            // Assert
            artist.ToString().Should().Be(expectedArtistName);
        }
    }
}
