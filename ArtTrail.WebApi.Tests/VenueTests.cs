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
    public class VenueTests
    {
        #region Public Methods and Operators

        [Test]
        public void GetVenueByIdReturnsTheCorrectVenue()
        {
            // Arrange
            const int expectedVenueId = 1;
            var dataRep = new Mock<IVenueRepository>();
            dataRep.Setup(x => x.GetVenues()).Returns(new List<Venue> { new Venue { VenueId = expectedVenueId } });

            // Act
            var returnedVenue = new VenueController(dataRep.Object, null).GetVenueById(expectedVenueId);

            // Assert
            returnedVenue.VenueId.Should().Be(expectedVenueId);
        }

        [Test]
        public void GetVenueByNameReturnsTheCorrectVenue()
        {
            // Arrange
            const string expectedVenueName = "venue1";
            var dataRep = new Mock<IVenueRepository>();
            dataRep.Setup(x => x.GetVenues()).Returns(new List<Venue> { new Venue { VenueName = expectedVenueName } });

            // Act
            var returnedVenue = new VenueController(dataRep.Object, null).GetVenueByName(expectedVenueName);

            // Assert
            returnedVenue.VenueName.Should().Be(expectedVenueName);
        }

        [Test]
        public void GetVenueListShouldReturnAllVenues()
        {
            // Arrange
            const int expectedVenueCount = 2;
            var dataRep = new Mock<IVenueRepository>();
            dataRep.Setup(x => x.GetVenues()).Returns(new List<Venue> { new Venue(), new Venue() });

            // Act
            var returnedVenues = new VenueController(dataRep.Object, null).GetVenueList();

            // Assert
            returnedVenues.Count().Should().Be(expectedVenueCount);
        }

        #endregion
    }
}