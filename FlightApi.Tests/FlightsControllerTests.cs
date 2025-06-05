using FlightApi.Models;
using FlightApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FlightApi.Tests
{
    public class FlightsControllerTests
    {
        private readonly Mock<IFlightService> _mockService;
        private readonly Mock<ILogger<FlightsController>> _mockLogger;
        private readonly FlightsController _controller;

        public FlightsControllerTests()
        {
            _mockService = new Mock<IFlightService>();
            _mockLogger = new Mock<ILogger<FlightsController>>();
            _controller = new FlightsController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResult_WithListOfFlights()
        {
            var flights = new List<Flight> { new Flight { Id = 1, FlightNumber = "XY123" } };
            _mockService.Setup(s => s.GetAll()).Returns(flights);

            var result = _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnFlights = Assert.IsAssignableFrom<IEnumerable<Flight>>(okResult.Value);
            Assert.Single(returnFlights);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            var flight = new Flight { Id = 1, FlightNumber = "XY123" };
            _mockService.Setup(s => s.GetById(1)).Returns(flight);

            var result = _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(flight, okResult.Value);
        }

        [Fact]
        public void Create_ValidFlight_ReturnsCreatedAtAction()
        {
            var flight = new Flight { Id = 1, FlightNumber = "XY123" };
            _mockService.Setup(s => s.Create(It.IsAny<Flight>())).Returns(flight);

            var result = _controller.Create(flight);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", createdResult.ActionName);
        }

        [Fact]
        public void Update_ValidFlight_ReturnsNoContent()
        {
            var flight = new Flight { Id = 1, FlightNumber = "XY123" };

            // Mock the GetById to simulate an existing flight
            _mockService.Setup(s => s.GetById(1)).Returns(flight);

            // Act
            var result = _controller.Update(1, flight);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_InvalidFlight_ReturnsNotFound()
        {
            // Arrange
            var flight = new Flight { Id = 999, FlightNumber = "INVALID" };

            // Simulate that the flight does not exist
            _mockService.Setup(s => s.GetById(999)).Returns((Flight)null);

            // Act
            var result = _controller.Update(999, flight);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Flight with ID 999 not found.", notFoundResult.Value);
        }

        [Fact]
        public void Delete_ValidId_ReturnsNoContent()
        {
            var flight = new Flight { Id = 1, FlightNumber = "XY123" };

            // Mocking GetById so the controller thinks the flight exists
            _mockService.Setup(s => s.GetById(1)).Returns(flight);

            var result = _controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange: flight doesn't exist
            _mockService.Setup(s => s.GetById(999)).Returns((Flight)null);

            // Act
            var result = _controller.Delete(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Flight with ID 999 not found.", notFoundResult.Value);
        }


        [Fact]
        public void Search_ByAirline_ReturnsOkResult()
        {
            var flights = new List<Flight> { new Flight { Id = 1, Airline = "Delta" } };
            _mockService.Setup(s => s.Search("Delta", null, null)).Returns(flights);

            var result = _controller.Search("Delta", null, null);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Flight>>(okResult.Value);
        }

    }
}
