using FlightApi.Models;
using FlightApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

/// <summary>
/// Unit tests for the FlightsController class.
/// </summary>
public class FlightsControllerTests
{
    private readonly Mock<IFlightService> _mockService;
    private readonly FlightsController _controller;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightsControllerTests"/> class.
    /// </summary>
    public FlightsControllerTests()
    {
        _mockService = new Mock<IFlightService>();
        _controller = new FlightsController(_mockService.Object);
    }

    /// <summary>
    /// Tests that GetAll returns Ok with flights.
    /// </summary>
    [Fact]
    public void GetAll_ReturnsOkWithFlights()
    {
        var flights = new List<Flight> { new Flight { Id = 1 } };
        _mockService.Setup(s => s.GetAll()).Returns(flights);

        var result = _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(flights, okResult.Value);
    }

    /// <summary>
    /// Tests that Create returns Created when the flight is valid.
    /// </summary>
    [Fact]
    public void Create_ValidFlight_ReturnsCreated()
    {
        var flight = new Flight { Id = 1, Airline = "MockAir" };
        _mockService.Setup(s => s.Create(flight)).Returns(flight);

        var result = _controller.Create(flight);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(flight, createdResult.Value);
    }

    /// <summary>
    /// Tests that Create returns BadRequest when the model is invalid.
    /// </summary>
    [Fact]
    public void Create_InvalidModel_ReturnsBadRequest()
    {
        _controller.ModelState.AddModelError("Airline", "Required");

        var result = _controller.Create(new Flight());

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
