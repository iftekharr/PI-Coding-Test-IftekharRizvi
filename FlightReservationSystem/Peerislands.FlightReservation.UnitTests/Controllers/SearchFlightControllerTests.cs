using FluentAssertions;
using Moq;
using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;
using Peerislands.FlightReservation.Interactor;
using Peerislands.FlightReservation.UnitTests.TestDataProvider;
using Peerislands.FlightReservation.Web.Controllers;

namespace Peerislands.FlightReservation.UnitTests.Controllers
{
    public class SearchFlightControllerTests
    {
        private readonly Mock<ISearchFlightInteractor> _mockSearchFlightInteractor;
        private readonly SearchFlightController _searchFlightController;

        public SearchFlightControllerTests()
        {
            _mockSearchFlightInteractor = new Mock<ISearchFlightInteractor>();
            _searchFlightController = new SearchFlightController(_mockSearchFlightInteractor.Object);
        }

        [Fact]
        [Trait("Scenario", @"Given: SearchFlightController is called
                             When: Request is valid
                             Then: It should return response successfully")]
        public async Task SearchFlightController_With_Valid_Request_Should_Return_Response_Successfully()
        {
            var mockSearchFlightRequest = new SearchFlightRequest();
            mockSearchFlightRequest = SearchFlightMockDataProvider.GetSearchFlightRequest();

            _mockSearchFlightInteractor.Setup(x => x.SearchFlightAsync(It.IsAny<SearchFlightRequest>()))
                .Returns(Task.FromResult(SearchFlightMockDataProvider.GetSearchFlightResponse()));

            var response = await _searchFlightController.SearchFlightAsync(mockSearchFlightRequest);
            _mockSearchFlightInteractor.Verify(x => x.SearchFlightAsync(mockSearchFlightRequest), Times.Once);
            response.Should().NotBeNull();
        }
    }
}
