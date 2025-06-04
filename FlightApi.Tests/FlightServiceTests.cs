using FlightApi.Models;
using FlightApi.Repositories;
using FlightApi.Services;
using Moq;

/// <summary>
/// Unit tests for the FlightService class.
/// </summary>
public class FlightServiceTests
{
    private readonly Mock<IFlightRepository> _mockRepo;
    private readonly FlightService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightServiceTests"/> class.
    /// </summary>
    public FlightServiceTests()
    {
        _mockRepo = new Mock<IFlightRepository>();
        _service = new FlightService(_mockRepo.Object);
    }

    /// <summary>
    /// Tests that GetAll returns all flights.
    /// </summary>
    [Fact]
    public void GetAll_ReturnsAllFlights()
    {
        var flights = new List<Flight> { new Flight { Id = 1 }, new Flight { Id = 2 } };
        _mockRepo.Setup(r => r.GetAll()).Returns(flights);

        var result = _service.GetAll();

        Assert.Equal(2, result.Count());
    }

    /// <summary>
    /// Tests that GetById returns the correct flight.
    /// </summary>
    [Fact]
    public void GetById_ReturnsCorrectFlight()
    {
        var flight = new Flight { Id = 1, Airline = "TestAir" };
        _mockRepo.Setup(r => r.GetById(1)).Returns(flight);

        var result = _service.GetById(1);

        Assert.Equal("TestAir", result.Airline);
    }
}
