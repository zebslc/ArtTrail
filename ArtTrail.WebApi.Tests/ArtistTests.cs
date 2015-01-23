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
    public class ArtistTests
    {
        [Test]
        public void GetArtistByNameReturnsTheCorrectArtist()
        {
            // Arrange
            const string expectedArtistName = "artist1";
            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetArtists()).Returns(new List<Artist> { new Artist { ArtistName = expectedArtistName } });

            // Act
            var returnedArtist = new ArtistController(dataRep.Object).GetArtistByName(expectedArtistName);

            // Assert
            returnedArtist.ArtistName.Should().Be(expectedArtistName);
        }

        [Test]
        public void GetArtistByIdReturnsTheCorrectArtist()
        {
            // Arrange
            const int expectedArtistId = 1;
            var dataRep = new Mock<IArtistRepository>();
            dataRep.Setup(x => x.GetArtists()).Returns(new List<Artist> { new Artist { ArtistId = expectedArtistId } });

            // Act
            var returnedArtist = new ArtistController(dataRep.Object).GetArtistById(expectedArtistId);

            // Assert
            returnedArtist.ArtistId.Should().Be(expectedArtistId);
        }

        [Test]
        public void GetArtistWithPaintingsReturnsTheCorrectNumberOfPaintings()
        {
            // Arrange
            const int expectedPaintingCount = 1;
            const string expectedArtistName = "artist1";
            var dataRep = new Mock<IArtistRepository>();
            var artist = new Artist { ArtistName = expectedArtistName };
            artist.AddPainting(new Painting { PaintingId = 1 });
            dataRep.Setup(x => x.GetArtists()).Returns(new List<Artist> { artist });

            // Act
            var paintingCount =
                new ArtistController(dataRep.Object).GetArtistByName(expectedArtistName).Paintings.Count();

            // Assert
            paintingCount.Should().Be(expectedPaintingCount);
        }
    }
}