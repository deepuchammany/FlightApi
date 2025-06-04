using FlightApi.Models;
using FlightApi.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing flight operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightsController"/> class.
    /// </summary>
    /// <param name="flightService">Service for flight operations.</param>
    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    /// <summary>
    /// Retrieves all flights.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll() => Ok(_flightService.GetAll());

    /// <summary>
    /// Retrieves a flight by its ID.
    /// </summary>
    /// <param name="id">Flight ID.</param>
    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_flightService.GetById(id));

    /// <summary>
    /// Creates a new flight.
    /// </summary>
    /// <param name="flight">Flight to create.</param>
    [HttpPost]
    public IActionResult Create([FromBody] Flight flight)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = _flightService.Create(flight);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Updates an existing flight.
    /// </summary>
    /// <param name="id">Flight ID.</param>
    /// <param name="flight">Updated flight data.</param>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Flight flight)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _flightService.Update(id, flight);
        return NoContent();
    }

    /// <summary>
    /// Deletes a flight by its ID.
    /// </summary>
    /// <param name="id">Flight ID.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _flightService.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Searches for flights by airline, departure, or arrival.
    /// </summary>
    /// <param name="airline">Airline name.</param>
    /// <param name="departure">Departure airport.</param>
    /// <param name="arrival">Arrival airport.</param>
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string? airline, [FromQuery] string? departure, [FromQuery] string? arrival)
        => Ok(_flightService.Search(airline, departure, arrival));
}