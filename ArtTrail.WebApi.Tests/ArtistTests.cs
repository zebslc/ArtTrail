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
        #region Public Methods and Operators

        [Test]
        public void GetArtistByIdReturnsTheCorrectArtist()
        {
            // Arrange
            const int expectedArtistId = 1;
            var dataArtistRep = new Mock<IArtistRepository>();
            dataArtistRep.Setup(x => x.GetArtists()).Returns(new List<Artist> { new Artist { ArtistId = expectedArtistId } });

            // Act
            var returnedArtist = new ArtistController(dataArtistRep.Object, null).GetArtistById(expectedArtistId);

            // Assert
            returnedArtist.ArtistId.Should().Be(expectedArtistId);
        }

        [Test]
        public void GetArtistByNameReturnsTheCorrectArtist()
        {
            // Arrange
            const string expectedArtistName = "artist1";
            var dataArtistRep = new Mock<IArtistRepository>();
            dataArtistRep.Setup(x => x.GetArtists())
                .Returns(new List<Artist> { new Artist { ArtistName = expectedArtistName } });

            // Act
            var returnedArtist = new ArtistController(dataArtistRep.Object, null).GetArtistByName(expectedArtistName);

            // Assert
            returnedArtist.ArtistName.Should().Be(expectedArtistName);
        }

        [Test]
        public void GetArtistWithPaintingsReturnsTheCorrectNumberOfPaintings()
        {
            // Arrange
            const int expectedPaintingCount = 1;
            const string expectedArtistName = "artist1";
            var dataArtistRep = new Mock<IArtistRepository>();
            var artist = new Artist { ArtistName = expectedArtistName };
            artist.AddPainting(new Painting { PaintingId = 1 });
            dataArtistRep.Setup(x => x.GetArtists()).Returns(new List<Artist> { artist });

            // Act
            var paintingCount =
                new ArtistController(dataArtistRep.Object, null).GetArtistByName(expectedArtistName).Paintings.Count();

            // Assert
            paintingCount.Should().Be(expectedPaintingCount);
        }

        #endregion
    }
}